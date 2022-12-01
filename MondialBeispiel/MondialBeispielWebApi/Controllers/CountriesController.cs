using Microsoft.AspNetCore.Mvc;
using MondialBeispielWebApi.BL;
using Shared;

namespace MondialBeispielWebApi.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class CountriesController : ControllerBase
  {
    private readonly World world;

    public CountriesController(World world)
    {
      this.world = world;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Country>> Get(string continentId)
    {
      var countries = world.GetCountriesOnContinent(continentId);
      if (countries.Count() > 0)
        return Ok(countries);
      return BadRequest($"Kontinent mit Id {continentId} gibt es nicht.");
    }
  }
}
