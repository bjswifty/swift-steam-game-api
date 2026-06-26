using System.ComponentModel.DataAnnotations;
using SwiftSteamGameApi.Models;

namespace SwiftSteamGameApi.Models.Related;

/// <summary>
/// Placeholder for future achievement tracking linked to a game record.
/// </summary>
public class GameAchievement
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid GameRecordId { get; set; }

    public GameRecord? GameRecord { get; set; }

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
