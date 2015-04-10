using System;
using System.Collections.Generic;

using Microsoft.Practices.Unity;

using NEventStore;
using NEventStore.Dispatcher;

using SuiteEvents.Domain.Infrastructures.Abstracts;

namespace SuiteEvents.Domain.Infrastructures.Concretes
{
    public class SuiteDispatcher : IDispatchCommits
    {
        private readonly IUnityContainer _container;
        Dictionary<Type, Action<IUnityContainer, IEvent>> _registry = new Dictionary<Type, Action<IUnityContainer, IEvent>>();

        public SuiteDispatcher(IUnityContainer container)
        {
            this._container = container;
        }

        public void Dispatch(Commit commit)
        {
            var store = this._container.Resolve<IStoreEvents>();

            var minRevision = int.MinValue;
            var snapshot = store.Advanced.GetSnapshot(commit.StreamId, int.MaxValue);
            if (snapshot != null)
                minRevision = snapshot.StreamRevision;
            //else
            //    snapshot = new Snapshot(commit.StreamId, commit.StreamRevision, new MyMemento());

            var stream = store.OpenStream(commit.StreamId, minRevision, int.MaxValue);

            using (var child = this._container.CreateChildContainer())
            {
                //child.RegisterInstance<ISnapshot>(snapshot);
                child.RegisterInstance(stream);

                foreach (var msg in commit.Events)
                {
                    // TODO: keep handler around so we don't have to re-initialize on each iteration (don't worry about it for now - all our commits only have a single event)
                    this._registry[msg.Body.GetType()](child, (IEvent)msg.Body);
                }
            }
        }

        public void Dispose()
        {
        }

        public void RegisterHandler<T, TH>()
            where TH : IHandler<T>
            where T : IEvent
        {
            this._registry.Add(typeof(T), (unity, evt) => ((IHandler<T>)unity.Resolve(typeof(TH))).Handle(evt));
        }
    }
}
