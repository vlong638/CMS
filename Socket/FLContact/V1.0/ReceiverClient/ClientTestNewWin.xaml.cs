using System;
using System.Windows;
using SocketContactLib;
using SocketContactLib.Server;
using SocketContactLib.Client;
using System.Threading.Tasks;
using System.Threading;

namespace ReceiverClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ClientTestNewWin : Window
    {

        public ClientTestNewWin()
        {
            InitializeComponent();
        }

        public string ContactState
        {
            get { return (string)GetValue(ContactStateProperty); }
            set { SetValue(ContactStateProperty, value); }
        }

        public static readonly DependencyProperty ContactStateProperty =
            DependencyProperty.Register("ContactState", typeof(string), typeof(ClientTestNewWin), new FrameworkPropertyMetadata(OnContactStatePropertyChanged));

        private static void OnContactStatePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ClientTestNewWin control = sender as ClientTestNewWin;
            control.tb_out.Text += "  " + e.NewValue.ToString();
        }

        CLSServer Server;
        CLSClient ClientC;
        CLSClient ClientR;
        //服务器端启用
        //中转服
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Server = new CLSServer(TestData.ServerHost, TestData.ServerPort);
            Server.UpdatePath(@"C:\MyLog.txt");
            Server.SetOuter(tb_out);
            Server.Listen();
        }
        //客户C启用
        //主拨方
        private void button5_Click(object sender, RoutedEventArgs e)
        {
            UserInfo user = TestData.UserList[0];
            ClientC = new CLSClient(user);
            ClientC.UpdatePath(@"C:\MyLog.txt");
            ClientC.SetOuter(tb_out);
            ClientC.Listen();
            ClientC.OnStartRecord += (string s) =>
            {
                ThreadStart ts = new ThreadStart(ClientC.Manager.StartRecord);
                this.Dispatcher.Invoke(ts);
            };
        }
        //客户R启用
        //受拨方
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            UserInfo target = TestData.UserList[1];
            ClientR = new CLSClient(target);
            ClientR.UpdatePath(@"C:\MyLog.txt");
            ClientR.SetOuter(tb_out);
            ClientR.Listen();
            ClientR.OnStartRecord += (string s) =>
            {
                ThreadStart ts = new ThreadStart(ClientR.Manager.StartRecord);
                this.Dispatcher.Invoke(ts);
            };
        }
        // 拨号 C=>R
        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                UserInfo target = TestData.UserList[1];
                ThreadStart ts = new ThreadStart(() =>
                {
                    //用户主拨
                    ClientC.Call(target.Name);
                });
                Thread t = new Thread(ts);
                t.Start();
                //ClientC.Call(target.Name);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 用户C模拟拨号飞联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserInfo target = TestData.UserList[5];
                ThreadStart ts = new ThreadStart(() =>
                {
                    ClientC.Call(target.Name);
                });
                Thread t = new Thread(ts);
                t.Start();

                //ClientC.Call(target.Name);
                //Log.WriteLog(Thread.CurrentThread.ManagedThreadId.ToString());
                //ThreadStart ts = new ThreadStart(() =>
                //{
                //    ClientC.Call(target.Name);
                //});
                //Thread t = new Thread(ts);
                //t.Start();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 用户C模拟拨号飞联8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserInfo target = TestData.UserList[8];
                ThreadStart ts = new ThreadStart(() =>
                {
                    ClientC.Call(target.Name);
                });
                Thread t = new Thread(ts);
                t.Start();
            }
            catch 
            {
                throw;
            }
        }
        /// <summary>
        /// 用户R模拟拨号飞联
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserInfo target = TestData.UserList[5];
                Task.Factory.StartNew(() => ClientR.Call(target.Name));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /// <summary>
        /// 用户C模拟拨号G
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserInfo target = TestData.UserList[6];
                Task.Factory.StartNew(() => ClientC.Call(target.Name));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        //受拨G
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            UserInfo user = TestData.UserList[6];
            ClientC = new CLSClient(user);
            ClientC.UpdatePath(@"C:\MyLog.txt");
            ClientC.SetOuter(tb_out);
            ClientC.AutoTest = true;
            ClientC.Listen();
        }
        //取消通话
        private void button9_Click(object sender, RoutedEventArgs e)
        {
            ClientC.Stop();
        }
    }
}
