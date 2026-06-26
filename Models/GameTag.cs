using System.ComponentModel.DataAnnotations;

namespace SwiftSteamGameApi.Models;

/// <summary>
/// Table-backed organization tag linked to a game record.
/// </summary>
public class GameTag
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid GameRecordId { get; set; }

    public GameRecord? GameRecord { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
}
