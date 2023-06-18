using System.Reflection;
using GamesStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Api.Data;

public class GamesStoreContext : DbContext
{
    public GamesStoreContext(DbContextOptions<GamesStoreContext> options) : base(options)
    {

    }
    public DbSet<Game> Games => Set<Game>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}