
namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultsController : ControllerBase
{
  private readonly Auth0Provider _auth;
  private readonly VaultsService _vaultsService;
  public VaultsController(Auth0Provider auth, VaultsService vaultsService)
  {
    _auth = auth;
    _vaultsService = vaultsService;
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





}
