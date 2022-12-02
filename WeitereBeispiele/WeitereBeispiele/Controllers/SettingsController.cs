using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeitereBeispiele.Controllers
{
  [Route("[controller]")]
  [ApiController]
  public class SettingsController : ControllerBase
  {
    private readonly IConfiguration configuration;

    public SettingsController(IConfiguration configuration)
    {
      this.configuration = configuration;
    }

    [HttpGet]
    public string GetConfig()
    {
      var pfad = configuration["pfad"];
      int anzahl = configuration.GetValue<int>("anzahl");
      string passwort = configuration.GetValue<string>("passwort");

      return $"pfad: {pfad}, Anzahl: {anzahl}, Pw: {passwort}";
    }
  }
}
