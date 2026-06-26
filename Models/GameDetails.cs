using System.ComponentModel.DataAnnotations;
using SwiftSteamGameApi.Models.Enums;

namespace SwiftSteamGameApi.Models;

/// <summary>
/// Identity and catalog metadata for a game.
/// </summary>
public class GameDetails
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid GameRecordId { get; set; }

    public GameRecord? GameRecord { get; set; }

    [Required]
    [MaxLength(300)]
    public required string Title { get; set; }

    [MaxLength(200)]
    public string? Developer { get; set; }

    [MaxLength(200)]
    public string? Publisher { get; set; }

    [Range(1970, 2100)]
    public int? YearOfRelease { get; set; }

    public List<GameGenre> Genres { get; set; } = [];

    public GamePlatform Platform { get; set; } = GamePlatform.Steam;

    [MaxLength(8000)]
    public string? Description { get; set; }

    /// <summary>
    /// Optional external identifier (e.g. Steam App ID) for future store integrations.
    /// </summary>
    [MaxLength(100)]
    public string? ExternalId { get; set; }
}
