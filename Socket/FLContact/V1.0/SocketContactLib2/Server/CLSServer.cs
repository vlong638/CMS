using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using SocketContactLib.Base;
using System.Threading.Tasks;
using System.Threading;

namespace SocketContactLib.Server
{
    /// <summary>
    /// C Client(Call)
    /// L Client(Listen)
    /// S Server(Listen)
    /// </summary>
    public class CLSServer : ListenBase
    {

        #region Constructors
        public CLSServer(string host, int port)
            : base(host, port)
        {
            
        }
        #endregion

        #region Methods
        public void SetOuter(object obj)
        {
            Log.SetOuter(obj);
        }
        //服务器响应请求
        protected override void HandleRequest(Socket clientC)
        {
            //UserInfo caller = null, receiver = null;
            //用户主拨请求 反馈请求分支
            switch (ReceiveCommand(clientC))
            {
                case RequestCommandsEnum.RejectCommand:
                case RequestCommandsEnum.AcceptCommand:
                case RequestCommandsEnum.Error:
                default:
                    SendCommandText(clientC, RequestCommandsEnum.Error);
                    clientC.Close();
                    //不明CloseConnection(clientC);
                    break;
                case RequestCommandsEnum.CallCommand:
                    string text = ReceiveText(clientC);
                    string[] args = text.Split(',');
                    string callerName = args[0];
                    string targetName = args[1];
                    var callerInfo = TestData.UserList.FirstOrDefault(p => p.Name == callerName);
                    var targetInfo = TestData.UserList.FirstOrDefault(p => p.Name == targetName);
                    if (callerInfo == null || targetInfo == null)
                    {
                        SendCommandText(clientC, RequestCommandsEnum.Error);
                        Log.WriteLog("存在无效对象");
                        clientC.Close();
                        //不明CloseConnection(clientC);
                    }
                    else
                    {
                        //双方在线 尝试接通受方
                        IPAddress ip = IPAddress.Parse(targetInfo.Host);
                        IPEndPoint iped = new IPEndPoint(ip, targetInfo.Port);
                        Socket clientR = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        try
                        {
                            clientR.Connect(iped);
                        }
                        catch(Exception ex)
                        {
                            Log.WriteLog("目标{0}连接失败", targetName);
                            Log.WriteLog("服务器终止通话");
                            SendCommandText(clientC, RequestCommandsEnum.Error);
                            clientC.Close();
                            return;
                        }
                        //发送拨方请求和拨方消息
                        SendCommandText(clientR, RequestCommandsEnum.CallCommand, callerInfo.Name);
                        Log.WriteLog("服务器请求接通被拨方");

                        //clientC.ReceiveTimeout = clientR.ReceiveTimeout = 500;
                        bool isSettled = false;
                        while (!isSettled)
                        {
                            if (CheckConnection(clientR))
                            {
                                switch (ReceiveCommand(clientR))
                                {
                                    case RequestCommandsEnum.Default:
                                        SendCommandText(clientC, RequestCommandsEnum.Default);
                                        Thread.Sleep(100);
                                        break;
                                    case RequestCommandsEnum.Error:
                                    case RequestCommandsEnum.CallCommand:
                                    case RequestCommandsEnum.CancelCommand:
                                        clientR.Close();
                                        SendCommandText(clientC, RequestCommandsEnum.Error);
                                        clientC.Close();
                                        break;
                                    case RequestCommandsEnum.RejectCommand:
                                        clientR.Close();
                                        SendCommandText(clientC, RequestCommandsEnum.RejectCommand);
                                        clientC.Close();
                                        break;
                                    case RequestCommandsEnum.AcceptCommand:
                                        SendCommandText(clientC, RequestCommandsEnum.AcceptCommand);
                                        Connection connection = new Connection(clientC, clientR);
                                        connection.SetParent(this);
                                        connection.StartTransfer();
                                        Log.WriteLog("通信已接通");
                                        isSettled = true;
                                        break;
                                }
                            }
                            else
                            {
                                clientR.Close();
                                clientC.Close();
                                isSettled = true;
                                break;
                            }
                            if (!isSettled&&CheckConnection(clientC))
                            {
                                switch (ReceiveCommand(clientC))
                                {
                                    case RequestCommandsEnum.Default:
                                        SendCommandText(clientR, RequestCommandsEnum.Default);
                                        Thread.Sleep(100);
                                        break;
                                    case RequestCommandsEnum.Error:
                                    case RequestCommandsEnum.CallCommand:
                                    case RequestCommandsEnum.RejectCommand:
                                    case RequestCommandsEnum.AcceptCommand:
                                        clientC.Close();
                                        SendCommandText(clientR, RequestCommandsEnum.Error);
                                        clientR.Close();
                                        break;
                                    case RequestCommandsEnum.CancelCommand:
                                        clientC.Close();
                                        SendCommandText(clientR, RequestCommandsEnum.CancelCommand);
                                        clientR.Close();
                                        break;
                                }
                            }
                        }
                    }
                    break;
            }
        }
        #endregion

        #region Events
        public event EventHandler OnRequestReceived = new EventHandler(() => { });
        public event EventHandler OnTargetConnected = new EventHandler(() => { });
        public event EventHandler OnConnectionSetup = new EventHandler(() => { });
        public event EventHandler OnConnectionFailed = new EventHandler(() => { });
        #endregion

    }
}
