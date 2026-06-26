using SwiftSteamGameApi.Models;

namespace SwiftSteamGameApi.Services;

public interface IGameRecordService
{
    Task<IReadOnlyList<GameRecord>> GetGameRecordListAsync(CancellationToken cancellationToken = default);

    Task<GameRecord?> GetGameRecordAsync(Guid id, CancellationToken cancellationToken = default);

    Task<GameRecord> CreateGameRecordAsync(GameRecord gameRecord, CancellationToken cancellationToken = default);
}
