using Microsoft.AspNetCore.Mvc;
using NightClubManager.Common.Dtos.Role;
using NightClubManager.Common.Interfaces;

namespace NightClubManager.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class RoleController : ControllerBase
{
    private IRoleService RoleService { get; }

    public RoleController(IRoleService roleService)
    {
        RoleService = roleService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateRole(RoleCreate roleCreate)
    {
        var id = await RoleService.CreateRoleAsync(roleCreate);
        return Ok(id);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateRole(RoleUpdate roleUpdate)
    {
        await RoleService.UpdateRoleAsync(roleUpdate);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteRole(RoleDelete roleDelete)
    {
        await RoleService.DeleteRoleAsync(roleDelete);
        return Ok();
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetRole(int id)
    {
        var role = await RoleService.GetRoleAsync(id);
        return Ok(role);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetRoles()
    {
        var roles = await RoleService.GetRolesAsync();
        return Ok(roles);
    }
}
