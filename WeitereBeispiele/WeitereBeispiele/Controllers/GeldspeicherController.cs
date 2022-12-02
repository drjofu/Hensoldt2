using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TokenProvider.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  //[Authorize]
  public class GeldspeicherController : ControllerBase
  {
    // nur zur Demo
    private static double inhalt = 99999999;

    [HttpGet()]
    [Authorize(Policy = "geldspeicherR")]
    public ActionResult<double> Get()
    {
      return Ok(inhalt);
    }

    [Authorize(Policy ="geldspeicherRW")]
    [HttpPost]
    public ActionResult<double> Post(double transfer)
    {
      inhalt += transfer;
      return Ok(inhalt);
    }
  }
}
