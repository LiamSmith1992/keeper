
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
    img = @img
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, update);
    return rows > 0;
  }

  internal List<Keep> GetVaultKeeps(int vaultId)
  {
    string sql = @"
    SELECT
   k.*,
   a.*,
   vk.*
   FROM keeps k 
  JOIN accounts a ON k.creatorId = a.id
  JOIN vaultKeeps vk ON k.creatorId = vk.creatorId
   WHERE vk.vaultId = @vaultId
    ";
    List<Keep> keeps = _db.Query<Keep, Account, VaultKeep, Keep>(sql, (keep, account, vaultKeep) =>
    {
      keep.Creator = account;
      // keep.vaultKeepId = vaultKeep.Id;
      return keep;
    }, new { vaultId }).ToList();
    return keeps;
  }
}
