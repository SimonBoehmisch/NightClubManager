using Microsoft.AspNetCore.Mvc;
using NightClubManager.Common.Dtos.EmployeeAssignment;
using NightClubManager.Common.Dtos.Event;
using NightClubManager.Common.Interfaces;

namespace NightClubManager.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class EmployeeAssignmentAssignmentController : ControllerBase
{
    private IEmployeeAssignmentService EmployeeAssignmentService { get; }

    public EmployeeAssignmentAssignmentController(IEmployeeAssignmentService employeeAssignmentAssignmentService)
    {
        EmployeeAssignmentService = employeeAssignmentAssignmentService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateEmployeeAssignment(EmployeeAssignmentCreate employeeAssignmentAssignmentCreate)
    {
        var id = await EmployeeAssignmentService.CreateEmployeeAssignmentAsync(employeeAssignmentAssignmentCreate);
        return Ok(id);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateEmployeeAssignment(EmployeeAssignmentUpdate employeeAssignmentAssignmentUpdate)
    {
        await EmployeeAssignmentService.UpdateEmployeeAssignmentAsync(employeeAssignmentAssignmentUpdate);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteEmployeeAssignment(EmployeeAssignmentDelete employeeAssignmentAssignmentDelete)
    {
        await EmployeeAssignmentService.DeleteEmployeeAssignmentAsync(employeeAssignmentAssignmentDelete);
        return Ok();
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetEmployeeAssignment(int id)
    {
        var employeeAssignmentAssignment = await EmployeeAssignmentService.GetEmployeeAssignmentAsync(id);
        return Ok(employeeAssignmentAssignment);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetEmployeeAssignments([FromQuery] EmployeeAssignmentFilter employeeAssignmentAssignmentFilter)
    {
        var employeeAssignmentAssignments = await EmployeeAssignmentService.GetEmployeeAssignmentsAsnyc(employeeAssignmentAssignmentFilter);
        return Ok(employeeAssignmentAssignments);
    }

}