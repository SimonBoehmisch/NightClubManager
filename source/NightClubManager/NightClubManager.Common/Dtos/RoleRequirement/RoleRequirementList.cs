using NightClubManager.Common.Dtos.Event;
using NightClubManager.Common.Dtos.Role;

namespace NightClubManager.Common.Dtos.RoleRequirement;

public record RoleRequirementList(int Id, RoleGet Role, EventGet Event, int RequiredEmployees);
