using System.ComponentModel.DataAnnotations;

namespace SwiftSteamGameApi.Models;

/// <summary>
/// Personal ownership and play-progress fields.
/// </summary>
public class PersonalTracking
{
    public bool IsOwned { get; set; }

    public bool HasPlayed { get; set; }

    public bool IsCompleted { get; set; }

    public bool IsInBacklog { get; set; }

    public bool WantsReplay { get; set; }

    public DateOnly? DateStarted { get; set; }

    public DateOnly? DateCompleted { get; set; }

    [Range(0, 100_000)]
    public decimal HoursPlayed { get; set; }
}
