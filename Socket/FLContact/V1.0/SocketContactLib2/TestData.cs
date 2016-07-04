using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace SocketContactLib
{
    public class TestData
    {
        public static string ServerHost = "192.168.2.169";
        public static int ServerPort = 6000;

        public static int ClientPort = 6001;
        public static string LocalHost
        {
            get
            {
                if (string.IsNullOrEmpty(_localHost))
                {
                    _localHost = GetLocalIP();
                }
                return _localHost;
            }
        }
        private static string _localHost;
        private static string GetLocalIP()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] ips = Dns.GetHostAddresses(hostName);
            foreach (IPAddress ip in ips)
            {
                if (ip.ToString().IndexOf("192") >= 0)
                {
                    return ip.ToString();
                }
            }
            return "";
        }

        /// <summary>
        /// 拟数据库
        /// </summary>
        /// Client启用时连接服务器并更新IP
        /// 客户端+心跳帧=>客户开关机状态
        /// Call=>服务器验证拨方和受方 根据受方状态
        /// 请求受方 或 直接反馈拨方
        public static List<UserInfo> UserList = new List<UserInfo>()
        {
            //公用机1(user1)
            //公用机2(user2)
            //研一专用1(user10)
            //研一专用2(user11)
            new UserInfo("公用机1(user1)",1111),
            new UserInfo("公用机2(user2)",1112),
            new UserInfo("C3",1113),
            new UserInfo("C4",1114),
            new UserInfo("C5",1115),
            new UserInfo("周婷婷(tina_071)",8099),
            new UserInfo("GG1","192.168.1.122",8888),
            new UserInfo("夏锦慧(xjh_169)","192.168.2.122",8099),
            new UserInfo("李伟(lw_011)","192.168.2.122",8099)
            
            //new UserInfo(new Guid("9281FAB1-47C5-4475-98FC-022590E661F6"),"User1"){Host="192.168.2.169",Port=6000},
            //new UserInfo(new Guid("ECD21032-522F-4C52-87B1-81F6457D9251"),"User2"){Code="E1",Host="192.168.2.169",Port=6001},
            //new UserInfo(new Guid("AA6C9A0D-8001-4F2A-9263-E1A0C2AC1616"),"User3"){Code="E2",Host="192.168.2.169",Port=6001},
            //new UserInfo(new Guid("6641834A-3914-479A-A562-17EB694A61C4"),"User4"){Code="E3",Host="192.168.2.169",Port=6001},  
            //new UserInfo(new Guid("ECD21032-522F-4C52-87B1-81F6457D9252"),"User5"){Code="E4",Host="192.168.2.169",Port=6001,State=UserState.Busy},
            //new UserInfo(new Guid("AA6C9A0D-8001-4F2A-9263-E1A0C2AC1612"),"User6"){Code="ECD5",Host="192.168.2.169",Port=6001,State=UserState.Engaged},
            //new UserInfo(new Guid("6641834A-3914-479A-A562-17EB694A61C2"),"User7"){Code="ECD6",Host="192.168.2.169",Port=6001,State=UserState.Off},        };
        };
    }

    public class UserInfo
    {
        public UserInfo(string name,int port)
        {
            Name = name;
            Port = port;
        }
        public UserInfo(string name,string host,int port)
        {
            Name = name;
            Host = host;
            Port = port;
        }

        public string Name { get; set; }
        public string Host = TestData.LocalHost;
        public int Port { get; set; }
        public string ServerHost = TestData.ServerHost;
        public int ServerPort = TestData.ServerPort;
    }
}
