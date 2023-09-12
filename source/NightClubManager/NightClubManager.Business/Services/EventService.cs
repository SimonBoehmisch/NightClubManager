using AutoMapper;
using FluentValidation;
using NightClubManager.Business.Exceptions;
using NightClubManager.Business.Validation;
using NightClubManager.Common.Dtos.Event;
using NightClubManager.Common.Dtos.Role;
using NightClubManager.Common.Dtos.RoleRequirement;
using NightClubManager.Common.Interfaces;
using NightClubManager.Common.Models;
using System.Linq.Expressions;

namespace NightClubManager.Business.Services;

public class EventService : IEventService
{
    private IGenericRepository<Event> EventRepository { get; }
    public IGenericRepository<RoleRequirement> RoleRequirementRepository { get; }
    public IGenericRepository<Role> RoleRepository { get; }
    public IGenericRepository<EmployeeAssignment> EmployeeAssignmentRepository { get; }
    private IMapper Mapper { get; }
    private EventCreateValidator EventCreateValidator { get; }
    private EventUpdateValidator EventUpdateValidator { get; }

    public EventService(IGenericRepository<Event> clubEventRepository, IGenericRepository<RoleRequirement> roleRequirementRepository,
        IGenericRepository<EmployeeAssignment> employeeAssignmentRepository, IMapper mapper, EventCreateValidator eventCreateValidator, EventUpdateValidator eventUpdateValidator)
    {
        EventRepository = clubEventRepository;
        RoleRequirementRepository = roleRequirementRepository;
        EmployeeAssignmentRepository = employeeAssignmentRepository;
        Mapper = mapper;
        EventCreateValidator = eventCreateValidator;
        EventUpdateValidator = eventUpdateValidator;
    }

    public async Task<int> CreateEventAsync(EventCreate clubEventCreate)
    {
        await EventCreateValidator.ValidateAndThrowAsync(clubEventCreate);

        DateTime dateTime = DateTime.Now;

        var entity = Mapper.Map<Event>(clubEventCreate);
        entity.Title = clubEventCreate.Title;
        entity.Start = dateTime;
        entity.End = dateTime.AddDays(1);

        await EventRepository.InsertAsync(entity);
        await EventRepository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteEventAsync(EventDelete clubEventDelete)
    {
        var entity = await EventRepository.GetByIdAsync(clubEventDelete.Id);

        if (entity == null)
            throw new EventNotFoundException(clubEventDelete.Id);

        EventRepository.Delete(entity);
        await EventRepository.SaveChangesAsync();

    }

    public async Task<EventDetails> GetEventAsync(int id)
    {
        var entity = await EventRepository.GetByIdAsync(id, (clubEvent) => clubEvent.Title, (clubEvent) => clubEvent.Start, (clubEvent) => clubEvent.End, (clubEvent) => clubEvent.EmployeeAssignments, (clubEvent) => clubEvent.RoleRequirements);

        if (entity == null)
            throw new EventNotFoundException(id);

        return Mapper.Map<EventDetails>(entity);
    }

    public async Task<List<EventList>> GetEventsAsnyc(EventFilter clubEventFilter)
    {
        Expression<Func<Event, bool>> titleFilter = (clubEvent) => clubEventFilter.Title == null ? true :
        clubEvent.Title.StartsWith(clubEventFilter.Title);
        Expression<Func<Event, bool>> startFilter = (clubEvent) => clubEventFilter.Start == null ? true :
        clubEvent.Start == clubEventFilter.Start;
        Expression<Func<Event, bool>> endFilter = (clubEvent) => clubEventFilter.End == null ? true :
        clubEvent.End == clubEventFilter.End;


        var entities = await EventRepository.GetFilteredAsync(new Expression<Func<Event, bool>>[]
        {
            titleFilter, startFilter, endFilter
        }, clubEventFilter.Skip, clubEventFilter.Take,
        (clubEvent) => clubEvent.EmployeeAssignments, (clubEvent) => clubEvent.RoleRequirements);

        return Mapper.Map<List<EventList>>(entities);
    }

    public async Task UpdateEventAsync(EventUpdate clubEventUpdate)
    {
        await EventUpdateValidator.ValidateAndThrowAsync(clubEventUpdate);

        Expression<Func<RoleRequirement, bool>> roleRequirementFilter = (roleRequirement) => clubEventUpdate.RoleRequirements.Contains(roleRequirement.Id);
        var roleRequirements = await RoleRequirementRepository.GetFilteredAsync(new[] { roleRequirementFilter }, null, null);

        Expression<Func<EmployeeAssignment, bool>> employeeAssignmentFilter = (employeeAssignment) => clubEventUpdate.EmployeeAssignments.Contains(employeeAssignment.Id);
        var employeeAssignments = await EmployeeAssignmentRepository.GetFilteredAsync(new[] { employeeAssignmentFilter }, null, null);

        var entity = await EventRepository.GetByIdAsync(clubEventUpdate.Id, (clubEvent) => clubEvent.EmployeeAssignments, (clubEvent) => clubEvent.RoleRequirements);

        if (entity == null)
            throw new EventNotFoundException(clubEventUpdate.Id);

        Mapper.Map(clubEventUpdate, entity);
        entity.Title = clubEventUpdate.Title;
        entity.Start = clubEventUpdate.Start;
        entity.End = clubEventUpdate.End;
        entity.EmployeeAssignments = employeeAssignments;
        entity.RoleRequirements = roleRequirements;
        EventRepository.Update(entity);
        await EventRepository.SaveChangesAsync();
    }
}
