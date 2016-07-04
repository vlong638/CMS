using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SocketContactLib.Client
{
    public class FLClient : CLSClientBase
    {
        public FLClient(string host, int port, string serverHost, int serverPort)
            : base(host, port, serverHost, serverPort)
        {
            Init();
        }
        public FLClient(string name, string host, int port, string serverHost, int serverPort)
            : base(name, host, port, serverHost, serverPort)
        {
            Init();
        }
        void Init()
        {
            OnRequestReceived += RequestReceived;
            OnConfirmCallWhileHandling += ConfirmCallWhileHandling;
            OnConfirmAccpetWhileHandling += ConfirmAcceptWhileHandling;
            OnTaskExisted += TaskExisted;
        }

        protected void RequestReceived(string callerName)
        {
            CLPush(callerName);
        }
        public new bool AcceptRequest(string callerName)
        {
            return base.AcceptRequest(callerName);
        }
        public new bool RejectRequest(string callerName)
        {
            return base.RejectRequest(callerName);
        }
        public new bool AcceptRequestWhileHandling(string callerName)
        {
            return base.AcceptRequestWhileHandling(callerName);
        }
        public new bool RejectRequestWhileHandling(string callerName)
        {
            return base.RejectRequestWhileHandling(callerName);
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
                    return;
                case DialogResult.Yes:
                    base.AcceptRequestWhileHandling(callerName);
                    return;
                default:
                    Log.WriteLog("用户再确认出现错误");
                    CLPush(callerName, TaskParam._Cancel);
                    return;
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
