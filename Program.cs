using GamesStore.Api.Data;
using GamesStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRepositories(builder.Configuration);

var app = builder.Build();

await app.Services.InitializeDb();

app.MapGamesEndpoints();

app.Run();
