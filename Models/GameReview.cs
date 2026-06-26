using System.ComponentModel.DataAnnotations;

namespace SwiftSteamGameApi.Models;

/// <summary>
/// Personal review and rating for a game.
/// Designed as a standalone type so a game can later support multiple reviews or versioned write-ups.
/// </summary>
public class GameReview
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid GameRecordId { get; set; }

    public GameRecord? GameRecord { get; set; }

    [Range(1.0, 10.0)]
    public decimal? PersonalRating { get; set; }

    [MaxLength(200)]
    public string? ReviewTitle { get; set; }

    [MaxLength(20_000)]
    public string? ReviewBody { get; set; }

    [MaxLength(4000)]
    public string? Pros { get; set; }

    [MaxLength(4000)]
    public string? Cons { get; set; }

    [MaxLength(2000)]
    public string? FavoriteMoment { get; set; }

    [Range(1, 10)]
    public int? DifficultyRating { get; set; }

    [Range(1, 10)]
    public int? ReplayValue { get; set; }

    public DateTimeOffset? ReviewedAt { get; set; }
}
