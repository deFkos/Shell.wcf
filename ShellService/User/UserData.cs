using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ShellService.User
{
    public class UserData
    {
        public int id { get; set; }

        public string name { get; set; }

        public static List<UserData> users { get; set; } = new List<UserData>();  

        public static int nextId { get; set; } = 1;

        public OperationContext operationContext { get; set; }
    }
}
