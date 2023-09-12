using NightClubManager.Common.Dtos.Role;

namespace NightClubManager.Common.Dtos.Employee;

public record EmployeeCreate(string FirstName, string LastName, List<int> Roles);