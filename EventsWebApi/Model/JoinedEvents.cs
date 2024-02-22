using System.ComponentModel.DataAnnotations.Schema;

namespace EventsWebApi.Model
{
    public class JoinedEvents
    {
        public int EventId { get; set; }
        public string UserId { get; set; }

        public Event? Event { get; set; }
    }
}
