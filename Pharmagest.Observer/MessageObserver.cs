using Pharmagest.Interface.ObserverManager;
using System;
using System.Threading.Tasks.Dataflow;

namespace Pharmagest.Observer
{
    internal class MessageObserver<TMessage> : IMessageObserver<TMessage>
        where TMessage : IBaseMessage
    {
        private readonly ActionBlock<TMessage> _actionBlock;

        private readonly string _systemName;
        public string SystemName => _systemName;


        public int Id { get; }

        private static int id = 1;

        public MessageObserver(Action<TMessage> action, string systemName)
        {
            _actionBlock = new ActionBlock<TMessage>(action);
            _systemName = systemName;
            Id = id++;
        }



        public void OnCompleted()
        {
            //
        }

        public void OnError(Exception error)
        {
        }

        public void OnNext(TMessage message)
        {
            _actionBlock.Post(message);
        }
    }
}
