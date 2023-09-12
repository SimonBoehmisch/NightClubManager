
using NightClubManager.Common.Dtos.EmployeeAssignment;
using NightClubManager.Common.Dtos.Role;

namespace NightClubManager.Common.Dtos.Employee;

public record EmployeeGet(int Id, string FirstName, string LastName, List<EmployeeAssignmentList> EmployeeAssignments, List<RoleList> Roles);
