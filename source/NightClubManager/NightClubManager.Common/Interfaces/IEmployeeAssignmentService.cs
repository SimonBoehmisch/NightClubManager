using NightClubManager.Common.Dtos.Employee;
using NightClubManager.Common.Dtos.EmployeeAssignment;

namespace NightClubManager.Common.Interfaces;

public interface IEmployeeAssignmentService
{
    Task<int> CreateEmployeeAssignmentAsync(EmployeeAssignmentCreate employeeAssignmentAssignmentCreate);
    Task UpdateEmployeeAssignmentAsync(EmployeeAssignmentUpdate employeeAssignmentAssignmentUpdate);
    Task<List<EmployeeAssignmentList>> GetEmployeeAssignmentsAsnyc(EmployeeAssignmentFilter employeeAssignmentFilter);
    Task<List<EmployeeAssignmentGet>> GetEmployeeAssignmentsAsync();
    Task<EmployeeAssignmentGet> GetEmployeeAssignmentAsync(int id);
    Task DeleteEmployeeAssignmentAsync(EmployeeAssignmentDelete employeeAssignmentAssignmentDelete);
}
