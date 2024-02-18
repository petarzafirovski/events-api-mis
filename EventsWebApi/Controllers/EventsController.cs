using EventsWebApi.Exceptions;
using EventsWebApi.Mapper;
using EventsWebApi.Model.Dto;
using EventsWebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventsWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventsController : ControllerBase
{
    private readonly IEventRepository _eventsRepository;

    public EventsController(IEventRepository eventsRepository)
    {
        _eventsRepository = eventsRepository;
    }

    [HttpGet("get-events")]
    public IActionResult GetEvents()
    {
        try
        {
            var events = _eventsRepository.GetAllEvents().Select(@event => @event.Map()).ToList();
            return Ok(events);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpGet("get-my-events/{userId}")]
    public IActionResult GetMyEvents(string userId)
    {
        try
        {
            var eventsByMe = _eventsRepository.GetEventsByUser(userId);
            return Ok(eventsByMe);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("get-event/{id:int}")]
    public IActionResult GetEvent(int id)
    {
        try
        {
            var mappedEvent = _eventsRepository.GetEvent(id).Map();
            return Ok(mappedEvent);
        }
        catch (Exception ex)
        {
            if (ex is EventNotFoundException eventExc)
            {
                return BadRequest(eventExc.Message);
            }
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost("add-event")]
    public IActionResult AddEvent([FromBody] EventDto eventDto)
    {
        try
        {
            var @event = eventDto.Map();
            var res = _eventsRepository.CreateEvent(@event);
            if (res)
            {
                return StatusCode(201);
            }
            return BadRequest("Event not created.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("delete-event/{id:int}")]
    public IActionResult DeleteEvent(int id)
    {
        try
        {
            _eventsRepository.DeleteEvent(id);
            return Ok();
        }
        catch (Exception ex)
        {
            if (ex is EventNotFoundException eventExc)
            {
                return BadRequest(eventExc.Message);
            }
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("edit-event")]
    public IActionResult EditEvent([FromBody] EventDto eventDto)
    {
        try
        {
            var @event = eventDto.Map();
            _eventsRepository.EditEvent(@event);
            return Ok();
        }
        catch (Exception ex)
        {
            if (ex is EventNotFoundException eventExc)
            {
                return BadRequest(eventExc.Message);
            }
            return StatusCode(500, ex.Message);
        }
    }
}