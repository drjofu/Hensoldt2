using Microsoft.AspNetCore.Mvc;

namespace WebApiBasics.Controllers
{
  [Route("[controller]")]
  public class BeispielController
  {
    [HttpGet]
    public string Get()
    {
      return "Hallo Welt!";
    }

    [HttpGet("Plus")]
    public int Plus(int a, int b)
    {
      return a + b;
    }
  }
}
