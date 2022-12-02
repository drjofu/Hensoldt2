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
    private readonly ILogger<CountriesController> logger;

    public CountriesController(World world, ILogger<CountriesController> logger)
    {
      this.world = world;
      this.logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Country>> Get(string continentId)
    {
      logger.LogInformation("Es wurde nach den Länder für die Kontinent-Id {continentId} gefragt", continentId);

      var countries = world.GetCountriesOnContinent(continentId);
      if (countries.Count() > 0)
        return Ok(countries);

      logger.LogError("Kontinent mit Id {continentId} gibt es nicht", continentId);
      return BadRequest($"Kontinent mit Id {continentId} gibt es nicht.");
    }
  }
}
