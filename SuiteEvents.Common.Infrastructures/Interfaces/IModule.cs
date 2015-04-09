using Microsoft.Practices.Unity;

namespace SuiteEvents.Common.Infrastructures.Interfaces
{
    public interface IModule
    {
        void Register(IUnityContainer container);
    }
}
