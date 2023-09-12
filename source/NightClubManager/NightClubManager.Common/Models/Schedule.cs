namespace NightClubManager.Common.Models;

public class Schedule : BaseEntity
{
    DateTime MonthYear { get; set; }
    public List<Event> Events { get; set; }
}
