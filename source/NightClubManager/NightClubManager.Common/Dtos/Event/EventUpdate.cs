namespace NightClubManager.Common.Dtos.Event;

public record EventUpdate(int Id, string Title, DateTime Start, DateTime End, List<int> EmployeeAssignments, List<int> RoleRequirements);