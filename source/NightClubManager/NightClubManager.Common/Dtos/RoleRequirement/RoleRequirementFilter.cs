namespace NightClubManager.Common.Dtos.RoleRequirement;

public record RoleRequirementFilter(int? RoleId, int? EventId, int? Skip, int? Take);