using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeitereBeispiele.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BeispielController : ControllerBase
  {
    [HttpGet]
    public async Task<ActionResult<string>> Get()
    {
      await Task.Delay(2000);
      return "Hallo Welt";
    }

    [HttpGet("soNicht")]
    public async void SoBitteNicht()
    {
      await Task.Delay(2000);
      // ...
    }

    //public string Get2()
    //{
    //  Task.Delay(2000).Wait();
    //  return "...";
    //}
  }
}
