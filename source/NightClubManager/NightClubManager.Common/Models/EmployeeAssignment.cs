namespace NightClubManager.Common.Models;

public class EmployeeAssignment : BaseEntity
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int EventId { get; set; }
    public Event Event { get; set; }
    public bool IsAssigned { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}
