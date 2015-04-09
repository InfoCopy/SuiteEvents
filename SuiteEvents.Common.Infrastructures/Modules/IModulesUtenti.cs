using System;
using SuiteEvents.Common.Infrastructures.Interfaces;

namespace SuiteEvents.Common.Infrastructures.Modules
{
    public interface IModulesUtenti : IController
    {
        event EventHandler<EventArgs> CloseModuloUtentiInvoked;
    }
}
