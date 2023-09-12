using Microsoft.Extensions.DependencyInjection;
using NightClubManager.Business.Services;
using NightClubManager.Business.Validation;
using NightClubManager.Common.Interfaces;

namespace NightClubManager.Business;

public class DIConfiguration
{
    public static void RegisterServices(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DtoEntityMapperProfile));
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmployeeAssignmentService, EmployeeAssignmentService>();
        services.AddScoped<IRoleRequirementService, RoleRequirementService>();
        services.AddScoped<IEventService, EventService>();

        services.AddScoped<RoleCreateValidator>();
        services.AddScoped<RoleUpdateValidator>();
        services.AddScoped<EmployeeCreateValidator>();
        services.AddScoped<EmployeeUpdateValidator>();
        services.AddScoped<EmployeeAssignmentCreateValidator>();
        services.AddScoped<EmployeeAssignmentUpdateValidator>();
        services.AddScoped<RoleRequirementCreateValidator>();
        services.AddScoped<RoleRequirementUpdateValidator>();
        services.AddScoped<EventCreateValidator>();
        services.AddScoped<EventUpdateValidator>();
    }
}
