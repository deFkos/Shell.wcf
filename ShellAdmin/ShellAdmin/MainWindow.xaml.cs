using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using ShellAdmin.Connection;
using System.ComponentModel.Design;
using ShellAdmin.AdminConnection;

namespace ShellAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IAdminCallback//,IConnectionCallback
    {
        //ConnectionClient client;
        AdminClient client;
        bool IsConnection;
        int id;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Connection_btn_Click(object sender, RoutedEventArgs e)
        {
            if(!IsConnection && Name.Text != "")
            {
                Connection();
                Name.IsEnabled = false;
                Connection_btn.Content = "Disconnection";
            }
            else if (IsConnection && Name.Text != "")
            {
                Disconnect();
                Name.IsEnabled = true;
                Connection_btn.Content = "Connection";
            }
        }

        public void Connection()
        {
            client = new AdminClient(new System.ServiceModel.InstanceContext(this));
            id = client.Connect(Name.Text);
            IsConnection = true;
        }
        public void Disconnect()
        {
            client.Disconnect(id);
            client = null;
            IsConnection = false;
        }

        public void AddTime(double hours, double minutes, int id)
        {
            client.AddGameTime(hours, minutes, id); 
        }

        public void InfoMsg(string msg, int id)
        {
            lbChat.Items.Add(msg + ": " + id);
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);
        }

        private void AddTime_btn_Click(object sender, RoutedEventArgs e)
        {
            AddTime(hHoursSl.Value, hMinuteSl.Value, int.Parse(idUser.Text));
        }
    }
}
