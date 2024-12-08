using Pharmagest.Interface.ObserverManager;
using System;

namespace Pharmagest.Message
{
    public abstract class BaseMessage : IBaseMessage
    {

        public string Id { get; private set; }
        public string SystemName { get; private set; }


        protected BaseMessage(string sysName)
        {
            SystemName = sysName;
            Id = Guid.NewGuid().ToString();
        }

        protected BaseMessage(string sysName, string id)
        {
            SystemName = sysName;
            Id = id;
        }



    }
}
