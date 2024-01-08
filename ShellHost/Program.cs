using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ShellHost
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var service = new ServiceHost(typeof(ShellService.Service));
            service.Open();
            Console.WriteLine("\t...service host open...");

            var admin = new ServiceHost(typeof(ShellService.AdminService));
            admin.Open();
            Console.WriteLine("\t...Admin host open...");

            var user = new ServiceHost(typeof(ShellService.UserService));
            user.Open();
            Console.WriteLine("\t...User host open..."); 
            Console.ReadLine();
        }
    }
}
