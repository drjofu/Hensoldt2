using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WeitereBeispiele;
using WeitereBeispiele.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<MyHostedService>();
builder.Services.AddSingleton<MyService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
  .AddJwtBearer(options =>
  {
    options.TokenValidationParameters = new TokenValidationParameters
    {
      ValidateIssuer = true,
      ValidateAudience = true,
      ValidateLifetime = true,
      ValidateIssuerSigningKey = true,
      ValidIssuer = builder.Configuration["Jwt:Issuer"],
      ValidAudience = builder.Configuration["Jwt:Audience"],
      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
  });

builder.Services.AddAuthorization(config =>
{
  config.AddPolicy("geldspeicherRW", p => p.RequireClaim("geldspeicher", "rw"));
  config.AddPolicy("geldspeicherR", p => p.RequireClaim("geldspeicher", "r", "rw"));
});

builder.Services.AddSignalR();
builder.Services.AddCors(b => b.AddPolicy("CORSPolicy", p =>
  p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

if (app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/error-development");
}
else
{
  app.UseExceptionHandler("/error");
}

app.UseCors("CORSPolicy");

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chat");

app.Run();
