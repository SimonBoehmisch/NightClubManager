namespace NightClubManager.Common.Models;

public class RoleRequirement : BaseEntity
{
    public int EventId { get; set; }
    public Event Event { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public int RequiredEmployees { get; set; }
}