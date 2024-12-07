using Pharmagest.Interface.ObserverManager;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace Pharmagest.Observer
{
    internal class MessageObservable<TObserver, TMessage> : IMessageObservable<TObserver, TMessage>
        where TObserver : IMessageObserver<TMessage>
        where TMessage : IBaseMessage
    {
        private readonly ConcurrentDictionary<int, TObserver> _observers;

        public MessageObservable()
        {
            _observers = new ConcurrentDictionary<int, TObserver>();
        }

        public IDisposable Subscribe(IObserver<TMessage> observer)
        {
            var casted = (TObserver)observer;

            _observers.TryAdd(casted.Id, casted);

            return new Unsubscriber<TObserver, TMessage>(_observers, casted);
        }

        public void Publish(TMessage message)
        {
            var observers = _observers.Where(o => o.Value.SystemName.Equals(message.SystemName));

            Parallel.ForEach(observers, (obs) =>
            {
                obs.Value.OnNext(message);
            });


        }
    }



}
