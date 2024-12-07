using Pharmagest.Interface.ObserverManager;

namespace Pharmagest.Message
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
