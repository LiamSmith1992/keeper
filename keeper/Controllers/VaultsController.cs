
namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly Auth0Provider _auth;
  private readonly VaultsService _vaultsService;

  private readonly KeepsService _keepsService;
  public VaultsController(Auth0Provider auth, VaultsService vaultsService, KeepsService keepsService)
  {
    _auth = auth;
    _vaultsService = vaultsService;
    _keepsService = keepsService;
  }


  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Vault>> Create([FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      vaultData.CreatorId = userInfo.Id;
      Vault vault = _vaultsService.Create(vaultData);
      vault.Creator = userInfo;
      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }

  [HttpGet("{id}")]
  public async Task<ActionResult<Vault>> GetVaultById(int id)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      Vault vault = _vaultsService.GetVaultById(id, userInfo?.Id);
      return Ok(vault);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }

  [HttpPut("{id}")]
  [Authorize]
  public async Task<ActionResult<Vault>> UpdateVault(int id, [FromBody] Vault vaultData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      vaultData.CreatorId = userInfo.Id;
      vaultData.Id = id;
      Vault vault = _vaultsService.UpdateVault(vaultData);
      return Ok(vault);

    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> Delete(int id)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      string message = _vaultsService.Delete(id, userInfo.Id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }

  [HttpGet("{id}/keeps")]
  public ActionResult<List<Keep>> GetVaultKeeps(int id)
  {
    try
    {
      List<Keep> keeps = _keepsService.GetVaultKeeps(id);
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }

}
