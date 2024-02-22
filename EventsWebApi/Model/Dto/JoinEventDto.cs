using System.ComponentModel.DataAnnotations;

namespace EventsWebApi.Model.Dto
{
    public class JoinEventDto
    {
        [Required]
        public int EventId { get; set; }

        [Required]
        public string UserId { get; set; }

        public JoinEventDto(int eventId, string userId)
        {
            EventId = eventId;
            UserId = userId;
        }
    }
}
