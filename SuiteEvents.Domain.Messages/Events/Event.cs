using System;

namespace SuiteEvents.Domain.Messages.Events
{
    public abstract class Event : IMessage
    {
        public Guid AggregateId { get; set; }
        public int Version { get; set; }
    }
}
