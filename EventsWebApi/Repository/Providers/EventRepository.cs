using EventsWebApi.Context;
using EventsWebApi.Exceptions;
using EventsWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace EventsWebApi.Repository.Providers
{
    public class EventRepository : IEventRepository
    {
        private readonly ApiDbContext _context;

        public EventRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateEvent(Event @event)
        {
            _context.Events.Add(@event);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool DeleteEvent(int id)
        {
            var @event = GetEventById(id);
            _context.Events.Remove(@event);
            _context.SaveChanges();
            return true;
        }

        public void EditEvent(Event @event)
        {
            if (@event == null) throw new ArgumentNullException(nameof(@event));

            var eventFromDb = _context.Events.Find(@event.Id);
            if (eventFromDb == null) throw new EventNotFoundException($"Event not found with id: {@event.Id}");

            var properties = @event.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

            foreach (var property in properties)
            {
                var newValue = property.GetValue(@event);

                if (newValue == null || property.Name == nameof(Event.Id)) continue;

                var propertyToBeUpdated = eventFromDb.GetType().GetProperty(property.Name);

                if (propertyToBeUpdated != null && propertyToBeUpdated.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), false).Length == 0)
                {
                    propertyToBeUpdated.SetValue(eventFromDb, newValue);
                }
            }
            _context.SaveChanges();
        }

        public IEnumerable<Event> GetEventsByUser(string createdById)
        {
            var eventsByUser = _context.Events
                .Where(@event => @event.CreatedById != null && @event.CreatedById.Equals(createdById))
                .ToList();
            return eventsByUser;
        }

        public async Task<IEnumerable<Event>> GetAllEvents()
        {
            return await _context.Events.ToListAsync();
        }

        public Event GetEvent(int id)
        {
            var @event = GetEventById(id);
            return @event;
        }

        private Event GetEventById(int id)
        {
            return _context.Events.Find(id) ?? throw new EventNotFoundException($"Event not found with id: {id}");
        }
    }
}
