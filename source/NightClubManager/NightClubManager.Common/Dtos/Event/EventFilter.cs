namespace NightClubManager.Common.Dtos.Event;

public record EventFilter(string? Title, DateTime? Start, DateTime? End, int? Skip, int? Take);