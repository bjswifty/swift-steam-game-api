using System.ComponentModel.DataAnnotations;
using SwiftSteamGameApi.Models;

namespace SwiftSteamGameApi.Models.Related;

/// <summary>
/// Placeholder for future screenshot attachments linked to a game record.
/// </summary>
public class GameScreenshot
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid GameRecordId { get; set; }

    public GameRecord? GameRecord { get; set; }

    [Required]
    [MaxLength(2000)]
    public required string Url { get; set; }

    [MaxLength(500)]
    public string? Caption { get; set; }

    public DateTimeOffset? CapturedAt { get; set; }
}
