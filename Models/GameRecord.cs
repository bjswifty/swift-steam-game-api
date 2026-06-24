using System.ComponentModel.DataAnnotations;
using SwiftSteamGameApi.Models.Enums;
using SwiftSteamGameApi.Models.Related;

namespace SwiftSteamGameApi.Models;

/// <summary>
/// Root aggregate for a personal Steam/library game entry.
/// Composed of focused sub-models so validation, persistence, and API contracts can evolve independently.
/// </summary>
public class GameRecord
{
    public Guid Id { get; set; }

    [Required]
    public GameDetails Details { get; set; } = new() { Title = string.Empty };

    public PersonalTracking Tracking { get; set; } = new();

    /// <summary>
    /// Primary review for this entry. Replace or supplement with a collection when supporting multiple reviews.
    /// </summary>
    public GameReview? Review { get; set; }

    public List<string> Tags { get; set; } = [];

    public GameStatus Status { get; set; } = GameStatus.NotStarted;

    public PriorityLevel Priority { get; set; } = PriorityLevel.None;

    public DateTimeOffset CreatedAt { get; set; }

    public DateTimeOffset UpdatedAt { get; set; }

    // Future relationship collections — optional until populated by services or persistence layer.
    public List<GameScreenshot>? Screenshots { get; set; }

    public List<GameAchievement>? Achievements { get; set; }

    public List<GameCategory>? Categories { get; set; }
}
