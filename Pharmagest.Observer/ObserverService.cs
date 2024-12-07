using Pharmagest.Interface.ObserverManager;
using System;
using System.Collections.Generic;

namespace Pharmagest.Observer
{
    public class ObserverService : IObserverService
    {
        private readonly IMessageObservable<MessageObserver<IBaseMessage>, IBaseMessage> _messageObservable;
        private readonly IList<Unsubscriber<MessageObserver<IBaseMessage>, IBaseMessage>> _disposables;

        public ObserverService()
        {
            _messageObservable = new MessageObservable<MessageObserver<IBaseMessage>, IBaseMessage>();
            _disposables = new List<Unsubscriber<MessageObserver<IBaseMessage>, IBaseMessage>>();
        }


        public void Publish(IBaseMessage message)
        {
            _messageObservable.Publish(message);
        }


        public int Subscribe(Action<IBaseMessage> action, string systemName)
        {
            var messageObserver = new MessageObserver<IBaseMessage>(action, systemName);

            var disposable = _messageObservable.Subscribe(messageObserver);

            _disposables.Add((Unsubscriber<MessageObserver<IBaseMessage>, IBaseMessage>)disposable);

            return messageObserver.Id;

        }


        /// <summary>
        /// Dispose all
        /// </summary>
        public void UnSuscribe()
        {
            foreach (var disposable in _disposables)
            {
                disposable.Dispose();
            }
        }


        /// <summary>
        /// Dispose specific observer
        /// </summary>
        /// <param name="id"></param>
        public void UnSuscribe(int id)
        {

            foreach (var disposable in _disposables)
            {
                disposable.Dispose(id);
            }
        }


    }




}
