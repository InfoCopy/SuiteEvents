using System;

using SuiteEvents.Domain.Messages.Commands;
using SuiteEvents.Domain.Messages.Events;

namespace SuiteEvents.Domain.Infrastructures.Abstracts
{
    public interface IServiceBus
    {
        void Send<T>(T command) where T : Command;
        void RegisterHandler<T>(Action<T> handler) where T : Event;
    }
}
