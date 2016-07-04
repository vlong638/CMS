using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SocketContactLib.Base;

namespace SocketContactLib.Client
{
    public class CLSClient:CLSClientBase
    {
        #region Fields
        #endregion

        #region Constructors
        public CLSClient(string host, int port, string serverHost, int serverPort)
            : base(host, port, serverHost, serverPort)
        { Init(); }

        public CLSClient(string name, string host, int port, string serverHost, int serverPort)
            : base(name, host, port, serverHost, serverPort)
        { Init(); }

        public CLSClient(UserInfo user)
            : base(user.Name, user.Host, user.Port, user.ServerHost, user.ServerPort)
        { Init(); }
        void Init()
        {
            //OnAudioStarted+=AudioStarted;
            //OnAudioRejected += AudioRejected;
            OnRequestReceived += RequestReceived;
            OnConfirmAccpet += ConfirmAccpet;
            OnConfirmAccpetWhileHandling += ConfirmAcceptWhileHandling;
            OnConfirmCallWhileHandling += ConfirmCallWhileHandling;
            OnTaskExisted += TaskExisted;
        } 
        #endregion
        public void AudioRejected()
        {
            Stop();
        }
        public void AudioStarted()
        {
            Manager.StartRecord();
        }
        public void SetOuter(object obj)
        {
            Log.SetOuter(obj);
        }
        protected void RequestReceived(string callerName)
        {
            CLPush(callerName);
        }
        protected void ConfirmAccpet(string callerName)
        {
            string receiverName = Name;
            Log.WriteLog(string.Format("收到来自{0}的通话请求", callerName));
            string text = string.Format("收到来自{0}的通话请求,点击(确认)接通", callerName);
            DialogResult dResult;
            if (!AutoTest)
            {
                dResult = MessageBox.Show(text, "通话请求", MessageBoxButtons.YesNo);
            }
            else
            {
                dResult = DialogResult.Yes;
            }
            switch (dResult)
            {
                case DialogResult.No:
                    base.RejectRequest(callerName);
                    return;
                case DialogResult.Yes:
                    base.AcceptRequest(callerName);
                    return;
                default:
                    Log.WriteLog("用户确认出现错误");
                    CLPush(callerName, TaskParam._Cancel);
                    return;
            }
        }
        protected void ConfirmAcceptWhileHandling(string callerName)
        {
            string receiverName = Name;
            Log.WriteLog("用户占线 确认是否继续接听");
            string text = "您正在通话中,确认将终止与其他人的通话";
            DialogResult dResult = MessageBox.Show(text, "确认接收", MessageBoxButtons.YesNo);
            switch (dResult)
            {
                case DialogResult.No:
                    base.RejectRequestWhileHandling(callerName);
                    return ;
                case DialogResult.Yes: 
                    base.AcceptRequestWhileHandling(callerName);
                    return ;
                default:
                    Log.WriteLog("用户再确认出现错误");
                    CLPush(callerName, TaskParam._Cancel);
                    return ;
            }
        }
        protected void ConfirmCallWhileHandling(string targetName)
        {
            string receiverName = Name;
            Log.WriteLog("用户占线 确认是否继续拨号");
            string text = "您正在拨号中,确认将终止向其他人的拨号";
            DialogResult dResult = MessageBox.Show(text, "确认拨号", MessageBoxButtons.YesNo);
            switch (dResult)
            {
                case DialogResult.No:
                    base.CancelCallWhileHandling(targetName);
                    return ;
                case DialogResult.Yes:
                    base.ContinueCallWhileHandling(targetName);
                    return ;
                default:
                    Log.WriteLog("用户确认出现错误");
                    CLPush(targetName, TaskParam._Cancel);
                    return ;
            }
        }
        protected void TaskExisted()
        {
            string text = "目标通话已启用";
            DialogResult dResult = MessageBox.Show(text, "已启用", MessageBoxButtons.OK);
        }
    }
}
