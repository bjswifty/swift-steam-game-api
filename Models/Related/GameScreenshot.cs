using System.ComponentModel.DataAnnotations;

namespace SwiftSteamGameApi.Models.Related;

/// <summary>
/// Placeholder for future screenshot attachments linked to a game record.
/// </summary>
public class GameScreenshot
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(2000)]
    public required string Url { get; set; }

    [MaxLength(500)]
    public string? Caption { get; set; }

    public DateTimeOffset? CapturedAt { get; set; }
}
