using System.ComponentModel.DataAnnotations;

namespace SwiftSteamGameApi.Models;

/// <summary>
/// Table-backed genre value linked to a game record.
/// </summary>
public class GameGenre
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid GameRecordId { get; set; }

    public GameRecord? GameRecord { get; set; }

    public Guid GameDetailsId { get; set; }

    public GameDetails? GameDetails { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
}
