using System.ComponentModel.DataAnnotations;
using SwiftSteamGameApi.Models.Enums;

namespace SwiftSteamGameApi.Models;

/// <summary>
/// Identity and catalog metadata for a game.
/// </summary>
public class GameDetails
{
    [Required]
    [MaxLength(300)]
    public required string Title { get; set; }

    [MaxLength(200)]
    public string? Developer { get; set; }

    [MaxLength(200)]
    public string? Publisher { get; set; }

    [Range(1970, 2100)]
    public int? YearOfRelease { get; set; }

    public List<string> Genres { get; set; } = [];

    public GamePlatform Platform { get; set; } = GamePlatform.Steam;

    [MaxLength(8000)]
    public string? Description { get; set; }

    /// <summary>
    /// Optional external identifier (e.g. Steam App ID) for future store integrations.
    /// </summary>
    [MaxLength(100)]
    public string? ExternalId { get; set; }
}
