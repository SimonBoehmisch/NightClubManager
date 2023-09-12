using Microsoft.AspNetCore.Mvc;
using NightClubManager.Common.Dtos.RoleRequirement;
using NightClubManager.Common.Interfaces;

namespace NightClubManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RoleRequirementController : ControllerBase
{
    private IRoleRequirementService RoleRequirementService { get; }

    public RoleRequirementController(IRoleRequirementService roleRequirementService)
    {
        RoleRequirementService = roleRequirementService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateRoleRequirement(RoleRequirementCreate roleRequirementCreate)
    {
        var id = await RoleRequirementService.CreateRoleRequirementsAsync(roleRequirementCreate);
        return Ok(id);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateRoleRequirement(RoleRequirementUpdate roleRequirementUpdate)
    {
        await RoleRequirementService.UpdateRoleRequirementAsync(roleRequirementUpdate);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteRoleRequirement(RoleRequirementDelete roleRequirementDelete)
    {
        await RoleRequirementService.DeleteRoleRequirementAsync(roleRequirementDelete);
        return Ok();
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetRoleRequirement(int id)
    {
        var roleRequirement = await RoleRequirementService.GetRoleRequirementAsync(id);
        return Ok(roleRequirement);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetRoleRequirements([FromQuery] RoleRequirementFilter roleRequirementFilter)
    {
        var roleRequirements = await RoleRequirementService.GetRoleRequirementsAsnyc(roleRequirementFilter);
        return Ok(roleRequirements);
    }

}
