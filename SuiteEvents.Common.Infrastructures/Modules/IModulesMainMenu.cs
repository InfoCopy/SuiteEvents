using System;

using SuiteEvents.Common.Infrastructures.Interfaces;

namespace SuiteEvents.Common.Infrastructures.Modules
{
    public interface IModulesMainMenu : IController
    {
        event EventHandler<EventArgs> ModuloUtentiInvoked;
    }
}
