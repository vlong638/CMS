//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Net.Sockets;
//using System.Net;
//using SocketContactLib.Base;

//namespace SocketContactLib.Server
//{
//    public class FLServer : ListenBase
//    {
//        #region Constructors
//        public FLServer(string host, int port)
//            : base(host, port)
//        {
//        }
//        #endregion

//        #region Methods
//        //服务器响应请求
//        protected override void HandleRequest(Socket clientC)
//        {

//            //UserInfo caller = null, receiver = null;
//            //用户主拨请求 反馈请求分支
//            switch (ReceiveCommand(clientC))
//            {
//                case RequestCommandsEnum.RejectCommand:
//                case RequestCommandsEnum.AcceptCommand:
//                case RequestCommandsEnum.Error:
//                default:
//                    SendCommandText(clientC, RequestCommandsEnum.Error);
//                    CloseConnection(clientC);
//                    break;
//                case RequestCommandsEnum.CallCommand:
//                    string text = ReceiveText(clientC);
//                    string[] names = text.Split(',');
//                    string callerName = names[0];
//                    string targetName = names[1];
//                    var caller = TestData.UserList.FirstOrDefault(p => p.Name == callerName);
//                    var receiver = TestData.UserList.FirstOrDefault(p => p.Name == targetName);
//                    if (caller == null || receiver == null)
//                    {
//                        SendCommandText(clientC, RequestCommandsEnum.Error);
//                        Log.WriteLog("存在无效对象");
//                        CloseConnection(clientC);
//                    }
//                    else
//                    {
//                        //双方在线 尝试接通受方
//                        IPAddress ip = IPAddress.Parse(TestData.LocalHost);
//                        IPEndPoint iped = new IPEndPoint(ip, receiver.Port);
//                        Socket clientR = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//                        clientR.Connect(iped);
//                        //发送拨方请求和拨方消息
//                        SendCommandText(clientR, RequestCommandsEnum.CallCommand, caller.Name);
//                        Log.WriteLog("服务器请求接通被拨方");
//                        //接收反馈
//                        switch (ReceiveCommand(clientR))
//                        {
//                            case RequestCommandsEnum.Error:
//                                clientR.Close();
//                                SendCommandText(clientC, RequestCommandsEnum.Error);
//                                clientC.Close();
//                                break;
//                            case RequestCommandsEnum.RejectCommand:
//                                clientR.Close();
//                                SendCommandText(clientC, RequestCommandsEnum.RejectCommand);
//                                clientC.Close();
//                                break;
//                            case RequestCommandsEnum.AcceptCommand:
//                                SendCommandText(clientC, RequestCommandsEnum.AcceptCommand);
//                                Connection connection = new Connection(clientC, clientR);
//                                connection.SetParent(this);
//                                connection.StartTransfer();
//                                Log.WriteLog("通信已接通");
//                                break;
//                        }
//                    }
//                    break;
//            }
//        }
//        #endregion

//        #region Events
//        public event EventHandler OnRequestAccepted = new EventHandler(() => { });
//        public event EventHandler OnTargetConnected = new EventHandler(() => { });
//        public event EventHandler OnConnectionSetup = new EventHandler(() => { });
//        #endregion

//    }
//}
