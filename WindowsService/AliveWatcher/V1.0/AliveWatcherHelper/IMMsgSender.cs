using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Net.NetworkInformation;

namespace AliveWatcherHelper
{
    /// <summary>
    /// 通知聊天工具服务端类
    /// </summary>
    public class IMMsgSender
    {
        Socket so;
        IPEndPoint server;
        /// <summary>
        /// 构造函数
        /// </summary>
        public IMMsgSender()
        {
            so = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server = new IPEndPoint(IPAddress.Parse("192.168.2.122"), 8100);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">聊天工具服务器IP</param>
        public IMMsgSender(string ip)
            : this()
        {
            IPAddress[] ipAddServer = Dns.GetHostAddresses(ip);
            server = new IPEndPoint(ipAddServer[0], 8100);
        }

        /// <summary>
        /// 向聊天工具发送扩展信息
        /// </summary>
        /// <param name="msgId">扩展功能标识ID</param>
        /// <param name="account">通知用户</param>
        /// <param name="args">扩展功能需要的参数</param>
        /// <returns>true发送成功，false发送失败</returns>
        public bool SendApprove(string msgId, string account, string[] args)
        {
            string msg = "0APV:" + msgId + ":" + account;
            foreach (string arg in args)
            {
                msg += ":" + arg;
            }
            try
            {
                so.Connect(server);
                so.Send(Encoding.Unicode.GetBytes(msg));
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 向聊天工具发送管理平台中的人事审批提示信息
        /// </summary>
        /// <param name="msgId">扩展功能标识ID</param>
        /// <param name="account">通知用户</param>
        /// <param name="args">扩展功能需要的参数</param>
        /// <returns>true发送成功，false发送失败</returns>
        public bool SendPersonnelApprove(string msgId, string account, string[] args)
        {
            string msg = "0PAP:" + msgId + ":" + account;
            foreach (string arg in args)
            {
                msg += ":" + arg;
            }

            try
            {
                so.Connect(server);
                so.Send(Encoding.Unicode.GetBytes(msg));
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 向聊天工具发送管理平台中的人事提示信息
        /// </summary>
        /// <param name="msgId">扩展功能标识ID</param>
        /// <param name="account">通知用户</param>
        /// <param name="args">扩展功能需要的参数</param>
        /// <returns>true发送成功，false发送失败</returns>
        public bool SendPersonnelMsg(string msgId, string account, string args)
        {
            string msg = "0PMS:" + msgId + ":" + account + ":" + args;

            try
            {
                so.Connect(server);
                so.Send(Encoding.Unicode.GetBytes(msg));
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 向聊天工具发送管理平台中的人事提示信息
        /// </summary>
        /// <param name="msgId">扩展功能标识ID</param>
        /// <param name="account">通知用户</param>
        /// <param name="args">扩展功能需要的参数</param>
        /// <returns>true发送成功，false发送失败</returns>
        public bool SendPersonnelGroupMsg(string msgId, string account, string args)
        {
            string msg = "0GMS:" + msgId + ":" + account + ":" + args;

            try
            {
                so.Connect(server);
                so.Send(Encoding.Unicode.GetBytes(msg));
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// OperationType
        /// </summary>
        public enum OperationType
        {
            Update = 0,
            Add = 1,
            Delete = 2
        }
    }
}
