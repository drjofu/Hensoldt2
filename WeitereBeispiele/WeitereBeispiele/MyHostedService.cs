namespace WeitereBeispiele
{
  public class MyHostedService : BackgroundService  //IHostedService
  {
    private readonly MyService myService;

    public MyHostedService(MyService myService)
    {
      this.myService = myService;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
      myService.Start(stoppingToken);
      return Task.CompletedTask;
    }
  }
}
