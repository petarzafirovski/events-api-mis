using System.Text.Json.Serialization;
namespace EventsWebApi.Model.Dto;

public class EventDto
{
    [JsonPropertyName("Type")]
    public string? Type { get; set; }

    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    [JsonPropertyName("EventEndDate")]
    public DateTime? EventEndDate { get; set; }

    [JsonPropertyName("Poster")]
    public string? Poster { get; set; }

    [JsonPropertyName("EventCenter")]
    public string? EventCenter { get; set; }

    [JsonPropertyName("EventCenterLocation")]
    public EventCenterLocationDto? EventCenterLocation { get; set; }

    [JsonPropertyName("BriefDescription")]
    public string? BriefDescription { get; set; }

    [JsonPropertyName("TicketSalesLink")]
    public string? TicketSalesLink { get; set; }

    [JsonPropertyName("IsFree")]
    public bool IsFree { get; set; }

    [JsonPropertyName("Picture")]
    public string? Picture { get; set; }

    [JsonPropertyName("EventUrl")]
    public string? EventUrl { get; set; }

    [JsonPropertyName("EventStartDate")]
    public DateTime? EventStartDate { get; set; }

    [JsonPropertyName("Artist")]
    public string? Artist { get; set; }
    
    [JsonPropertyName("CreatedBy")]
    public string? CreatedById { get; set; }
}

public class EventCenterLocationDto
{
    [JsonPropertyName("Latitude")]
    public double Latitude { get; set; }
    
    [JsonPropertyName("Longitude")]
    public double Longitude { get; set; }
}