namespace NightClubManager.Common.Models;

public class Employee : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public List<EmployeeAssignment> EmployeeAssignments { get; set; }
    public List<Role> Roles { get; set; }
}