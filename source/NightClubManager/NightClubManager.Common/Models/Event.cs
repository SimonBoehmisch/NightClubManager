namespace NightClubManager.Common.Models;

public class Event : BaseEntity
{
    public string Title { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public List<EmployeeAssignment> EmployeeAssignments { get; set; }
    public List<RoleRequirement> RoleRequirements { get; set; }
    public List<Schedule> Schedules { get; set; }
}
