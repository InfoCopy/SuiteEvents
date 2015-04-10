namespace SuiteEvents.Domain.Infrastructures.Abstracts
{
    public interface IHandler<T> where T : IEvent
    {
        void Handle(object message);
    }

    public interface IEvent
    {
        string MessageId { get; set; }
        int Version { get; set; }
    }
}
