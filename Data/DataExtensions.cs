using GamesStore.Api.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Api.Data;

public static class DataExtensions
{
    public static async Task InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<GamesStoreContext>();
        await dbContext.Database.MigrateAsync();
    }
    public static IServiceCollection AddRepositories(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("GameStoreContext");
        services.AddSqlServer<GamesStoreContext>(connString)
                .AddScoped<IGamesRepository, EntityFrameworkGamesRepository>();
        return services;
    }
}