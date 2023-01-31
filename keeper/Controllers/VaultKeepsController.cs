
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
  public async Task<ActionResult<VaultKeep>> Create([FromBody] VaultKeep vaultKeepData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);

      vaultKeepData.CreatorId = userInfo.Id;
      VaultKeep vaultKeep = _vaultKeepsService.Create(vaultKeepData);

      return Ok(vaultKeep);
      // userInfo.KeeperId = id;
      //   userInfo.CreatorId = vaultKeepData.CreatorId;
      //   userInfo.VaultId = vaultKeepData.VaultId;
      //   userInfo.KeepId = vaultKeepData.KeepId;

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
