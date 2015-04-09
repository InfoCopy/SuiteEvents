using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using Microsoft.Practices.Unity;
using NEventStore.Dispatcher;

using SuiteEvents.Domain.Abstracts;
using SuiteEvents.Domain.Infrastructures.Abstracts;
using SuiteEvents.Domain.Messages.Events;

namespace SuiteEvents.Domain.Infrastructures.Concretes
{
    public class InProcessBus : IServiceBus, IDispatchCommits
    {
        private readonly IUnityContainer _container;
        private readonly Dictionary<Type, List<Action<Event>>> _routes = new Dictionary<Type, List<Action<Event>>>();

        public InProcessBus(IUnityContainer container)
        {
            this._container = container;
        }

        public void Send<T>(T command) where T : Messages.Commands.Command
        {
            if (command == null) throw new ArgumentNullException("command");

            this._container.Resolve<IHandleCommand<T>>().Handle(command);
        }

        public void RegisterHandler<T>(Action<T> handler) where T : Event
        {
            List<Action<Event>> handlers;
            if (!this._routes.TryGetValue(typeof (T), out handlers))
            {
                handlers = new List<Action<Event>>();
                this._routes.Add(typeof(T), handlers);
            }
            handlers.Add(DelegateAdjuster.CastArgument<Event, T>(x => handler(x)));
        }

        public void Dispatch(NEventStore.Commit commit)
        {
            foreach (var @event in commit.Events)
            {
                List<Action<Event>> handlers;
                if (!this._routes.TryGetValue(@event.Body.GetType(), out handlers)) return;

                foreach (var handler in handlers)
                    handler((Event)@event.Body);
            }
        }

        #region Dispose
        private bool _disposed;
        public void Dispose()
        {
            Dispose(true);
            // Use SupressFinalize in case a subclass
            // of this type implements a finalizer.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {
            }
            this._disposed = true;
        }
        #endregion
    }

    public static class DelegateAdjuster
    {
        public static Action<TBase> CastArgument<TBase, TDerived>(Expression<Action<TDerived>> source)
            where TDerived : TBase
        {
            if (typeof(TDerived) == typeof(TBase))
                return (Action<TBase>)((Delegate)source.Compile());

            var sourceParameter = Expression.Parameter(typeof(TBase), "source");
            var result = Expression.Lambda<Action<TBase>>(Expression.Invoke(source, Expression.Convert(sourceParameter, typeof(TDerived))), sourceParameter);

            return result.Compile();
        }
    }
}
