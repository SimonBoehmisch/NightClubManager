using NightClubManager.Common.Dtos.EmployeeAssignment;
using NightClubManager.Common.Dtos.RoleRequirement;

namespace NightClubManager.Common.Dtos.Event;

public record EventDetails(int Id, string Name, DateTime Start, DateTime End, List<EmployeeAssignmentGet> EmployeeAssignmentsm, List<RoleRequirementGet> RoleRequirements);
