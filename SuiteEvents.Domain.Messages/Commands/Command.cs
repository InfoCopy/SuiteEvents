using System;

namespace SuiteEvents.Domain.Messages.Commands
{
    [Serializable]
    public abstract class Command : IMessage
    {
        public Guid AggregateId { get; set; }
        public int Version { get; set; }
    }
}
