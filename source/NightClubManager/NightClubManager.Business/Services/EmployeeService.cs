using AutoMapper;
using FluentValidation;
using NightClubManager.Business.Exceptions;
using NightClubManager.Business.Validation;
using NightClubManager.Common.Dtos.Employee;
using NightClubManager.Common.Dtos.Role;
using NightClubManager.Common.Dtos.RoleRequirement;
using NightClubManager.Common.Interfaces;
using NightClubManager.Common.Models;
using System.Linq.Expressions;
using System.Net;

namespace NightClubManager.Business.Services;


public class EmployeeService : IEmployeeService
{
    private IGenericRepository<Employee> EmployeeRepository { get; }
    public IGenericRepository<Role> RoleRepository { get; }
    public IGenericRepository<EmployeeAssignment> EmployeeAssignmentRepository { get; }
    private IMapper Mapper { get; }
    private EmployeeCreateValidator EmployeeCreateValidator { get; }
    private EmployeeUpdateValidator EmployeeUpdateValidator { get; }

    public EmployeeService(IGenericRepository<Employee> employeeRepository, IGenericRepository<Role> roleRepository,
        IGenericRepository<EmployeeAssignment> employeeAssignmentRepository, IMapper mapper, EmployeeCreateValidator employeeCreateValidator, EmployeeUpdateValidator employeeUpdateValidator)
    {
        EmployeeRepository = employeeRepository;
        RoleRepository = roleRepository;
        EmployeeAssignmentRepository = employeeAssignmentRepository;
        Mapper = mapper;
        EmployeeCreateValidator = employeeCreateValidator;
        EmployeeUpdateValidator = employeeUpdateValidator;
    }

    public async Task<int> CreateEmployeeAsync(EmployeeCreate employeeCreate)
    {
        await EmployeeCreateValidator.ValidateAndThrowAsync(employeeCreate);

        Expression<Func<Role, bool>> roleFilter = (role) => employeeCreate.Roles.Contains(role.Id);
        var roles = await RoleRepository.GetFilteredAsync(new[] { roleFilter }, null, null);

        var entity = Mapper.Map<Employee>(employeeCreate);
        entity.Roles = roles;
        await EmployeeRepository.InsertAsync(entity);
        await EmployeeRepository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteEmployeeAsync(EmployeeDelete employeeDelete)
    {
        var entity = await EmployeeRepository.GetByIdAsync(employeeDelete.Id);

        if (entity == null)
            throw new EmployeeNotFoundException(employeeDelete.Id);

        EmployeeRepository.Delete(entity);
        await EmployeeRepository.SaveChangesAsync();

    }

    public async Task<EmployeeDetails> GetEmployeeAsync(int id)
    {
        var entity = await EmployeeRepository.GetByIdAsync(id, (employee) => employee.Roles, (employee) => employee.EmployeeAssignments);

        if (entity == null)
            throw new EmployeeNotFoundException(id);

        return Mapper.Map<EmployeeDetails>(entity);
    }

    public async Task<List<EmployeeList>> GetEmployeesAsnyc(EmployeeFilter employeeFilter)
    {
        Expression<Func<Employee, bool>> firstNameFilter = (employee) => employeeFilter.FirstName == null ? true :
        employee.FirstName.StartsWith(employeeFilter.FirstName);
        Expression<Func<Employee, bool>> lastNameFilter = (employee) => employeeFilter.LastName == null ? true :
        employee.LastName.StartsWith(employeeFilter.LastName);
        Expression<Func<Employee, bool>> roleFilter = (employee) => employeeFilter.RoleId == null ? true :
        employee.Roles.Any(role => role.Id == employeeFilter.RoleId);

        var entities = await EmployeeRepository.GetFilteredAsync(new Expression<Func<Employee, bool>>[]
        {
            firstNameFilter, lastNameFilter, roleFilter
        }, employeeFilter.Skip, employeeFilter.Take,
         (employee) => employee.Roles, (employee) => employee.EmployeeAssignments);

        return Mapper.Map<List<EmployeeList>>(entities);
    }

    public async Task UpdateEmployeeAsync(EmployeeUpdate employeeUpdate)
    {
        await EmployeeUpdateValidator.ValidateAndThrowAsync(employeeUpdate);

        Expression<Func<Role, bool>> roleFilter = (role) => employeeUpdate.Roles.Contains(role.Id);
        var roles = await RoleRepository.GetFilteredAsync(new[] { roleFilter }, null, null);
        
        var entity = await EmployeeRepository.GetByIdAsync(employeeUpdate.Id, (employeeAssignment) => employeeAssignment.Roles);

        if (entity == null)
            throw new EmployeeNotFoundException(employeeUpdate.Id);

        Mapper.Map(employeeUpdate, entity);
        entity.Roles = roles;

        EmployeeRepository.Update(entity);

        await EmployeeRepository.SaveChangesAsync();
    }
}
