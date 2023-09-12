namespace NightClubManager.Common.Models;

public class Role : BaseEntity
{
    public string Name { get; set; }

    public List<Employee> Employees { get; set; }
    public List<RoleRequirement> RoleRequirements { get; set; }
}