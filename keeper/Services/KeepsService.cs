
namespace keeper.Services;

public class KeepsService
{
  private readonly KeepsRepository _repo;
  private readonly VaultsRepository _vaultsRepository;

  public KeepsService(KeepsRepository repo, VaultsRepository vaultsRepository)
  {
    _repo = repo;
    _vaultsRepository = vaultsRepository;
  }

  internal Keep Create(Keep keepData)
  {
    Keep keep = _repo.Create(keepData);
    return keep;
  }

  internal string Delete(int keepId, string userId)
  {
    Keep original = GetOne(keepId);
    if (original.CreatorId != userId)
    {
      throw new Exception("you can delete that. ok!?");
    }
    _repo.Delete(keepId);
    return $"{original.Name} has been deleted";
  }

  internal List<Keep> Get()
  {
    List<Keep> keeps = _repo.Get();
    return keeps;
  }

  internal Keep GetOne(int id)
  {
    Keep keep = _repo.GetOne(id);
    if (keep == null)
    {
      throw new Exception("no keep with that id");
    }

    return keep;
  }

  internal List<Keeper> GetVaultKeeps(int vaultId, string userId)
  {
    Vault vault = _vaultsRepository.GetOne(vaultId);
    if (vault.IsPrivate != false && vault.CreatorId != userId)
    {
      throw new Exception("Private Vault please leave");
    }
    List<Keeper> keeps = _repo.GetVaultKeeps(vaultId);

    return keeps;
  }

  internal Keep Update(Keep keepData, int id, string userId)
  {
    Keep original = GetOne(id);
    if (original.CreatorId != userId)
    {
      throw new Exception("not your keep");
    }
    original.Name = keepData.Name ?? original.Name;
    original.Description = keepData.Description ?? original.Description;
    original.Img = keepData.Img ?? original.Img;
    bool edited = _repo.Update(original);

    if (edited == false)
    {
      throw new Exception("was not updated");
    }
    return original;
  }





}
