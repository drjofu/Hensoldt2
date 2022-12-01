
// static async Task<int>Main(string[]params)

using WebApiBasics.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Personenliste>();

var app = builder.Build();

// Pipeline aufbauen

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", (string name) => $"Hallo {name}");
app.Run();
