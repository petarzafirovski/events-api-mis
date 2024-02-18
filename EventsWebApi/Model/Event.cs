using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventsWebApi.Model
{
    [Table("Event")]
    public class Event
    {
        public string? Type { get; set; }

        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime? EventEndDate { get; set; }

        public string? Poster { get; set; }

        public string? EventCenter { get; set; }
        
        public string? EventCenterLocation { get; set; }

        public string? BriefDescription { get; set; }

        public string? TicketSalesLink { get; set; }

        public bool IsFree { get; set; }

        public string? Picture { get; set; }

        public string? EventUrl { get; set; }

        public DateTime? EventStartDate { get; set; }

        public string? Artist { get; set; }
        
        public string? CreatedById { get; set; }
    }
}