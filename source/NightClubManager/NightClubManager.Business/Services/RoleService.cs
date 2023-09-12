using AutoMapper;
using FluentValidation;
using NightClubManager.Business.Exceptions;
using NightClubManager.Business.Validation;
using NightClubManager.Common.Dtos.Role;
using NightClubManager.Common.Interfaces;
using NightClubManager.Common.Models;

namespace NightClubManager.Business.Services;

public class RoleService : IRoleService
{
    private IMapper Mapper { get; }
    private IGenericRepository<Role> RoleRepository { get; }
    private RoleCreateValidator RoleCreateValidator { get; }
    private RoleUpdateValidator RoleUpdateValidator { get; }

    public RoleService(IMapper mapper, IGenericRepository<Role> roleRepository, RoleCreateValidator roleCreateValidator, RoleUpdateValidator roleUpdateValidator)
    {
        Mapper = mapper;
        RoleRepository = roleRepository;
        RoleCreateValidator = roleCreateValidator;
        RoleUpdateValidator = roleUpdateValidator;
    }


    public async Task<int> CreateRoleAsync(RoleCreate roleCreate)
    {
        await RoleCreateValidator.ValidateAndThrowAsync(roleCreate);

        var entity = Mapper.Map<Role>(roleCreate);
        await RoleRepository.InsertAsync(entity);
        await RoleRepository.SaveChangesAsync();
        return entity.Id;
    }

    public async Task DeleteRoleAsync(RoleDelete roleDelete)
    {
        var entity = await RoleRepository.GetByIdAsync(roleDelete.Id);

        if (entity == null)
            throw new RoleNotFoundException(roleDelete.Id);

        RoleRepository.Delete(entity);
        await RoleRepository.SaveChangesAsync();
    }

    public async Task<RoleGet> GetRoleAsync(int id)
    {
        var entity = await RoleRepository.GetByIdAsync(id);

        if (entity == null)
            throw new RoleNotFoundException(id);

        return Mapper.Map<RoleGet>(entity);
    }

    public async Task<List<RoleGet>> GetRolesAsync()
    {
        var entities = await RoleRepository.GetAsync(null, null);
        return Mapper.Map<List<RoleGet>>(entities);
    }

    public async Task UpdateRoleAsync(RoleUpdate roleUpdate)
    {
        await RoleUpdateValidator.ValidateAndThrowAsync(roleUpdate);

        var entity = Mapper.Map<Role>(roleUpdate);

        if (entity == null)
            throw new RoleNotFoundException(roleUpdate.Id);

        RoleRepository.Update(entity);
        await RoleRepository.SaveChangesAsync();
    }
}

