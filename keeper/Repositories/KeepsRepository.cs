
using keeper.Interfaces;
namespace keeper.Repositories;

public class KeepsRepository : IRepository<Keep, int>
{
  private readonly IDbConnection _db;

  public KeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Keep Create(Keep keepData)
  {
    string sql = @"
    INSERT INTO keeps
    (creatorId, name, description, img)
    VALUES
    (@creatorId, @name, @description, @img);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, keepData);
    keepData.Id = id;
    return keepData;
  }

  public List<Keep> Get()
  {
    string sql = @"
    SELECT
    k.*,
    a.*
    FROM keeps k 
    JOIN accounts a ON a.id = k.creatorId
    ";
    List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
    {
      keep.Creator = account;
      return keep;
    }).ToList();
    return keeps;
  }

  public Keep GetOne(int id)
  {
    string sql = @"
    UPDATE keeps set
    views = views +1
    WHERE id = @id;
    SELECT 
    k.*,
    a.*
    FROM keeps k
    JOIN accounts a ON a.id = k.creatorId
    WHERE k.id = @id;
    ";
    Keep keep = _db.Query<Keep, Account, Keep>(sql, (keep, account) =>
    {
      keep.Creator = account;
      return keep;
    }, new { id }).FirstOrDefault();
    return keep;
  }
  public bool Delete(int id)
  {
    string sql = @"
    DELETE FROM keeps
    WHERE id = @id
    ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;
  }


  public bool Update(Keep update)
  {
    string sql = @"
    UPDATE keeps
    SET
    name = @name,
    description = @description,
    img = @img,
    kept = @kept
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, update);
    return rows > 0;
  }

  internal List<Keeper> GetVaultKeeps(int vaultId)
  {
    string sql = @"
    SELECT
   k.*,
   vk.*,
   a.*
   FROM keeps k
   JOIN vaultKeeps vk ON k.id = vk.keepId
  JOIN accounts a ON k.creatorId = a.id
   WHERE vk.vaultId = @vaultId;
    ";
    List<Keeper> keeps = _db.Query<Keeper, VaultKeep, Account, Keeper>(sql, (keep, vaultKeep, account) =>
    {
      keep.VaultKeepId = vaultKeep.Id;
      keep.Creator = account;

      // keep.vaultKeepId = vaultKeep.Id;
      return keep;
    }, new { vaultId }).ToList();
    return keeps;
  }
}
