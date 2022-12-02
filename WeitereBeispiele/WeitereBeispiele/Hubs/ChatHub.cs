using Microsoft.AspNetCore.SignalR;

namespace WeitereBeispiele.Hubs
{
  public class ChatHub : Hub
  {
    public async Task PostMessage(string message)
    {
      string m = $"{DateTime.Now.ToLongTimeString()}: {message}";
      await this.Clients.All.SendAsync("ShowMessage", m);
    }
  }
}
