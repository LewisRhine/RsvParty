using System.ComponentModel.DataAnnotations;

namespace RsvParty.Models;

public class RsvpBody
{
    [Required] public required string Name { get; init; }
    [Required] public required int NumberInParty { get; init; }
    public string? MoveGuess { get; init; } = string.Empty;
    public string? Email { get; init; } = string.Empty;
    public bool? GetUpdates { get; init; } = false;
    public bool? GetReminder { get; init; } = false;
}

public class Rsvp : RsvpBody
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public DateTime MadeAt { get; init; } = DateTime.UtcNow;
}