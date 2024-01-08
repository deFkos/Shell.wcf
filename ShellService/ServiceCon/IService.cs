using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShellService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IConnection" in both code and config file together.
    [ServiceContract(SessionMode = SessionMode.Required,CallbackContract = typeof(IServiceCallback))]
    public interface IService
    {
        [OperationContract]
        int Connect(string name);
        [OperationContract]
        void Disconnect(int id);
    }

    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void InfoMsg(string msg, int id);
    }
}
