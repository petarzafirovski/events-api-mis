using System.ComponentModel.DataAnnotations;

namespace EventsWebApi.Model.Dto
{
    public class JoinedEventsDto
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        public string UserId { get; set; }

        public Event? Event { get; set; }

        public JoinedEventsDto(int eventId, string userId)
        {
            EventId = eventId;
            UserId = userId;
        }
    }
}
