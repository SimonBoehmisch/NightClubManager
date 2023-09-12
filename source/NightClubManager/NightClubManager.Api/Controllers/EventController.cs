using Microsoft.AspNetCore.Mvc;
using NightClubManager.Common.Dtos.Event;
using NightClubManager.Common.Interfaces;

namespace NightClubManager.Api.Controllers;


[ApiController]
[Route("[controller]")]
public class EventController : ControllerBase
{
    private IEventService EventService { get; }

    public EventController(IEventService clubEventAssignmentService)
    {
        EventService = clubEventAssignmentService;
    }

    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateEvent(EventCreate clubEventAssignmentCreate)
    {
        var id = await EventService.CreateEventAsync(clubEventAssignmentCreate);
        return Ok(id);
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateEvent(EventUpdate clubEventAssignmentUpdate)
    {
        await EventService.UpdateEventAsync(clubEventAssignmentUpdate);
        return Ok();
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteEvent(EventDelete clubEventAssignmentDelete)
    {
        await EventService.DeleteEventAsync(clubEventAssignmentDelete);
        return Ok();
    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetEvent(int id)
    {
        var clubEventAssignment = await EventService.GetEventAsync(id);
        return Ok(clubEventAssignment);
    }

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetEvents([FromQuery] EventFilter clubEventAssignmentFilter)
    {
        var clubEventAssignments = await EventService.GetEventsAsnyc(clubEventAssignmentFilter);
        return Ok(clubEventAssignments);
    }

}
