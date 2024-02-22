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
        string? base64 = null;
        try
        {
            var coordinates = JsonConvert.DeserializeObject<EventCenterLocationDto>(@event.EventCenterLocation, Settings);
            location = coordinates;
            if (@event.Poster is not null)
            {
                base64 = @event.PosterPrefix + Convert.ToBase64String(@event.Poster);
            }
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
            EventEndDate = @event.EventEndDate?.ToString() ?? null,
            Poster = base64,
            EventCenter = @event.EventCenter,
            EventCenterLocation = location,
            BriefDescription = @event.BriefDescription,
            TicketSalesLink = @event.TicketSalesLink,
            IsFree = @event.IsFree,
            Picture = @event.Picture,
            EventStartDate = @event.EventStartDate?.ToString() ?? null,
            Artist = @event.Artist,
            EventUrl = @event.EventUrl,
            CreatedById = @event.CreatedById
        };
    }

    public static Event Map(this EventDto eventDto)
    {
        string? location = null;
        string? firstPartBase64 = null;
        byte[]? secondPartBase64 = null;
        try
        {
            var coordinates = JsonConvert.SerializeObject(eventDto.EventCenterLocation, Settings);
            location = coordinates;
            
            var commaIndex = eventDto.Poster?.IndexOf("base64,", StringComparison.InvariantCultureIgnoreCase) + "base64,".Length;
            if (commaIndex is not null)
            {
                firstPartBase64 = eventDto.Poster.Substring(0, (int)commaIndex);
                var secondPart = eventDto.Poster.Substring((int)commaIndex);
                secondPartBase64 = Convert.FromBase64String(secondPart);
            }
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
            EventEndDate = eventDto.EventEndDate is null ? null : DateTime.Parse(eventDto.EventEndDate),
            Poster = secondPartBase64,
            EventCenter = eventDto.EventCenter,
            EventCenterLocation = location,
            BriefDescription = eventDto.BriefDescription,
            TicketSalesLink = eventDto.TicketSalesLink,
            IsFree = eventDto.IsFree,
            Picture = eventDto.Picture,
            EventStartDate = eventDto.EventStartDate is null ? null : DateTime.Parse(eventDto.EventStartDate),
            Artist = eventDto.Artist,
            EventUrl = eventDto.EventUrl,
            CreatedById = eventDto.CreatedById,
            PosterPrefix = firstPartBase64
        };
    }

    public static JoinedEvents Map(this JoinEventDto eventDto)
    {
        return new JoinedEvents
        {
            UserId = eventDto.UserId,
            EventId = eventDto.EventId,
        };
    }

    public static JoinedEventsDto Map(this JoinedEvents joinedEvent)
    {
        var dto =  new JoinedEventsDto(joinedEvent.EventId, joinedEvent.UserId)
        {
            Event = joinedEvent.Event?.Map() ?? null
        };
        return dto;
    }
}