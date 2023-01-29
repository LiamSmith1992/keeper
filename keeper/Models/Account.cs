namespace keeper.Models;

public class Account
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Picture { get; set; }
  public string CoverImg { get; set; }
}

public class Keeper : Account
{
  // public string CreatorId { get; set; }
  public int KeeperId { get; set; }
  // public int VaultId { get; set; }
  // public int KeepId { get; set; }
}
