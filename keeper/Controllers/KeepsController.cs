

namespace keeper.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KeepsController : ControllerBase
{
  private readonly Auth0Provider _auth;
  private readonly KeepsService _keepsService;

  public KeepsController(Auth0Provider auth, KeepsService keepsService)
  {
    _auth = auth;
    _keepsService = keepsService;
  }

  [HttpPost]
  [Authorize]
  public async Task<ActionResult<Keep>> Create([FromBody] Keep keepData)
  {
    try
    {
      Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
      keepData.CreatorId = userInfo.Id;
      keepData.Creator = userInfo;
      Keep keep = _keepsService.Create(keepData);
      return Ok(keep);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
      throw;
    }
  }

  [HttpGet]
  public ActionResult<List<Keep>> Get()
  {
    try
    {
      List<Keep> keeps = _keepsService.Get();
      return Ok(keeps);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);

    }
  }

  [HttpGet("{id}")]
  public ActionResult<Keep> GetOne(int id)
  {
    try
    {
      Keep keep = _keepsService.GetOne(id);
      return Ok(keep);
    }
    catch (Exception e)
    {

      return BadRequest(e.Message);
    }
  }


  [HttpPut("{id}")]
  [Authorize]
  public ActionResult<Keep> Update([FromBody] Keep keepData, int id)
  {
    try
    {
      Keep keep = _keepsService.Update(keepData, id);
      return Ok(keep);
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
      String message = _keepsService.Delete(id, userInfo.Id);
      return Ok(message);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
      throw;
    }
  }


}
