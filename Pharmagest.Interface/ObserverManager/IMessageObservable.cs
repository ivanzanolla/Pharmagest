using System;

namespace Pharmagest.Interface.ObserverManager
{
    public interface IMessageObservable<TObserver, TMessage> : IObservable<TMessage>
        where TObserver : IMessageObserver<TMessage>
        where TMessage : IBaseMessage
    {
        void Publish(TMessage message);

    }
}