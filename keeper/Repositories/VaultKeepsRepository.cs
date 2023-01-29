

namespace keeper.Repositories;

public class VaultKeepsRepository
{

  private readonly IDbConnection _db;

  public VaultKeepsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal VaultKeep Create(VaultKeep vaultKeepData)
  {
    string sql = @"
    INSERT INTO vaultKeeps
    (vaultId, keepId, creatorId)
    Values
    (@vaultId, @keepId, @creatorId);
    SELECT LAST_INSERT_ID();
    ";
    int id = _db.ExecuteScalar<int>(sql, vaultKeepData);
    vaultKeepData.Id = id;
    return vaultKeepData;
  }





}
