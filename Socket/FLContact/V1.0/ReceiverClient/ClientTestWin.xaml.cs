using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Sockets;
using System.Net;
using Common.Data.SocketData;
using System.Threading;

namespace ReceiverClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClientTestWin : Window
    {
        //const string Host = "192.168.2.169";
        //const int Port = 6666;
        //const int SendBufferSize = 1024;
        //const int SoundBufferSize = 4096;//4096//157569
        //const int BufferSize = 1024;
        //string path = @"E:\工作文档\6.Project\MyWPF\Common\Data\SocketData\log.txt";

        //#region LocalHost

        //private string _localHost;
        //public string LocalHost
        //{
        //    get
        //    {
        //        if (string.IsNullOrEmpty(_localHost))
        //        {
        //            _localHost = GetLocalIP();
        //        }
        //        return _localHost;
        //    }
        //}
        //private string GetLocalIP()
        //{
        //    string hostName = Dns.GetHostName();
        //    IPAddress[] ips = Dns.GetHostAddresses(hostName);
        //    foreach (IPAddress ip in ips)
        //    {
        //        if (ip.ToString().IndexOf("192") >= 0)
        //        {
        //            return ip.ToString();
        //        }
        //    }
        //    return "";
        //}
        //#endregion

        public ClientTestWin()
        {
            InitializeComponent();
        }

        public string ContactState
        {
            get { return (string)GetValue(ContactStateProperty); }
            set { SetValue(ContactStateProperty, value); }
        }

        public static readonly DependencyProperty ContactStateProperty =
            DependencyProperty.Register("ContactState", typeof(string), typeof(ClientTestWin), new FrameworkPropertyMetadata(OnContactStatePropertyChanged));

        private static void OnContactStatePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ClientTestWin control = sender as ClientTestWin;
            control.tb_out.Text += "  " + e.NewValue.ToString();
        }

        ServerService Server;
        ClientService ClientC;
        ClientService ClientR;
        //服务器端启用
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //中转服
            Server = new ServerService(TestData.ServerHost, TestData.ServerPort);
            Server.SetOuter(tb_out);
            Server.Listen();
            //UpdateText("{0}已启用", "服务");
            //UpdateText("地址:{0}:{1}", TestData.ServerHost, TestData.ServerPort);
        }
        //客户端启用
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            //主拨方
            UserInfo user = new UserInfo(Guid.NewGuid());
            user.Host = TestData.LocalHost;
            user.Port = TestData.ClientPort;
            //user.Code = user.Host.Substring(user.Host.LastIndexOf(".") + 1);
            //user.Name = "用户2" + user.Host.Substring(user.Host.LastIndexOf(".") + 1);
            ClientC = new ClientService(user);
            ClientC.SetOuter(tb_out);
            ClientC.Listen();
            //UpdateText("{0}已启用", ClientC.User.Name);
            //UpdateText("地址:{0}:{1}", TestData.LocalHost, TestData.ClientPort);


        }
        // 拨号
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                ////主拨拨号
                ClientC.User.TargetCode = tb_code.Text;
                ClientC.CallCommand();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void button6_Click_1(object sender, RoutedEventArgs e)
        {
            Server.CheckOnline();
        }
        //终止现有通话
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            ClientC.Close();
        }
    }
}
