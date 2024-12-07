using System;

namespace Pharmagest.Interface.ObserverManager
{
    public interface IObserverService
    {
        void Publish(IBaseMessage message);
        int Subscribe(Action<IBaseMessage> action, string systemName);
        void UnSuscribe();
        void UnSuscribe(int id);
    }
}