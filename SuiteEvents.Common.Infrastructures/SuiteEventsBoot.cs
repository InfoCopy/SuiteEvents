using System;
using Microsoft.Practices.Unity;
using SuiteEvents.Common.Infrastructures.Interfaces;

namespace SuiteEvents.Common.Infrastructures
{
    public class SuiteEventsBoot
    {
        private readonly IUnityContainer _container;

        public SuiteEventsBoot(IUnityContainer container)
		{
            this._container = container;
		}

        public SuiteEventsBoot RegisterModule(Type moduleType)
        {
            var module = _container.Resolve(moduleType) as IModule;

            if (module == null)
                throw new ArgumentException("moduleType");
            module.Register(_container);

            return this;
        }
    }
}
