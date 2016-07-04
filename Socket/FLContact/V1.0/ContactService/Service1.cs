using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.IO;
using System.Threading;
using SocketContactLib.Server;
using SocketContactLib;

namespace ContactService
{
    public partial class Service1 : ServiceBase
    {
        CLSServer Server;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
#if DEBUG
            Debugger.Launch();
#endif
            ////中转服
            Server = new CLSServer(TestData.ServerHost, TestData.ServerPort);
            Server.Listen();
        }

        //调试服务
        //Timer timer = new Timer(CallbackFunction, null, 0, 5000);
        //void CallbackFunction(object arg)
        //{
        //string path = @"C:\log.txt";
        //string message = "test";
        //using (FileStream stream = File.Open(path, FileMode.Append, FileAccess.Write))
        //{
        //    byte[] bytes = System.Text.Encoding.Default.GetBytes(message.ToString());
        //    stream.Write(bytes, 0, bytes.Length);
        //}
        //////中转服
        //ServerService Server = new ServerService(TestData.ServerHost, TestData.ServerPort);
        ////Server.Listen();
        //}

        protected override void OnStop()
        {
        }
    }
}
