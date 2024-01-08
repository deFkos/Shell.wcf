using ShellService.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShellService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Connection" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class Service : IService
    {
        public int Connect(string name)
        {
            UserData user = new UserData()
            {
                id = UserData.nextId,
                name = name,
                operationContext = OperationContext.Current
            };
            UserData.nextId++;
            foreach (var item in UserData.users)
            {
                item.operationContext.GetCallbackChannel<IAdminCallback>().InfoMsg($"{user.name} подключился", user.id);
            }
            UserData.users.Add(user);
            return user.id;
        }

        public void Disconnect(int id)
        {
            var user = UserData.users.FirstOrDefault(x => x.id == id);
            if (user != null)
            {
                UserData.users.Remove(user);
                foreach (var item in UserData.users)
                {
                    item.operationContext.GetCallbackChannel<IAdminCallback>().InfoMsg($"{user.name} отключился", user.id);
                }
            }
        }
    }
}
