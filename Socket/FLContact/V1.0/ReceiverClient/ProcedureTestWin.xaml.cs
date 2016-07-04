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
    /// Interaction logic for ProcedureTestWin.xaml
    /// </summary>
    public partial class ProcedureTestWin : Window
    {
        const string Host = "192.168.2.169";
        const int Port = 6666;
        const int SendBufferSize = 1024;
        const int SoundBufferSize = 4096;//4096//157569
        const int BufferSize = 1024;
        string path = @"E:\工作文档\6.Project\MyWPF\Common\Data\SocketData\log.txt";

        public ProcedureTestWin()
        {
            InitializeComponent();

            //TimerCallback timerCallback = new TimerCallback((state) =>
            //    {
            //        tb_out.Text += "1";
            //        tb_out.UpdateLayout();
            //        //tb_out.Text = System.IO.File.ReadAllText(path);
            //    });
            //Timer timer = new Timer(timerCallback, null, 0, 1000);
        }

        public string ContactState
        {
            get { return (string)GetValue(ContactStateProperty); }
            set { SetValue(ContactStateProperty, value); }
        }

        public static readonly DependencyProperty ContactStateProperty =
            DependencyProperty.Register("ContactState", typeof(string), typeof(ProcedureTestWin), new FrameworkPropertyMetadata(OnContactStatePropertyChanged));

        private static void OnContactStatePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ProcedureTestWin control = sender as ProcedureTestWin;
            control.tb_out.Text += "  "+e.NewValue.ToString();
        }

        ServerService Server;
        ClientService ClientC;
        ClientService ClientR;
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            //中转服
            Server = new ServerService(TestData.ServerHost, TestData.ServerPort);
            Server.SetOuter(tb_out);
            Server.Listen();
        }
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            //主拨方
            UserInfo user = new UserInfo(Guid.NewGuid());
            user.Host = TestData.LocalHost;
            user.Port = TestData.ClientPort;
            //user.Code = user.Port.ToString(); ;
            //user.Name = "用户" + user.Host.Substring(user.Host.LastIndexOf(".") + 1);
            ClientC = new ClientService(user);
            ClientC.SetOuter(tb_out);
            ClientC.Listen();
        }

        private void button6_Click(object sender, RoutedEventArgs e)
        {
            //接收方
            UserInfo user = new UserInfo(Guid.NewGuid());
            user.Host = TestData.LocalHost;
            user.Port = TestData.ClientPort+1;
            //user.Code = user.Port.ToString(); ;
            //user.Name = "用户" + user.Host.Substring(user.Host.LastIndexOf(".") + 1);
            ClientR = new ClientService(user);
            ClientR.SetOuter(tb_out);
            ClientR.Listen();
        }
        /// <summary>
        /// 拨号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                //主拨拨号
                ClientC.User.TargetCode = ClientR.User.Code;
                ClientC.CallCommand();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //终止拨号
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ClientC.Close();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            Server.CheckOnline();
        }
    }
}
