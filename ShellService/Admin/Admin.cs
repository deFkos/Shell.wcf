using ShellService.Admin.Func;
using ShellService.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ShellService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AdminFunc" in both code and config file together.
    public class AdminService : IAdmin
    {
        Service connection = new Service();
        public void AddGameTime(double hour, double minute, int id)
        {
            AddTime addTime = new AddTime()
            {
                CurrentTime = DateTime.Now,
            };
            var EndGameTime = addTime.CurrentTime.AddHours(hour);
            EndGameTime = EndGameTime.AddMinutes(minute);
            addTime.TimeRanges = new Dictionary<DateTime, DateTime>();
            addTime.TimeRanges.Add(addTime.CurrentTime, EndGameTime);

            foreach (var user in UserData.users)
            {
                if (user.id == id)
                {
                    addTime.id = user.id;
                    foreach (var item in addTime.TimeRanges)
                    {
                        user.operationContext.GetCallbackChannel<IAdminCallback>().InfoMsg($"{item.Key.ToShortTimeString()} : {item.Value.ToShortTimeString()}", id);
                    }
                }
            }
            AddTime.addTimes.Add(addTime);
        }

        public int Connect(string Name)
        {
            return connection.Connect(Name);
        }
        public void Disconnect(int id)
        {
            connection.Disconnect(id); 
        }
    }
}
