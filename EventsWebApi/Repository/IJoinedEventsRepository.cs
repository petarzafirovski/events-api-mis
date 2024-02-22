using EventsWebApi.Model;

namespace EventsWebApi.Repository
{
    public interface IJoinedEventsRepository
    {
        Task<IEnumerable<JoinedEvents>> GetMyJoinedEvents(string userId);
        bool JoinEvent(JoinedEvents joinEvent);
    }
}
