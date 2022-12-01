using Microsoft.AspNetCore.Mvc;
using MondialBeispielWebApi.BL;
using Shared;

namespace MondialBeispielWebApi.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class ContinentsController : ControllerBase
  {
    private readonly World world;

    public ContinentsController(World world)
    {
      this.world = world;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Continent>> Get()
    {
      return Ok(world.GetContinents());
    }
  }
}
