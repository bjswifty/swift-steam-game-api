using System.ComponentModel.DataAnnotations;

namespace SwiftSteamGameApi.Models.Related;

/// <summary>
/// User-defined category for grouping games beyond genre tags.
/// </summary>
public class GameCategory
{
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; set; }
}
