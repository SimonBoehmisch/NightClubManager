using NightClubManager.Common.Dtos.Event;

namespace NightClubManager.Common.Interfaces;
public interface IEventService
{
    Task<int> CreateEventAsync(EventCreate clubEventAssignmentCreate);
    Task UpdateEventAsync(EventUpdate clubEventAssignmentUpdate);
    Task<List<EventList>> GetEventsAsnyc(EventFilter clubEventAssignmentFilter);
    Task<EventDetails> GetEventAsync(int id);
    Task DeleteEventAsync(EventDelete clubEventAssignmentDelete);
}

