using AutoMapper;
using NightClubManager.Common.Dtos.Employee;
using NightClubManager.Common.Dtos.EmployeeAssignment;
using NightClubManager.Common.Dtos.Event;
using NightClubManager.Common.Dtos.Role;
using NightClubManager.Common.Dtos.RoleRequirement;
using NightClubManager.Common.Models;

namespace NightClubManager.Business;


public class DtoEntityMapperProfile : Profile
{
    public DtoEntityMapperProfile()
    {
        CreateMap<RoleCreate, Role>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.RoleRequirements, opt => opt.Ignore());
        CreateMap<RoleUpdate, Role>()
            .ForMember(dest => dest.RoleRequirements, opt => opt.Ignore());
        CreateMap<Role, RoleGet>();
        CreateMap<Role, RoleList>();

        CreateMap<RoleRequirementCreate, RoleRequirement>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Role, opt => opt.Ignore())
            .ForMember(dest => dest.Event, opt => opt.Ignore());
        CreateMap<RoleRequirementUpdate, RoleRequirement>()
            .ForMember(dest => dest.Role, opt => opt.Ignore())
            .ForMember(dest => dest.Event, opt => opt.Ignore());
        CreateMap<RoleRequirement, RoleRequirementDetails>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<RoleRequirement, RoleRequirementGet>();
        CreateMap<RoleRequirement, RoleRequirementList>();

        CreateMap<EmployeeCreate, Employee>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Roles, opt => opt.Ignore())
            .ForMember(dest => dest.EmployeeAssignments, opt => opt.Ignore());
        CreateMap<EmployeeUpdate, Employee>()
            .ForMember(dest => dest.EmployeeAssignments, opt => opt.Ignore());
        CreateMap<Employee, EmployeeDetails>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Employee, EmployeeGet>();
        CreateMap<Employee, EmployeeList>();

        CreateMap<EmployeeAssignmentCreate, EmployeeAssignment>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<EmployeeAssignmentUpdate, EmployeeAssignment>()
            .ForMember(dest => dest.Employee, opt => opt.Ignore())
            .ForMember(dest => dest.Event, opt => opt.Ignore());
        CreateMap<EmployeeAssignment, EmployeeAssignmentDetails>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<EmployeeAssignment, EmployeeAssignmentGet>();
        CreateMap<EmployeeAssignment, EmployeeAssignmentList>();



        CreateMap<EventCreate, Event>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.EmployeeAssignments, opt => opt.Ignore())
            .ForMember(dest => dest.RoleRequirements, opt => opt.Ignore());
        CreateMap<EventUpdate, Event>()
            .ForMember(dest => dest.EmployeeAssignments, opt => opt.Ignore());
        CreateMap<Event, EventDetails>()
            .ForMember(dest => dest.Id, opt => opt.Ignore());
        CreateMap<Event, EventGet>();
        CreateMap<Event, EventList>();
    }
}
