namespace NightClubManager.Common.Dtos.Employee;

public record EmployeeUpdate(int Id, string FirstName, string LastName, List<int> Roles);