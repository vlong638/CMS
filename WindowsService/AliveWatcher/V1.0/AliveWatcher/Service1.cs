using System.ServiceProcess;
using AliveWatcherHelper;
using System.Windows.Forms;
using System.Threading;
using System.Xml.Linq;

namespace AliveWatcher
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                string Path = Application.StartupPath + @"\TargetList.xml";
                XDocument doc = XDocument.Load(Path);
                int minutes = int.Parse(doc.Element("ErrorInform").Attribute("Interval").Value);
                int interval = 1000 * 60 * minutes;
                //配置日志输出
                string path = System.IO.Path.Combine(Application.StartupPath, "log.txt");
                WatcherHelper.SetLogPath(path);
                WatcherHelper.SetLogOuter(OuterType.Consolo);
                WatcherHelper.WriteLog("监控服务已启用,检查间隔" + minutes.ToString() + "分钟");
                //开始定时检查

                //使用System.Timers.Timer 
                System.Timers.Timer tm = new System.Timers.Timer(interval);
                tm.Elapsed += new System.Timers.ElapsedEventHandler(tm_Elapsed);
                tm.Start();
                tm.Enabled = true;

                ////使用System.Threading.Timer 只执行一次?
                //TimerCallback tcb = new TimerCallback((object state) =>
                //{
                //    //检查服务
                //    WatcherHelper.WriteLog("\r\n启用检查,执行时间:" + System.DateTime.Now.ToString());
                //    WatcherHelper.CheckService();
                //});
                //System.Threading.Timer timer = new System.Threading.Timer(tcb, null, 0, interval);
            }
            catch (System.Exception ex)
            {
                WatcherHelper.WriteLog("监控服务启用失败");
                WatcherHelper.WriteLog(ex.ToString());
            }
        }

        void tm_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //检查服务
            WatcherHelper.WriteLog("\r\n启用检查,执行时间:" + System.DateTime.Now.ToString());
            WatcherHelper.CheckService();
        }

        protected override void OnStop()
        {
            WatcherHelper.WriteLog("监控服务已关闭");
        }
    }
}
