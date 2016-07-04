using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AliveWatcherHelper
{
    public class MsgSenderHelper
    {
        public static string MsgServerIP;
        static MsgSenderHelper()
        {
            if (string.IsNullOrEmpty(MsgServerIP))
            {
                //MsgServerIP = System.Configuration.ConfigurationManager.AppSettings["MMsgServerIP"];
                //MsgServerIP = "192.168.2.100";
                MsgServerIP = "192.168.2.122";
            }
        }

        /// <summary>
        /// Send Approve
        /// </summary>
        /// <param name="msgId"></param>
        /// <param name="account"></param>
        /// <param name="args"></param>
        /// <param name="MsgServerIP"></param>
        /// <returns></returns>
        public static bool SendApprove(string msgId, string account, string[] args)
        {
            IMMsgSender send = new IMMsgSender(MsgServerIP);
            return send.SendApprove(msgId, account, args);
            //bool ret = false;
            //try
            //{
            //    if (!string.IsNullOrEmpty(MsgServerIP))
            //    {
            //        IMMsgSender send = new IMMsgSender(MsgServerIP);
            //        ret = send.SendApprove(msgId, account, args);
            //    }
            //}
            //catch (Exception e)
            //{
            //    ret = false;
            //    LogHelper.Write(e.Message);
            //}
            //return ret;
        }

        /// <summary>
        /// 异步发送聊天工具消息（个人工作平台-待办事宜）。
        /// </summary>
        /// <param name="accounts">要提醒的人员帐户（多人以逗号分隔）</param>
        /// <param name="content">提醒的信息</param>
        /// <param name="data">与模块相关的数据（没有不填(输入null)）</param>
        /// <returns></returns>
        public static bool SendMessageAsyn(string accounts, string content, string data, bool isStartMuerpUI = true)
        {
            Message msg = new Message
            {
                Accounts = accounts,
                Content = content,
                Args = data,
                IsNeedStartMuerpUI = isStartMuerpUI,
            };
            return ThreadPool.QueueUserWorkItem(SendMessageAction, msg);
        }
        /// <summary>
        /// 线程池待执行发送消息函数。
        /// </summary>
        /// <param name="arg">待发送消息。</param>
        static void SendMessageAction(object arg)
        {
            Message message = arg as Message;
            if (message == null) return;

            MsgSenderHelper.SendApprove(message.MsgId, message.Accounts, new[]
            {
                message.SystemName,
                message.ModuleName,
                message.Uri,
                message.Args,
                message.Accounts,
                message.IsNeedStartMuerpUI ? "1"　: "0",
                message.Content
            });
        }

        /// <summary>
        /// 待发送消息。
        /// </summary>
        class Message
        {
            public Message()
            {
                MsgId = "xx线程检测MsgID";
                SystemName = "xx线程检测SystemName";
                ModuleName = "线程检测ModuleName";
                Uri = "";
            }

            /// <summary>
            /// 获取或设置聊天工具可处理的消息id。
            /// </summary>
            public string MsgId { get; set; }
            /// <summary>
            /// 获取或设置系统名称。
            /// </summary>
            public string SystemName { get; set; }
            /// <summary>
            /// 获取或设置模块名称。
            /// </summary>
            public string ModuleName { get; set; }
            /// <summary>
            /// 获取或设置模块地址。
            /// </summary>
            public string Uri { get; set; }
            /// <summary>
            /// 获取或设置参数。
            /// </summary>
            public string Args { get; set; }
            /// <summary>
            /// 获取或设置接收人（多人以逗号分隔）。
            /// </summary>
            public string Accounts { get; set; }
            /// <summary>
            /// 获取或设置是否需要启动内部管理系统。
            /// </summary>
            public bool IsNeedStartMuerpUI { get; set; }
            /// <summary>
            /// 获取或设置内容。
            /// </summary>
            public string Content { get; set; }
        }

        /// <summary>
        /// 给聊天工具发送提示信息
        /// </summary>
        /// <param name="systemName">系统名称</param>
        /// <param name="modelName">模块名称</param>
        /// <param name="uri">模块地址（一般不需要填写（输入null））</param>
        /// <param name="data">与模块相关的数据（没有不填(输入null)）</param>
        /// <param name="accounts">要提醒的人员帐户（多人以逗号分隔）</param>
        /// <param name="message">提醒的信息</param>
        /// <param name="type">消息显示类型（0：不启动管理平台，1：启动管理平台）</param>
        /// <returns></returns>
        public static bool SendMessage(string systemName, string modelName, string uri, object data, string accounts, string message, int type, string msgID)
        {
            string[] tem = new string[7];
            tem[0] = systemName;
            tem[1] = modelName;
            tem[2] = uri;
            tem[3] = data + "";
            tem[4] = accounts;
            tem[5] = type + "";
            tem[6] = string.Format(message);
            return MsgSenderHelper.SendApprove(msgID, accounts, tem);
        }

        /// <summary>
        /// 发送人事提示信息
        /// </summary>
        /// <param name="msgId">提示标题</param>
        /// <param name="account">提示用户</param>
        /// <param name="args">提示信息</param>
        /// <returns></returns>
        public static bool SendPersonnelGroupMsg(string msgId, string msgs)
        {
            bool ret = false;
            try
            {
                IMMsgSender send = new IMMsgSender(MsgServerIP);
                return send.SendPersonnelGroupMsg(msgId, "admin", msgs);
            }
            catch (Exception e)
            {
                ret = false;
                //LogHelper.Write(e.Message, LogMessageType.Error);
            }
            return ret;
        }

        /// <summary>
        /// 发送人事提示信息
        /// </summary>
        /// <param name="msgId">提示标题</param>
        /// <param name="account">提示用户</param>
        /// <param name="args">提示信息</param>
        /// <returns></returns>
        public static bool SendPersonnelMsg(string msgId, string account, string msgs)
        {
            bool ret = false;
            try
            {
                IMMsgSender send = new IMMsgSender(MsgServerIP);
                ret = send.SendPersonnelMsg(msgId, account, msgs);
            }
            catch (Exception e)
            {
                ret = false;
                //LogHelper.Write(e.Message, LogMessageType.Error);
            }
            return ret;
        }

    }
}
