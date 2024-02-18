namespace EventsWebApi.Exceptions
{
    [Serializable]
    public class EventNotFoundException : Exception
    {
        public EventNotFoundException() { }
        public EventNotFoundException(string message) : base(message) { }
    }
}
