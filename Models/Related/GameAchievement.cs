using System.ComponentModel.DataAnnotations;

namespace SwiftSteamGameApi.Models.Related;

/// <summary>
/// Placeholder for future achievement tracking linked to a game record.
/// </summary>
public class GameAchievement
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(300)]
    public required string Name { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    public bool IsUnlocked { get; set; }

    public DateTimeOffset? UnlockedAt { get; set; }

    [MaxLength(100)]
    public string? ExternalId { get; set; }
}
