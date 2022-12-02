using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WeitereBeispiele.Hubs;

namespace WeitereBeispiele.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class BeispielController : ControllerBase
  {
    private readonly IHubContext<ChatHub> hubContext;

    public BeispielController(IHubContext<ChatHub> hubContext)
    {
      this.hubContext = hubContext;
    }

    [HttpPost("chatmessage")]
    public async Task SendMessage(string message)
    {
      await hubContext.Clients.All.SendAsync("ShowMessage", message);
    }


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

    [HttpGet("fehler")]
    public void Fehler()
    {
      throw new ApplicationException("Hoppla - ein Fehler...");
    }
  }
}
