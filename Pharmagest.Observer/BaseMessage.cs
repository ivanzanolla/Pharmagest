using Pharmagest.Interface.ObserverManager;

namespace Pharmagest.Observer
{
    public abstract class BaseMessage : IBaseMessage
    {

        protected BaseMessage(string sysName)
        {
            SystemName = sysName;
        }


        public string SystemName { get; protected set; }

    }
}
