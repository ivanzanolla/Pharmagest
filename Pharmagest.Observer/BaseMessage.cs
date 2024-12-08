using Pharmagest.Interface.ObserverManager;

namespace Pharmagest.Observer
{
    public abstract class BaseMessage : IBaseMessage
    {

        public string Id { get; private set; }

        public string SystemName { get; protected set; }

        protected BaseMessage(string sysName)
        {
            SystemName = sysName;
        }

        

    }
}
