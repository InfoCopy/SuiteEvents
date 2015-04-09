using System;

namespace SuiteEvents.Common.Infrastructures.Interfaces
{
    public interface IHeader : IController
    {
        event EventHandler<EventArgs> CloseApplication;
    }
}
