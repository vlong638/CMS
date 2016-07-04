using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using SocketContactLib.Base;

namespace SocketContactLib.Client
{
    /// <summary>
    /// 客户基类
    /// </summary>
    public abstract class CLSClientBase : ListenBase
    {
        public bool AutoTest = false;

        #region Fields
        private Socket _targetClient;
        public AudioManager Manager;
        public int ServerPort;
        public string ServerHost;
        #endregion

        #region Properties
        /// <summary>
        /// 连接对象名称
        /// </summary>
        public string TargetName { set; get; }
        /// <summary>
        /// 拨号对象
        /// </summary>
        public Socket TargetClient
        {
            get { return _targetClient; }
            set { _targetClient = value; }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string Name { set; get; }
        /// <summary>
        /// 是否是主拨
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// 是否在通话状态
        /// </summary>
        public bool IsOnContact
        {
            get { return CheckConnection(TargetClient); }
        }
        /// <summary>
        /// 待处理Socket列表
        /// </summary>
        public static Dictionary<string, Socket> WaitList = new Dictionary<string, Socket>();
        private static object WaitListLock = new object();
        /// <summary>
        /// 待处理指令列表
        /// </summary>
        public static List<string> CommandList = new List<string>();
        private static object CommandLock = new object();
        #endregion

        #region Constructors
        public CLSClientBase(string host, int port, string serverHost, int serverPort)
            : base(host, port)
        {
            Log.IsClient = true;
            Manager = new AudioManager() { Parent = this };
            ServerHost = serverHost;
            ServerPort = serverPort;
        }
        public CLSClientBase(string name, string host, int port, string serverHost, int serverPort)
            : base(host, port)
        {
            Name = name;
            Log.IsClient = true;
            Manager = new AudioManager() { Parent = this };
            ServerHost = serverHost;
            ServerPort = serverPort;
        }
        //protected ~ClientBase()
        //{
        //    //或需要对语音部分进行关闭处理
        //    //StopAudio();
        //}
        #endregion

        #region Methods

        #region 帮助功能
        /// <summary>
        /// 是否存在通话请求或当前通话
        /// 0:无连接;1：有其他连接;-1已有相同的拨号请求
        /// </summary>
        protected int IsOtherCallExist(string callerName)
        {
            if (WaitList.Count == 0 && !CheckConnection(TargetClient))
            {
                return 0;
            }
            else if (WaitList.Count == 0 && CheckConnection(TargetClient) && TargetName == callerName)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
        //清理其他通讯(通话请求或当前通话)
        protected void ClearOtherCall()
        {
            if (WaitList.Count != 0)
            {
                foreach (var waitItem in WaitList)
                {
                    RejectRequest(waitItem.Key);
                }
            }
            if (CheckConnection(TargetClient))
            {
                Stop();
            }
        }
        /// <summary>
        /// 检查请求是否已取消
        /// </summary>
        /// <param name="targetName">请求方的标识名</param>
        /// <returns>等待序列和是否连接</returns>
        protected bool WLCheckExist(string targetName)
        {
            lock (WaitListLock)
            {
                if (!WaitList.ContainsKey(targetName))
                {
                    Log.WriteLog("对象已移出等待序列");
                    return false;
                }
                bool isExist = true;
                Socket client = WaitList.FirstOrDefault(c => c.Key == targetName).Value;
                isExist = CheckConnection(client);
                if (!isExist)
                {
                    OnRequestReceivedCanceled(targetName);
                    WaitList.Remove(targetName);
                    CloseConnection(client);
                }
                return isExist;
            }
        }
        /// <summary>
        /// 弹出连接
        /// </summary>
        /// <param name="callerName"></param>
        /// <returns></returns>
        protected Socket WLPop(string callerName)
        {
            lock (WaitListLock)
            {
                Socket client = WaitList.FirstOrDefault(c => c.Key == callerName).Value;
                WaitList.Remove(callerName);
                return client;
            }
        }
        /// <summary>
        /// 获取连接
        /// </summary>
        /// <param name="callerName"></param>
        /// <returns></returns>
        protected Socket WLGet(string callerName)
        {
            lock (WaitListLock)
            {
                Socket client = WaitList.FirstOrDefault(c => c.Key == callerName).Value;
                return client;
            }
        }
        /// <summary>
        /// 通讯中断是否关闭对象
        /// </summary>
        /// <param name="isActive">主动关闭</param>
        public void CloseTargetConnection()
        {
            if (TargetClient == null)
                return;

            //vlong638 正在通讯中断 通讯中断事件对应sender触发 
            CloseConnection(TargetClient, true);
            TargetClient = null;
            TargetName = null;
        }
        /// <summary>
        /// 关闭目标拨号
        /// </summary>
        public void CloseTargetCall()
        {
            //vlong638 正在通讯中断 通讯中断事件对应sender触发 
            if (TargetClient == null)
                return;
            //拨方关闭指令
            SendCommandText(TargetClient, RequestCommandsEnum.CancelCommand);
            //关闭连接
            CloseTargetConnection();
        }
        #endregion

        #region 监听
        /// <summary>
        /// 接收请求
        /// </summary>
        /// <param name="listener"></param>
        protected sealed override void HandleRequest(Socket client)
        {
            if (ReceiveCommand(client) == RequestCommandsEnum.CallCommand)
            {
                string callerName = ReceiveText(client, client.Available);
                if (string.IsNullOrEmpty(callerName))
                    return;

                if (WaitList.ContainsKey(callerName))
                {
                    Log.WriteLog("已收到同名请求");
                    CloseConnection(client);
                    return;
                }

                //存储接入请求
                WaitList.Add(callerName, client);
                //外部UI接口
                OnRequestReceived(callerName);
                //每秒检查其是否已可继续执行或已取消
                while (WLCheckExist(callerName) && !CLPop(callerName))
                {
                    Thread.Sleep(100);
                };
                //处理接入请求
                HandleReceivedRequest(callerName);
            }
            else
            {
                CloseConnection(client);
            }
        }
        /// <summary>
        /// 处理已接收的请求
        /// </summary>
        /// <param name="callerName">用户名 用以确定对应Socket</param>
        protected void HandleReceivedRequest(string callerName)
        {
            Socket client = WLGet(callerName);
            SendCommandText(client, RequestCommandsEnum.Default);
            //是否已确认
            bool isConfirmed = false;
            //Confirm功能外部接口
            OnConfirmAccpet(callerName);
            //检查任务是否已取消
            while (WLCheckExist(callerName))
            {
                switch (ReceiveCommand(client))
                {
                    case RequestCommandsEnum.Default:
                        //检查任务是否可以继续执行
                        if (CLPop(callerName + TaskParam._Submit))
                        {
                            if (!CheckConnection(TargetClient))
                            {
                                //无通话
                                TargetClient = WLPop(callerName);
                                Log.WriteLog("用户{0}接收通话请求", Name);
                                SendCommandText(client, RequestCommandsEnum.AcceptCommand);
                                StartAudio(client, callerName, false);
                            }
                            else
                            {
                                //已有通话
                                if (!isConfirmed)
                                {
                                    //未确认继续
                                    isConfirmed = true;
                                    OnConfirmAccpetWhileHandling(callerName);
                                    SendCommandText(client, RequestCommandsEnum.Default);
                                    continue;
                                }
                                else
                                {
                                    //已确认继续
                                    //关闭通话
                                    StopAudio();
                                    while (CheckConnection(TargetClient) && Manager.Stopped == true)
                                    {
                                        Thread.Sleep(500);
                                    }
                                    //启用新通讯
                                    WLPop(callerName);
                                    Log.WriteLog("用户{0}接收通话请求", Name);
                                    SendCommandText(client, RequestCommandsEnum.AcceptCommand);
                                    StartAudio(client, callerName, false);
                                }
                            }
                        }
                        else if (CLPop(callerName + TaskParam._Cancel))
                        {
                            WLPop(callerName);
                            Log.WriteLog("用户{0}拒绝通话请求", Name);
                            SendCommandText(client, RequestCommandsEnum.RejectCommand);
                            CloseConnection(client);
                            OnRequestReceivedRejected(callerName);
                        }
                        else
                        {
                            SendCommandText(client, RequestCommandsEnum.Default);
                        }
                        break;
                    case RequestCommandsEnum.CancelCommand:
                        Log.WriteLog("对方用户{0}取消通话请求", callerName);
                        //清理任务和指令
                        WLPop(callerName);
                        CLRemoveRange(callerName);
                        CloseConnection(client, true);
                        OnRequestReceivedCanceled(callerName);
                        break;
                    case RequestCommandsEnum.Error:
                    case RequestCommandsEnum.CallCommand:
                    case RequestCommandsEnum.RejectCommand:
                    case RequestCommandsEnum.AcceptCommand:
                        Log.WriteLog("信号异常", Name);
                        //清理任务和指令
                        WLPop(callerName);
                        CLRemoveRange(callerName);
                        CloseConnection(client, true);
                        OnRequestReceivedError(callerName);
                        break;
                }
            }
        }
        #endregion

        #region 主拨
        /// <summary>
        /// 启用拨号
        /// </summary>
        public void Call(string targetName)
        {
            //主拨检查
            int result = IsOtherCallExist(targetName);
            if (result == -1)
            {
                //当前拨号已存在
                OnTaskExisted();
                return;
            }
            else if (result == 1)
            {
                Log.WriteLog("已存在主拨请求");
                OnConfirmCallWhileHandling(targetName);
                //检查任务是否已取消
                while (TargetClient != null)
                {
                    //检查任务是否可以继续执行
                    if (CLPop(targetName + TaskParam._Submit))
                    {
                        //清理其他任务
                        ClearOtherCall();
                        //检查其他任务是否已清理
                        int timeS = 1;
                        int timeE = 4;
                        while (timeS < timeE)
                        {
                            Thread.Sleep(500);
                            if (IsOtherCallExist(targetName) == 0)
                            {
                                break;
                            }
                            timeS++;
                            if (timeS == timeE)
                            {
                                OnTaskClearFailed();
                                return;
                            }
                        }
                        break;
                    }
                    else if (CLPop(targetName + TaskParam._Cancel))
                    {
                        return;
                    }
                    else
                    {
                        Thread.Sleep(200);
                    }
                }
            }
            //请求服务器
            Socket server = Connect(ServerHost, ServerPort);
            if (!CheckConnection(server))
                return;//连接失败错误

            //主动拨号请求
            TargetClient = server;
            TargetName = targetName;
            Log.WriteLog("客户{0}启用拨号对象:{1}", Name, targetName);
            string text = string.Format(RequestConstants.CallPattern, Name, targetName);
            SendCommandText(TargetClient, RequestCommandsEnum.CallCommand, text);

            //非阻塞式
            while (CheckConnection(TargetClient))
            {
                //接收请求反馈
                RequestCommandsEnum command = ReceiveCommand(TargetClient);
                switch (command)
                {
                    //默认回复Default
                    case RequestCommandsEnum.Default:
                        if (CLPop(targetName + TaskParam._Cancel))
                        {
                            Log.WriteLog("主动中断通话请求");
                            OnCallCanceled(targetName);
                            CloseTargetCall();
                            return;
                        }
                        else
                        {
                            SendCommandText(TargetClient, RequestCommandsEnum.Default);
                            break;
                        }
                    case RequestCommandsEnum.RejectCommand:
                        Log.WriteLog("对方拒绝通话请求", Name);
                        OnCallRejected(targetName);
                        CloseTargetCall();
                        return;
                    case RequestCommandsEnum.AcceptCommand:
                        Log.WriteLog("对方接收通话请求", Name);
                        OnCallAccepted(targetName);
                        StartAudio(TargetClient, targetName, true);
                        return;
                    case RequestCommandsEnum.Error:
                    case RequestCommandsEnum.CallCommand:
                    case RequestCommandsEnum.CancelCommand:
                        Log.WriteLog("信号异常", Name);
                        OnCallRejected(targetName);
                        //OnCallError(targetName);
                        CloseTargetCall();
                        return;
                }
            }

            //阻塞式
            ////接收请求反馈
            //RequestCommandsEnum command = ReceiveCommand(server);
            //switch (command)
            //{
            //    case RequestCommandsEnum.CancelCommand:
            //        CloseConnection(server,true);
            //        //OnCallCanceled(targetName);
            //        CallingClient = null;
            //        break;
            //    case RequestCommandsEnum.Default:
            //    case RequestCommandsEnum.Error:
            //    case RequestCommandsEnum.CallCommand:
            //    case RequestCommandsEnum.SignOnCommand:
            //        Log.WriteLog("通话请求反馈内容错误", Name);
            //        CloseConnection(server,true);
            //        OnCallErrored(targetName);
            //        CallingClient = null;
            //        break;
            //    case RequestCommandsEnum.RejectCommand:
            //        Log.WriteLog("对方拒接通话请求", Name);
            //        CloseConnection(server, true);
            //        OnCallRejected(targetName);
            //        CallingClient = null;
            //        break;
            //    case RequestCommandsEnum.AcceptCommand:
            //        Log.WriteLog("对方接收通话请求", Name);
            //        StartAudio(server, targetName,true);
            //        OnCallAccepted(targetName);
            //        CallingClient = null;
            //        break;
            //}
        }
        /// <summary>
        /// 暂停拨号
        /// 关闭窗口 or 取消按钮
        /// </summary>
        public void Stop()
        {
            if (TargetClient == null)
                return;

            //根据Manager的Stopped判断是否正在通话
            if (Manager.Stopped == false)
            {
                //通话中 禁用通话
                StopAudio();
            }
            else
            {
                //非通话中 即拨号状态 取消拨号
                CancelCall(TargetName);
            }
        }
        #endregion

        #region 语音
        /// <summary>
        /// 启用语音功能 录音及音频数据接收
        /// </summary>
        /// <param name="client"></param>
        private void StartAudio(Socket client, string targetName, bool isActive)
        {
            IsActive = isActive;
            TargetClient = client;
            TargetName = targetName;
            Log.WriteLog("用户{0}启用数据接收", Name);

            try
            {
                //联机测试
                OnStartRecord(targetName);
                ////单例测试 主拨启动录音
                //if (RequestConstants.IsSingleTest && IsActive)
                //{
                //    OnStartRecord();
                //}
            }
            catch (Exception ex)
            {
                Log.WriteLog("客户{0}语音功能启用失败", Name);
                Log.WriteLog(ex.ToString());
            }
            //语音播放启动
            Task.Factory.StartNew(() =>
            {
                Manager.Stopped = false;
                Manager.Play();
            });
            //单例测试 被拨启动接受
            //if (RequestConstants.IsSingleTest && !IsActive)
            //{
            //  Client.BeginReceive(Manager.BufferReceived, 0, Manager.BufferReceived.Length, SocketFlags.None, ReceiveCallback, Client);
            //}
            //联机测试
            TargetClient.BeginReceive(Manager.BufferReceived, 0, Manager.BufferReceived.Length, SocketFlags.None, ReceiveCallback, TargetClient);
        }
        /// <summary>
        /// 主动关闭语音
        /// </summary>
        private void StopAudio()
        {
            Manager.Stopped = true;
            //Manager.StopRecord();
        }
        /// <summary>
        /// 数据接收
        /// </summary>
        /// <param name="connection"></param>
        private void ReceiveCallback(IAsyncResult result)
        {
            try
            {
                Socket connection = result.AsyncState as Socket;
                int length = 0;
                if (CheckConnection(connection))
                {
                    //(主动)终止通话
                    if (Manager.Stopped)
                    {
                        //终止录音 音频输出
                        Manager.StopRecord();
                        //防止已经启用的Available事件继续Send导致服务端异常关闭
                        TargetClient.Shutdown(SocketShutdown.Send);
                        Thread.Sleep(200);
                        //接收残余数据
                        length = connection.EndReceive(result);
                        TargetClient.Shutdown(SocketShutdown.Receive);
                    }
                    else
                    {
                        //接收数据
                        length = connection.EndReceive(result);
                        Manager.AcceptStream(length);
                        Log.WriteLog("客户{1}已接收{0}位数据", Manager.RStream.Length, Name);
                    }
                    //(主动)终止通话
                    if (Manager.Stopped)
                    {
                        Log.WriteLog("{0}:(主动)终止通话", Name);
                        OnActiveAudioRejected(TargetName);

                        CloseTargetConnection();
                        return;
                    }
                }
                //(被动)终止通话
                if (length != 0)
                {
                    connection.BeginReceive(Manager.BufferReceived, 0, Manager.BufferReceived.Length, SocketFlags.None, ReceiveCallback, connection);
                }
                else
                {
                    Log.WriteLog("{0}:(被动)终止通话", Name);
                    OnPassiveAudioRejected(TargetName);
                    //Stop();
                    Manager.Stopped = true;
                    Manager.StopRecord();
                    CloseTargetConnection();
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.ToString());
                Log.WriteLog("{0}:(被动)异常终止通话", Name);
                OnPassiveAudioRejected(TargetName);
                //Stop();
                Manager.Stopped = true;
                Manager.StopRecord();
                CloseTargetConnection();
            }
        }
        #endregion

        #region 指令
        /// <summary>
        /// 新增待处理事件
        /// </summary>
        /// <param name="callerName"></param>
        protected void CLPush(string callerName, TaskParam arg = TaskParam._Default)
        {
            lock (CommandLock)
            {
                if (arg != TaskParam._Default)
                {
                    CommandList.Add(callerName + arg);
                }
                else
                {
                    CommandList.Add(callerName);
                }
            }
        }
        /// <summary>
        /// 处理待处理事件
        /// </summary>
        /// <param name="callerName"></param>
        /// <returns></returns>
        protected bool CLPop(string callerName)
        {
            lock (CommandLock)
            {
                if (CommandList.Contains(callerName))
                {
                    CommandList.Remove(callerName);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// 清理名称相关的指令
        /// </summary>
        /// <param name="callerName"></param>
        protected void CLRemoveRange(string callerName)
        {
            lock (CommandLock)
            {
                List<string> removeList = new List<string>();
                string locator = callerName + "_";
                foreach (string item in CommandList)
                {
                    if (item.Contains(locator))
                    {
                        removeList.Add(item);
                    }

                }
                foreach (var item in removeList)
                {
                    CommandList.Remove(item);
                }
            }
        }
        protected bool AcceptRequest(string callerName)
        {
            Log.WriteLog("接受来自{0}得通话请求", callerName);
            if (!WLCheckExist(callerName))
                return false;

            CLPush(callerName, TaskParam._Submit);
            return true;
        }
        protected bool RejectRequest(string callerName)
        {
            Log.WriteLog("拒绝来自{0}得通话请求", callerName);
            if (!WLCheckExist(callerName))
                return false;

            CLPush(callerName, TaskParam._Cancel);
            return true;
        }
        protected bool AcceptRequestWhileHandling(string callerName)
        {
            return AcceptRequest(callerName);
        }
        protected bool RejectRequestWhileHandling(string callerName)
        {
            return RejectRequest(callerName);
        }
        protected bool CancelCall(string callerName)
        {
            Log.WriteLog("取消拨号,目标:{0}", callerName);

            CLPush(callerName, TaskParam._Cancel);
            return true;
        }
        protected bool ContinueCallWhileHandling(string callerName)
        {
            Log.WriteLog("继续当前拨号");

            CLPush(callerName, TaskParam._Submit);
            return true;
        }
        protected bool CancelCallWhileHandling(string callerName)
        {
            Log.WriteLog("放弃当前拨号");

            CLPush(callerName, TaskParam._Cancel);
            return true;
        }
        #endregion

        #endregion

        #region Events
        //已有通讯连接或请求
        public event EventHandler OnTaskExisted = new EventHandler(() => { });
        //清理通讯连接或请求失败
        public event EventHandler OnTaskClearFailed = new EventHandler(() => { });
        //主拨请求反馈出错
        public event EventHandlerWithArgs OnCallError = new EventHandlerWithArgs((string s) => { });
        //主播请求被拒
        public event EventHandlerWithArgs OnCallRejected = new EventHandlerWithArgs((string s) => { });
        //主拨请求主拨方中止
        public event EventHandlerWithArgs OnCallCanceled = new EventHandlerWithArgs((string s) => { });
        //主拨请求被接受
        public event EventHandlerWithArgs OnCallAccepted = new EventHandlerWithArgs((string s) => { });
        //受拨请求监听到
        public event EventHandlerWithArgs OnRequestReceived = new EventHandlerWithArgs((string s) => { });
        //受拨请求反馈出现异常
        public event EventHandlerWithArgs OnRequestReceivedError = new EventHandlerWithArgs((string s) => { });
        //受拨请求拒绝
        public event EventHandlerWithArgs OnRequestReceivedRejected = new EventHandlerWithArgs((string s) => { });
        //受拨请求主拨方中止
        public event EventHandlerWithArgs OnRequestReceivedCanceled = new EventHandlerWithArgs((string s) => { });
        //启用语音功能 通讯启用
        public event EventHandlerWithArgs OnStartRecord = new EventHandlerWithArgs((string s) => { });
        //语音功能关闭 通讯关闭 主动
        public event EventHandlerWithArgs OnActiveAudioRejected = new EventHandlerWithArgs((string s) => { });
        //语音功能关闭 通讯关闭 被动
        public event EventHandlerWithArgs OnPassiveAudioRejected = new EventHandlerWithArgs((string s) => { });
        //确认接收
        public event EventHandlerWithArgs OnConfirmAccpet = new EventHandlerWithArgs((string s) => { });
        //确认接收(已有通讯)
        public event EventHandlerWithArgs OnConfirmAccpetWhileHandling = new EventHandlerWithArgs((string s) => { });
        //确认主拨(已有通讯)
        public event EventHandlerWithArgs OnConfirmCallWhileHandling = new EventHandlerWithArgs((string s) => { });
        #endregion

        public enum TaskParam
        {
            _Default,
            _Submit,
            _Cancel
        }
    }
}
