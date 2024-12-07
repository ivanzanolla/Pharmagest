using System;

namespace Pharmagest.Interface.ObserverManager
{
    public interface IMessageObserver<TMessage> : IObserver<TMessage>
        where TMessage : IBaseMessage
    {
        int Id { get; }
        string SystemName { get; }
    }
}