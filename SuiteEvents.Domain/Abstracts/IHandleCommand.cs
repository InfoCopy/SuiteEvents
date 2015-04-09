using SuiteEvents.Domain.Messages.Commands;

namespace SuiteEvents.Domain.Abstracts
{
    public interface IHandleCommand<in T> where T : Command
    {
        void Handle(T command);
    }
}
