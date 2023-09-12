using NightClubManager.Common.Dtos.RoleRequirement;
using NightClubManager.Common.Dtos.RoleRequirement;

namespace NightClubManager.Common.Interfaces;

public interface IRoleRequirementService
{
    Task<int> CreateRoleRequirementsAsync(RoleRequirementCreate roleRequirementCreate);
    Task UpdateRoleRequirementAsync(RoleRequirementUpdate roleRequirementUpdate);
    Task<List<RoleRequirementList>> GetRoleRequirementsAsnyc(RoleRequirementFilter roleRequirementFilter);
    Task<RoleRequirementDetails> GetRoleRequirementAsync(int id);
    Task DeleteRoleRequirementAsync(RoleRequirementDelete roleRequirementDelete);
}
