namespace NightClubManager.Common.Dtos.Employee;

public record EmployeeFilter(string? FirstName, string? LastName, int? RoleId, int? Skip, int? Take);