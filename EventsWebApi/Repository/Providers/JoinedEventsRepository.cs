using EventsWebApi.Context;
using EventsWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EventsWebApi.Repository.Providers
{
    public class JoinedEventsRepository : IJoinedEventsRepository
    {
        private readonly ApiDbContext _context;
        private readonly IEventRepository _eventRepository;

        public JoinedEventsRepository(ApiDbContext context, IEventRepository eventRepository)
        {
            _context = context;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<JoinedEvents>> GetMyJoinedEvents(string userId)
        {
            List<JoinedEvents> joinedEventsList = new();
            var joined = await _context.JoinedEvents.Where(x => x.UserId == userId).ToListAsync();
            foreach (var myEvent in joined)
            {
                var @event = _eventRepository.GetEvent(myEvent.EventId);
                myEvent.Event = @event;
                joinedEventsList.Add(myEvent);
            }

            return joinedEventsList;
        }

        public bool JoinEvent(JoinedEvents joinEvent)
        {
            var @event = _eventRepository.GetEvent(joinEvent.EventId);

            if (_context.JoinedEvents.Any(je => je.UserId == joinEvent.UserId && je.EventId == joinEvent.EventId))
                return false;

            joinEvent.Event = @event;
            _context.JoinedEvents.Add(joinEvent);
            _context.SaveChanges();

            return true;
        }
    }
}
