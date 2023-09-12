using AutoMapper;
using FluentValidation;
using NightClubManager.Business.Exceptions;
using NightClubManager.Business.Validation;
using NightClubManager.Common.Dtos.Role;
using NightClubManager.Common.Dtos.RoleRequirement;
using NightClubManager.Common.Interfaces;
using NightClubManager.Common.Models;
using System.Linq.Expressions;

namespace NightClubManager.Business.Services;
public class RoleRequirementService : IRoleRequirementService
{
    private IGenericRepository<RoleRequirement> RoleRequirementRepository { get; }
    public IGenericRepository<Role> RoleRepository { get; }
    public IGenericRepository<Event> EventRepository { get; }
    private IMapper Mapper { get; }

    private RoleRequirementCreateValidator RoleRequirementCreateValidator { get; }
    private RoleRequirementUpdateValidator RoleRequirementUpdateValidator { get; }

    public RoleRequirementService(IGenericRepository<RoleRequirement> roleRequirementRepository, IGenericRepository<Role> roleRepository,
        IGenericRepository<Event> clubEventRepository, IMapper mapper, RoleRequirementCreateValidator roleRequirementCreateValidator, RoleRequirementUpdateValidator roleRequirementUpdateValidator)
    {
        RoleRequirementRepository = roleRequirementRepository;
        RoleRepository = roleRepository;
        EventRepository = clubEventRepository;
        Mapper = mapper;
        RoleRequirementCreateValidator = roleRequirementCreateValidator;
        RoleRequirementUpdateValidator = roleRequirementUpdateValidator;
    }

    public async Task<int> CreateRoleRequirementsAsync(RoleRequirementCreate roleRequirementCreate)
    {
        await RoleRequirementCreateValidator.ValidateAndThrowAsync(roleRequirementCreate);


        var clubEvent = await EventRepository.GetByIdAsync(roleRequirementCreate.EventId);

        var role = await RoleRepository.GetByIdAsync(roleRequirementCreate.RoleId);
        var entity = Mapper.Map<RoleRequirement>(roleRequirementCreate);
        entity.Event = clubEvent;
        entity.Role = role;
        entity.RequiredEmployees = roleRequirementCreate.RequiredEmployees;
        await RoleRequirementRepository.InsertAsync(entity);
        await RoleRequirementRepository.SaveChangesAsync();

        return entity.Id;
    }

    public async Task DeleteRoleRequirementAsync(RoleRequirementDelete roleRequirementDelete)
    {
        var entity = await RoleRequirementRepository.GetByIdAsync(roleRequirementDelete.Id);

        if (entity == null)
            throw new RoleRequirementNotFoundException(roleRequirementDelete.Id);

        RoleRequirementRepository.Delete(entity);
        await RoleRequirementRepository.SaveChangesAsync();

    }

    public async Task<RoleRequirementDetails> GetRoleRequirementAsync(int id)
    {
        var entity = await RoleRequirementRepository.GetByIdAsync(id, (roleRequirement) => roleRequirement.Event, (roleRequirement) => roleRequirement.Role);

        if (entity == null)
            throw new RoleRequirementNotFoundException(id);

        return Mapper.Map<RoleRequirementDetails>(entity);
    }

    public async Task<List<RoleRequirementList>> GetRoleRequirementsAsnyc(RoleRequirementFilter roleRequirementFilter)
    {
        Expression<Func<RoleRequirement, bool>> roleFilter = (roleRequirement) => roleRequirementFilter.RoleId == null ? true :
        roleRequirement.Role.Id == roleRequirementFilter.RoleId;
        Expression<Func<RoleRequirement, bool>> eventFilter = (roleRequirement) => roleRequirementFilter.EventId == null ? true :
        roleRequirement.Event.Id == roleRequirementFilter.EventId;

        var entities = await RoleRequirementRepository.GetFilteredAsync(new Expression<Func<RoleRequirement, bool>>[]
        {
            roleFilter, eventFilter
        }, roleRequirementFilter.Skip, roleRequirementFilter.Take,
        (roleRequirement) => roleRequirement.Event, (roleRequirement) => roleRequirement.Role);

        return Mapper.Map<List<RoleRequirementList>>(entities);
    }

    public async Task UpdateRoleRequirementAsync(RoleRequirementUpdate roleRequirementUpdate)
    {
        await RoleRequirementUpdateValidator.ValidateAndThrowAsync(roleRequirementUpdate);

        var clubEvent = await EventRepository.GetByIdAsync(roleRequirementUpdate.EventId);

        if (clubEvent == null)
            throw new EventNotFoundException(roleRequirementUpdate.EventId);

        var role = await RoleRepository.GetByIdAsync(roleRequirementUpdate.RoleId);

        if (role == null)
            throw new RoleNotFoundException(roleRequirementUpdate.RoleId);

        var entity = Mapper.Map<RoleRequirement>(roleRequirementUpdate);

        if (entity == null)
            throw new RoleRequirementNotFoundException(roleRequirementUpdate.Id);

        entity.Event = clubEvent;
        entity.Role = role;
        RoleRequirementRepository.Update(entity);
        await RoleRequirementRepository.SaveChangesAsync();
    }
}
