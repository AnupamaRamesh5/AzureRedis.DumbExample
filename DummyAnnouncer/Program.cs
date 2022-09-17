using DummyAnnouncer;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRedis(builder.Configuration.GetConnectionString("ACR"));

builder.Services.AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
