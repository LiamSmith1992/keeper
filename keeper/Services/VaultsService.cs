
namespace keeper.Services;

public class VaultsService
{
  private readonly VaultsRepository _repo;

  public VaultsService(VaultsRepository repo)
  {
    _repo = repo;
  }

  internal Vault Create(Vault vaultData)
  {
    Vault vault = _repo.Create(vaultData);
    return vault;
  }

  internal Vault GetVaultById(int vaultId, string userId)
  {
    Vault vault = _repo.GetOne(vaultId);
    if (vault == null)
    {
      throw new Exception("no vault at that id");
    }
    if (vault.IsPrivate == true && vault.CreatorId != userId)
    {
      throw new Exception("you don't own that vault");
    }
    return vault;
  }
}
