using FinishedGamesAPI.Models;

namespace FinishedGamesAPI.Repositories.Abstractions;

public interface IFinishedGamesRepository
{
    Task<Game> CreateAsync(Game game, CancellationToken cancellationToken = default);

    Task<Game> UpdateAsync(Guid id, Game game, CancellationToken cancelattionToken = default);

    Task<Game> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    Task<List<Game>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Game> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
}