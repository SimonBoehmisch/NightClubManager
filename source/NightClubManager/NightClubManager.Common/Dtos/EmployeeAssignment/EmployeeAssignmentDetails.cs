using NightClubManager.Common.Dtos.Employee;
using NightClubManager.Common.Dtos.Event;

namespace NightClubManager.Common.Dtos.EmployeeAssignment;

public record EmployeeAssignmentDetails(int Id, EmployeeGet Employee, EventGet Event);