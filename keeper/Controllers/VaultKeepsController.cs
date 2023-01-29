
namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VaultKeepsController : ControllerBase
{

  private readonly Auth0Provider _auth;
  private readonly VaultKeepsService _vaultKeepsService;

  public VaultKeepsController(Auth0Provider auth, VaultKeepsService vaultKeepsService)
  {
    _auth = auth;
    _vaultKeepsService = vaultKeepsService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Keeper>> Create([FromBody] VaultKeep vaultKeepData)
  {
    try
    {
      Keeper userInfo = await _auth.GetUserInfoAsync<Keeper>(HttpContext);
      vaultKeepData.CreatorId = userInfo.Id;
      VaultKeep vaultKeep = _vaultKeepsService.Create(vaultKeepData);
      // userInfo.KeeperId = id;
      //   userInfo.CreatorId = vaultKeepData.CreatorId;
      //   userInfo.VaultId = vaultKeepData.VaultId;
      //   userInfo.KeepId = vaultKeepData.KeepId;

      return Ok(vaultKeep);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }

  [HttpDelete("{id}")]
  [Authorize]
  public async Task<ActionResult<string>> DELETE(int id)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      string message = _vaultKeepsService.Delete(id, userInfo.Id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }





}
