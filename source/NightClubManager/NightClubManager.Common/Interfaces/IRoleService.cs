using NightClubManager.Common.Dtos.Role;

namespace NightClubManager.Common.Interfaces;

public interface IRoleService
{
    Task<int> CreateRoleAsync(RoleCreate roleCreate);
    Task UpdateRoleAsync(RoleUpdate roleUpdate);
    Task<List<RoleGet>> GetRolesAsync();
    Task<RoleGet> GetRoleAsync(int id);
    Task DeleteRoleAsync(RoleDelete roleDelete);
}
