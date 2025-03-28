using FinishedGamesAPI.Data;
using FinishedGamesAPI.Models;
using FinishedGamesAPI.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace FinishedGamesAPI.Repositories;

public class FinishedGamesRepository(AppDbContext context) : IFinishedGamesRepository
{
    public async Task<Game> CreateAsync(Game game, CancellationToken cancellationToken = default)
    {
        await context.Games.AddAsync(game, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return game;
    }

    public async Task<Game> UpdateAsync(Guid id, Game game, CancellationToken cancelattionToken = default)
    {
        var currentGame = await context.Games.FirstOrDefaultAsync(x => x.Id == id, cancelattionToken);

        if (currentGame is null)
            return null;

        currentGame.Title = game.Title;
        currentGame.Description = game.Description;
        currentGame.Platform = game.Platform;
        currentGame.Genre = game.Genre;
        currentGame.Grade = game.Grade;

        context.Update(currentGame);
        await context.SaveChangesAsync(cancelattionToken);

        return game;
    }

    public async Task<Game> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var currentGame = await context.Games.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (currentGame is null)
            return null;

        context.Games.Remove(currentGame);
        await context.SaveChangesAsync(cancellationToken);

        return currentGame;
    }

    public Task<Game> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        context.Games.FirstOrDefaultAsync(x => x.Id == id, cancellationToken)!;

    public async Task<List<Game>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await context.Games.ToListAsync(cancellationToken);
}