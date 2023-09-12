using NightClubManager.Common.Models;

namespace NightClubManager.Common.Dtos.EmployeeAssignment;

public record EmployeeAssignmentFilter(int? EmployeeId, int? EventId, bool? IsAssigned, int? Skip, int? Take);
