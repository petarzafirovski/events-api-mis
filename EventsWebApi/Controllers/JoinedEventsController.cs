using EventsWebApi.Exceptions;
using EventsWebApi.Mapper;
using EventsWebApi.Model.Dto;
using EventsWebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EventsWebApi.Controllers
{
    [Route("api/my-events")]
    [ApiController]
    public class JoinedEventsController : ControllerBase
    {
        private readonly IJoinedEventsRepository _joinedEventsRepository;

        public JoinedEventsController(IJoinedEventsRepository joinedEventsRepository)
        {
            _joinedEventsRepository = joinedEventsRepository;
        }

        [HttpGet("get-joined/{userId}")]
        public IActionResult GetEvents(string userId)
        {
            try
            {
                var events = _joinedEventsRepository.GetMyJoinedEvents(userId).Select(e => e.Map()).ToList();
                return Ok(events);
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

        [HttpPost("join")]
        public IActionResult JoinEvent([FromBody] JoinEventDto dto)
        {
            try
            {
                var result = _joinedEventsRepository.JoinEvent(dto.Map());

                if (result)
                    return StatusCode(201);
                else
                    return BadRequest("You already joined this event");
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
}
