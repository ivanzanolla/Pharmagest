using Pharmagest.Interface.ObserverManager;
using System;
using System.Collections.Concurrent;

namespace Pharmagest.Observer
{
    internal class Unsubscriber<TObserver, TMessage> : IDisposable
       where TObserver : IMessageObserver<TMessage>
       where TMessage : IBaseMessage
    {
        private readonly ConcurrentDictionary<int, TObserver> _observers;
        private readonly TObserver _observer;


        public Unsubscriber(ConcurrentDictionary<int, TObserver> observers, TObserver observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            _ = _observers.TryRemove(_observer.Id, out _);
        }


        public void Dispose(int id)
        {
            _ = _observers.TryRemove(id, out _);
        }
    }


}
