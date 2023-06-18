using GamesStore.Api.Data;
using GamesStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Api.Repositories;

public class EntityFrameworkGamesRepository : IGamesRepository
{
    private readonly GamesStoreContext dbContext;

    public EntityFrameworkGamesRepository(GamesStoreContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await dbContext.Games.AsNoTracking().ToListAsync();
    }
    public async Task<Game?> GetAsync(int id)
    {
        return await dbContext.Games.FindAsync(id);
    }
    public async Task CreateAsync(Game game)
    {
        dbContext.Games.Add(game);
        await dbContext.SaveChangesAsync();
    }
    public async Task UpdateAsync(Game updatedGame)
    {
        dbContext.Games.Update(updatedGame);
        await dbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        await dbContext.Games.Where(game => game.Id == id).ExecuteDeleteAsync();
    }
}