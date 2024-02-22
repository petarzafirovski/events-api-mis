using EventsWebApi.Model;

namespace EventsWebApi.Repository
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEvents();
        Event GetEvent(int id);
        Task<bool> CreateEvent(Event @event);
        bool DeleteEvent(int id);
        void EditEvent(Event @event);
        IEnumerable<Event> GetEventsByUser(string createdById);
    }
}