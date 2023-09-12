using NightClubManager.Common.Dtos.Employee;

namespace NightClubManager.Common.Interfaces;

public interface IEmployeeService
{
    Task<int> CreateEmployeeAsync(EmployeeCreate employeeAssignmentCreate);
    Task UpdateEmployeeAsync(EmployeeUpdate employeeAssignmentUpdate);
    Task<List<EmployeeList>> GetEmployeesAsnyc(EmployeeFilter employeeAssignmentFilter);
    Task<EmployeeDetails> GetEmployeeAsync(int id);
    Task DeleteEmployeeAsync(EmployeeDelete employeeAssignmentDelete);
}
