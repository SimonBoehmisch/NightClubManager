using Microsoft.AspNetCore.Mvc;
using NightClubManager.Common.Dtos.Employee;
using NightClubManager.Common.Interfaces;

namespace NightClubManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private IEmployeeService EmployeeService { get; }

    public EmployeeController(IEmployeeService employeeAssignmentService)
    {
        EmployeeService = employeeAssignmentService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateEmployee(EmployeeCreate employeeAssignmentCreate)
    {
        var id = await EmployeeService.CreateEmployeeAsync(employeeAssignmentCreate);
        return Ok(id);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateEmployee(EmployeeUpdate employeeAssignmentUpdate)
    {
        await EmployeeService.UpdateEmployeeAsync(employeeAssignmentUpdate);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteEmployee(EmployeeDelete employeeAssignmentDelete)
    {
        await EmployeeService.DeleteEmployeeAsync(employeeAssignmentDelete);
        return Ok();
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var employeeAssignment = await EmployeeService.GetEmployeeAsync(id);
        return Ok(employeeAssignment);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetEmployees([FromQuery] EmployeeFilter employeeAssignmentFilter)
    {
        var employeeAssignments = await EmployeeService.GetEmployeesAsnyc(employeeAssignmentFilter);
        return Ok(employeeAssignments);
    }

}