using NightClubManager.Common.Dtos.EmployeeAssignment;
using NightClubManager.Common.Dtos.Event;
using NightClubManager.Common.Dtos.Role;

namespace NightClubManager.Common.Dtos.RoleRequirement;

public record RoleRequirementDetails(int Id, RoleGet Role, EventGet Event, int RequiredEmployees);