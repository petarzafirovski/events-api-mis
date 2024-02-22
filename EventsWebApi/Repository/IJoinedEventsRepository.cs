using EventsWebApi.Model;

namespace EventsWebApi.Repository
{
    public interface IJoinedEventsRepository
    {
        IEnumerable<JoinedEvents> GetMyJoinedEvents(string userId);
        bool JoinEvent(JoinedEvents joinEvent);
    }
}
