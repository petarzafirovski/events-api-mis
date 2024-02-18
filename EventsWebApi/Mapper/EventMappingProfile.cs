using EventsWebApi.Model;
using EventsWebApi.Model.Dto;
using Newtonsoft.Json;

namespace EventsWebApi.Mapper;

public static class EventMapper
{
    private static readonly JsonSerializerSettings Settings = new()
    {
        NullValueHandling = NullValueHandling.Ignore
    };
    
    public static EventDto Map(this Event @event)
    {
        var location = new EventCenterLocationDto();
        try
        {
            var coordinates = JsonConvert.DeserializeObject<EventCenterLocationDto>(@event.EventCenterLocation, Settings);
            location = coordinates;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        return new EventDto
        {
            Id = @event.Id,
            Type = @event.Type,
            Name = @event.Name,
            EventEndDate = @event.EventEndDate,
            Poster = @event.Poster,
            EventCenter = @event.EventCenter,
            EventCenterLocation = location,
            BriefDescription = @event.BriefDescription,
            TicketSalesLink = @event.TicketSalesLink,
            IsFree = @event.IsFree,
            Picture = @event.Picture,
            EventStartDate = @event.EventStartDate,
            Artist = @event.Artist,
            EventUrl = @event.EventUrl,
            CreatedById = @event.CreatedById
        };
    }
    
    public static Event Map(this EventDto eventDto)
    {
        string? location = null;
        try
        {
            var coordinates = JsonConvert.SerializeObject(eventDto.EventCenterLocation, Settings);
            location = coordinates;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        
        return new Event
        {
            Id = eventDto.Id,
            Type = eventDto.Type,
            Name = eventDto.Name,
            EventEndDate = eventDto.EventEndDate,
            Poster = eventDto.Poster,
            EventCenter = eventDto.EventCenter,
            EventCenterLocation = location,
            BriefDescription = eventDto.BriefDescription,
            TicketSalesLink = eventDto.TicketSalesLink,
            IsFree = eventDto.IsFree,
            Picture = eventDto.Picture,
            EventStartDate = eventDto.EventStartDate,
            Artist = eventDto.Artist,
            EventUrl = eventDto.EventUrl,
            CreatedById = eventDto.CreatedById
        };
    }
}