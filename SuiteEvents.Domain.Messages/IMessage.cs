using System;

namespace SuiteEvents.Domain.Messages
{
    public interface IMessage
    {
        Guid AggregateId { get; set; }
        int Version { get; set; }
    }
}
