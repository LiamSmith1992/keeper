using keeper.Interfaces;

namespace keeper.Repositories;

public class VaultsRepository : IRepository<Vault, int>
{
  private readonly IDbConnection _db;

  public VaultsRepository(IDbConnection db)
  {
    _db = db;
  }

  public Vault Create(Vault vaultData)
  {
    string sql = @"
   INSERT INTO vaults
   (creatorId, name, description, img, isPrivate)
   VALUES
   (@creatorId, @name, @description, @img, @isPrivate);
   SELECT LAST_INSERT_ID();
   ";
    int id = _db.ExecuteScalar<int>(sql, vaultData);
    vaultData.Id = id;
    return vaultData;
  }

  public bool Delete(int id)
  {
    string sql = @"
    DELETE FROM vaults
    WHERE id = @id
    ";
    int rows = _db.Execute(sql, new { id });
    return rows > 0;
  }

  public List<Vault> Get()
  {
    throw new NotImplementedException();
  }

  public Vault GetOne(int id)
  {
    string sql = @"
    SELECT 
    v.*,
    a.*
    FROM vaults v
    JOIN accounts a ON a.id = v.creatorId
    WHERE v.id = @id;
    ";
    Vault vault = _db.Query<Vault, Account, Vault>(sql, (vault, account) =>
    {
      vault.Creator = account;
      return vault;
    }, new { id }).FirstOrDefault();
    return vault;
  }

  public bool Update(Vault update)
  {
    string sql = @"
    UPDATE vaults SET
    name = @name,
    description = @description,
    img = @img,
    isPrivate = @isPrivate
    WHERE id = @id;
    ";
    int rows = _db.Execute(sql, update);
    return rows > 0;
  }
}
