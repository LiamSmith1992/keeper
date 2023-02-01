

namespace keeper.Services;

public class VaultKeepsService
{
  private readonly VaultKeepsRepository _repo;
  private readonly KeepsService _keepsService;
  private readonly VaultsService _vaultsService;

  public VaultKeepsService(VaultKeepsRepository repo, KeepsService keepsService, VaultsService vaultsService)
  {
    _repo = repo;
    _keepsService = keepsService;
    _vaultsService = vaultsService;
  }

  internal VaultKeep Create(VaultKeep vaultKeepData)
  {
    Vault vault = _vaultsService.GetVaultById(vaultKeepData.VaultId, vaultKeepData.CreatorId);
    if (vault.CreatorId != vaultKeepData.CreatorId)
    {
      throw new Exception("you can't do that");
    }
    if (vault.IsPrivate == true && vaultKeepData.CreatorId != vault.CreatorId)
    {
      throw new Exception("you can't do that");
    }
    Keep keep = _keepsService.GetOne(vaultKeepData.KeepId);
    VaultKeep vaultKeep = _repo.Create(vaultKeepData);


    return vaultKeep;

  }

  internal string Delete(int id, string userId)
  {
    string message = _repo.Delete(id, userId);
    return "Yep its gone";
  }
}
