using NightClubManager.Common.Dtos.Event;
using NightClubManager.Common.Dtos.Role;

namespace NightClubManager.Common.Dtos.RoleRequirement;

public record RoleRequirementGet(int Id, RoleGet Role, EventGet Event);