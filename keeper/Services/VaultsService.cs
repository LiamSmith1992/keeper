
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

  internal string Delete(int id, string userId)
  {
    Vault original = GetVaultById(id, userId);
    if (original.CreatorId != userId) throw new Exception("this isn't your vault to delete");
    _repo.Delete(id);
    return "vault was deleted";

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

  internal Vault UpdateVault(Vault vaultData)
  {
    Vault original = GetVaultById(vaultData.Id, vaultData.CreatorId);
    if (original.CreatorId != vaultData.CreatorId) throw new Exception("You don't own this vault");
    original.Name = vaultData.Name ?? original.Name;
    original.Description = vaultData.Description ?? original.Description;
    original.Img = vaultData.Img ?? original.Img;
    original.IsPrivate = vaultData.IsPrivate ?? original.IsPrivate;

    _repo.Update(original);
    return original;
  }
}
