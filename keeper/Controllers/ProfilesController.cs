

namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProfilesController : ControllerBase
{
  private readonly Auth0Provider _auth;
  private readonly ProfilesService _profilesService;

  public ProfilesController(Auth0Provider auth, ProfilesService profilesService)
  {
    _auth = auth;
    _profilesService = profilesService;
  }




  [HttpGet("{id}")]
  public ActionResult<Account> GetOne(string id)
  {
    try
    {
      Account profile = _profilesService.GetOne(id);
      return Ok(profile);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }

  [HttpGet("{id}/keeps")]
  public ActionResult<List<Keep>> GetProfileKeeps(string id)
  {
    try
    {
      List<Keep> keeps = _profilesService.GetProfileKeeps(id);
      return keeps;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }


  [HttpGet("{id}/vaults")]
  public ActionResult<List<Vault>> GetProfileVaults(string id)
  {
    try
    {
      List<Vault> vaults = _profilesService.GetProfileVaults(id);
      return vaults;
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }

}
