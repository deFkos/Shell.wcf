using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShellService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAdminFunc" in both code and config file together.
    [ServiceContract(CallbackContract = typeof(IAdminCallback))]
    public interface IAdmin
    {
        [OperationContract(IsOneWay = true)]
        void AddGameTime(double hour, double minute, int id);
        
        [OperationContract]
        int Connect(string Name);
        
        [OperationContract(IsOneWay = true)]
        void Disconnect(int id);
    }

    public interface IAdminCallback
    {
        [OperationContract(IsOneWay = true)]
        void InfoMsg(string msg, int id);
    }
}
