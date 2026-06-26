using Microsoft.EntityFrameworkCore;
using SwiftSteamGameApi.Data;
using SwiftSteamGameApi.Models;
using SwiftSteamGameApi.Models.Related;

namespace SwiftSteamGameApi.Services;

public class GameRecordService : IGameRecordService
{
    private readonly GameLibraryDbContext _dbContext;

    public GameRecordService(GameLibraryDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<GameRecord>> GetGameRecordListAsync(CancellationToken cancellationToken = default)
    {
        return await QueryGameRecords()
            .OrderBy(gameRecord => gameRecord.Details.Title)
            .ToListAsync(cancellationToken);
    }

    public async Task<GameRecord?> GetGameRecordAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await QueryGameRecords()
            .FirstOrDefaultAsync(gameRecord => gameRecord.Id == id, cancellationToken);
    }

    public async Task<GameRecord> CreateGameRecordAsync(GameRecord gameRecord, CancellationToken cancellationToken = default)
    {
        var now = DateTimeOffset.UtcNow;

        if (gameRecord.Id == Guid.Empty)
        {
            gameRecord.Id = Guid.NewGuid();
        }

        gameRecord.CreatedAt = now;
        gameRecord.UpdatedAt = now;

        PrepareGameRecordForInsert(gameRecord);

        _dbContext.GameRecords.Add(gameRecord);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return (await GetGameRecordAsync(gameRecord.Id, cancellationToken))!;
    }

    private static void PrepareGameRecordForInsert(GameRecord gameRecord)
    {
        gameRecord.Details ??= new GameDetails { Title = string.Empty };
        gameRecord.Details.Id = gameRecord.Details.Id == Guid.Empty ? Guid.NewGuid() : gameRecord.Details.Id;
        gameRecord.Details.GameRecordId = gameRecord.Id;
        gameRecord.Details.GameRecord = null;
        gameRecord.Details.Genres ??= [];

        foreach (var genre in gameRecord.Details.Genres)
        {
            genre.Id = genre.Id == Guid.Empty ? Guid.NewGuid() : genre.Id;
            genre.GameRecordId = gameRecord.Id;
            genre.GameDetailsId = gameRecord.Details.Id;
            genre.GameRecord = null;
            genre.GameDetails = null;
        }

        gameRecord.Tracking ??= new PersonalTracking();
        gameRecord.Tracking.Id = gameRecord.Tracking.Id == Guid.Empty ? Guid.NewGuid() : gameRecord.Tracking.Id;
        gameRecord.Tracking.GameRecordId = gameRecord.Id;
        gameRecord.Tracking.GameRecord = null;

        if (gameRecord.Review is not null)
        {
            gameRecord.Review.Id = gameRecord.Review.Id == Guid.Empty ? Guid.NewGuid() : gameRecord.Review.Id;
            gameRecord.Review.GameRecordId = gameRecord.Id;
            gameRecord.Review.GameRecord = null;
            gameRecord.Review.ReviewedAt ??= DateTimeOffset.UtcNow;
        }

        gameRecord.Tags ??= [];
        foreach (var tag in gameRecord.Tags)
        {
            tag.Id = tag.Id == Guid.Empty ? Guid.NewGuid() : tag.Id;
            tag.GameRecordId = gameRecord.Id;
            tag.GameRecord = null;
        }

        gameRecord.Screenshots ??= [];
        foreach (var screenshot in gameRecord.Screenshots)
        {
            screenshot.Id = screenshot.Id == Guid.Empty ? Guid.NewGuid() : screenshot.Id;
            screenshot.GameRecordId = gameRecord.Id;
            screenshot.GameRecord = null;
        }

        gameRecord.Achievements ??= [];
        foreach (var achievement in gameRecord.Achievements)
        {
            achievement.Id = achievement.Id == Guid.Empty ? Guid.NewGuid() : achievement.Id;
            achievement.GameRecordId = gameRecord.Id;
            achievement.GameRecord = null;
        }

        gameRecord.Categories ??= [];
        foreach (var category in gameRecord.Categories)
        {
            category.Id = category.Id == Guid.Empty ? Guid.NewGuid() : category.Id;
            category.GameRecordId = gameRecord.Id;
            category.GameRecord = null;
        }
    }

    private IQueryable<GameRecord> QueryGameRecords()
    {
        return _dbContext.GameRecords
            .AsNoTracking()
            .Include(gameRecord => gameRecord.Details)
                .ThenInclude(details => details.Genres)
            .Include(gameRecord => gameRecord.Tracking)
            .Include(gameRecord => gameRecord.Review)
            .Include(gameRecord => gameRecord.Tags)
            .Include(gameRecord => gameRecord.Screenshots)
            .Include(gameRecord => gameRecord.Achievements)
            .Include(gameRecord => gameRecord.Categories);
    }
}
