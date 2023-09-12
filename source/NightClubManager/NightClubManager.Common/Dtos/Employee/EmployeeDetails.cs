using NightClubManager.Common.Dtos.EmployeeAssignment;
using NightClubManager.Common.Dtos.Role;

namespace NightClubManager.Common.Dtos.Employee;

public record EmployeeDetails(int Id, string FirstName, string LastName, List<EmployeeAssignmentGet> EmployeeAssignments, List<RoleGet> Roles);