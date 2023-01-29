

namespace keeper.Services;

public class ProfilesService
{

  private readonly ProfilesRepository _repo;

  public ProfilesService(ProfilesRepository repo)
  {
    _repo = repo;
  }

  internal Account GetOne(string id)
  {

    Account profile = _repo.GetOne(id);

    return profile;
  }

  internal List<Keep> GetProfileKeeps(string id)
  {
    List<Keep> keeps = _repo.GetProfileKeeps(id);

    return keeps;
  }

  internal List<Vault> GetProfileVaults(string id)
  {
    List<Vault> vaults = _repo.GetProfileVaults(id);
    return vaults;
  }
}
