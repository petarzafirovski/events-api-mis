using EventsWebApi.Context;
using EventsWebApi.Model;

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

        public IEnumerable<JoinedEvents> GetMyJoinedEvents(string userId)
        {
            return _context.JoinedEvents.ToList();
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
