using AutoMapper;
using FluentValidation;
using NightClubManager.Business.Exceptions;
using NightClubManager.Business.Validation;
using NightClubManager.Common.Dtos.Employee;
using NightClubManager.Common.Dtos.EmployeeAssignment;
using NightClubManager.Common.Dtos.RoleRequirement;
using NightClubManager.Common.Interfaces;
using NightClubManager.Common.Models;
using System.Linq.Expressions;

namespace NightClubManager.Business.Services;

public class EmployeeAssignmentService : IEmployeeAssignmentService
{
    private IGenericRepository<EmployeeAssignment> EmployeeAssignmentRepository { get; }
    public IGenericRepository<Employee> EmployeeRepository { get; }
    public IGenericRepository<Event> EventRepository { get; }
    private IMapper Mapper { get; }
    private EmployeeAssignmentCreateValidator EmployeeAssignmentCreateValidator { get; }
    private EmployeeAssignmentUpdateValidator EmployeeAssignmentUpdateValidator { get; }

    public EmployeeAssignmentService(IGenericRepository<EmployeeAssignment> employeeAssignmentRepository, IGenericRepository<Employee> employeeRepository,
        IGenericRepository<Event> clubEventRepository, IMapper mapper,
        EmployeeAssignmentCreateValidator employeeAssignmentCreateValidator, EmployeeAssignmentUpdateValidator employeeAssignmentUpdateValidator)
    {
        EmployeeAssignmentRepository = employeeAssignmentRepository;
        EmployeeRepository = employeeRepository;
        EventRepository = clubEventRepository;
        Mapper = mapper;
        EmployeeAssignmentCreateValidator = employeeAssignmentCreateValidator;
        EmployeeAssignmentUpdateValidator = employeeAssignmentUpdateValidator;
    }

    public async Task<int> CreateEmployeeAssignmentAsync(EmployeeAssignmentCreate employeeAssignmentCreate)
    {
        await EmployeeAssignmentCreateValidator.ValidateAndThrowAsync(employeeAssignmentCreate);

        var clubEvent = await EventRepository.GetByIdAsync(employeeAssignmentCreate.EventId);
        var employee = await EmployeeRepository.GetByIdAsync(employeeAssignmentCreate.EmployeeId);
        var entity = Mapper.Map<EmployeeAssignment>(employeeAssignmentCreate);
        entity.Event = clubEvent;
        entity.Employee = employee;
        await EmployeeAssignmentRepository.InsertAsync(entity);
        await EmployeeAssignmentRepository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteEmployeeAssignmentAsync(EmployeeAssignmentDelete employeeAssignmentDelete)
    {
        var entity = await EmployeeAssignmentRepository.GetByIdAsync(employeeAssignmentDelete.Id);

        if (entity == null)
            throw new EmployeeAssignmentNotFoundException(employeeAssignmentDelete.Id);

        EmployeeAssignmentRepository.Delete(entity);
        await EmployeeAssignmentRepository.SaveChangesAsync();

    }

    public async Task<List<EmployeeAssignmentList>> GetEmployeeAssignmentsAsnyc(EmployeeAssignmentFilter employeeAssignmentFilter)
    {
        Expression<Func<EmployeeAssignment, bool>> employeeFilter = (employeeAssignment) => employeeAssignmentFilter.EmployeeId == null ? true :
        employeeAssignment.Employee.Id == employeeAssignmentFilter.EmployeeId;
        Expression<Func<EmployeeAssignment, bool>> eventFilter = (employeeAssignment) => employeeAssignmentFilter.EventId == null ? true :
        employeeAssignment.Event.Id == employeeAssignmentFilter.EventId;
        Expression<Func<EmployeeAssignment, bool>> isAssignedFilter = (employeeAssignment) => employeeAssignmentFilter.IsAssigned == null ? true :
        employeeAssignment.IsAssigned.Equals(employeeAssignmentFilter.IsAssigned);


        var entities = await EmployeeAssignmentRepository.GetFilteredAsync(new Expression<Func<EmployeeAssignment, bool>>[]
        {
            isAssignedFilter
        }, employeeAssignmentFilter.Skip, employeeAssignmentFilter.Take,
        (employeeAssignment) => employeeAssignment.Employee, (employeeAssignment) => employeeAssignment.Event);

        return Mapper.Map<List<EmployeeAssignmentList>>(entities);
    }

    public Task<List<EmployeeAssignmentGet>> GetEmployeeAssignmentsAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<EmployeeAssignmentGet> GetEmployeeAssignmentAsync(int id)
    {
        var entity = await EmployeeAssignmentRepository.GetByIdAsync(id);

        if (entity == null)
            throw new EmployeeAssignmentNotFoundException(id);

        return Mapper.Map<EmployeeAssignmentGet>(entity);
    }

    public async Task UpdateEmployeeAssignmentAsync(EmployeeAssignmentUpdate employeeAssignmentUpdate)
    {
        await EmployeeAssignmentUpdateValidator.ValidateAndThrowAsync(employeeAssignmentUpdate);

        var entity = Mapper.Map<EmployeeAssignment>(employeeAssignmentUpdate);

        if (entity == null)
            throw new EmployeeAssignmentNotFoundException(employeeAssignmentUpdate.Id);

        entity.IsAssigned = employeeAssignmentUpdate.IsAssigned;
        EmployeeAssignmentRepository.Update(entity);
        await EmployeeAssignmentRepository.SaveChangesAsync();
    }
}
