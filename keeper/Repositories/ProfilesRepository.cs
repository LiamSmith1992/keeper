

namespace keeper.Repositories;

public class ProfilesRepository
{

  private readonly IDbConnection _db;

  public ProfilesRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Account GetOne(string id)
  {
    string sql = @"
    SELECT * FROM accounts
    WHERE id = @id
    ";
    Account profile = _db.Query<Account>(sql, new { id }).FirstOrDefault();
    return profile;
  }

  internal List<Keep> GetProfileKeeps(string id)
  {
    string sql = @"
    SELECT * FROM keeps
    WHERE creatorId = @id
    ";
    List<Keep> keeps = _db.Query<Keep>(sql, new { id }).ToList();
    return keeps;
  }

  internal List<Vault> GetProfileVaults(string id)
  {
    string sql = @"
    SELECT * FROM vaults
    WHERE creatorId = @id
    AND isPrivate = false;
    ";
    List<Vault> vaults = _db.Query<Vault>(sql, new { id }).ToList();
    return vaults;
  }
}
