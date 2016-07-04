using System;
using System.Net.Sockets;
using System.Net;


#region WPF控件类库
//WPF TextBox=>PresentationFramework
//TextBox.UpdateLayout()=>PresentationCore 
#endregion

#region Socket开发相关类库
//System.Net
//System.Net.Dns
//System.Net.Sockets 
#endregion

namespace SocketContactLib.Base
{
    /// <summary>
    /// Listen业务逻辑
    /// </summary>
    public class ListenBase
    {
        #region 测试
        //用于测试更改配置
        public void UpdatePath(string path)
        {
            Log.path = path;
        }
        #endregion

        #region Fields
        protected internal LogBase Log = new LogBase();
        protected string Host;
        protected int Port;
        private Socket _listener;
        #endregion

        #region Properties
        /// <summary>
        /// 缓存字节
        /// </summary>
        protected Byte[] Buffer { set; get; }
        /// <summary>
        /// 监听对象
        /// </summary>
        protected Socket Listener
        {
            get
            {
                return _listener;
            }
            set { _listener = value; }
        }
        #endregion

        #region Constructors
        public ListenBase()
        {
            Init();
        }
        public ListenBase(string host, int port)
        {
            Host = host;
            Port = port;
            Init();
        }
        private void Init()
        {
            Buffer = new byte[RequestConstants.DefaultBufferSize];
        }
        #endregion

        #region Methods

        #region 连接
        /// <summary>
        /// 检查Socket连接情况
        /// </summary>
        /// <param name="socket"></param>
        /// <returns></returns>
        protected bool CheckConnection(Socket socket)
        {
            if (socket == null || !socket.Connected)
                return false;

            return true;
        }
        /// <summary>
        /// 关闭Socket
        /// </summary>
        protected void CloseConnection(Socket socket,bool IsActive=false)
        {
            if (socket == null&&socket.Connected)
                return;

            //socket.Shutdown(SocketShutdown.Both);
            //string host = IsActive ? ((IPEndPoint)socket.RemoteEndPoint).Address.ToString() : ((IPEndPoint)socket.LocalEndPoint).Address.ToString();
            //int port = IsActive ? ((IPEndPoint)socket.RemoteEndPoint).Port : ((IPEndPoint)socket.LocalEndPoint).Port;
            //if (RequestConstants.IsSingleTest)
            //{
            //    locator = TestData.UserList.Find(c => c.Host == host && (c.Port == port || c.ServerPort == port)).Name;
            //}
            socket.Close();
            //不管主被动都触发
            //if (IsActive)
            //{
            //}
            OnConnectionClosed();

            string locator = Host;
            Log.WriteLog("{0}已关闭连接", locator);
        }
        /// <summary>
        /// 启用连接
        /// </summary>
        protected Socket Connect(string host, int port)
        {
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint iped = new IPEndPoint(ip, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                socket.Connect(iped);
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.ToString());
            }
            return socket;
        }
        #endregion

        #region 监听
        /// <summary>
        /// 启用监听
        /// </summary>
        /// <param name="backlog"></param>
        public void Listen(int backlog = 0)
        {
            //端口port检查
            IPAddress ip = IPAddress.Parse(Host);
            IPEndPoint iped = new IPEndPoint(ip, Port);

            Listen(iped, backlog);
        }
        /// <summary>
        /// 启用监听
        /// </summary>
        /// <param name="iped"></param>
        /// <param name="backlog"></param>
        protected void Listen(IPEndPoint iped, int backlog = 0)
        {
            try
            {
                Listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Listener.Bind(iped);
                Listener.Listen(backlog);//连接不上会抛SocketException
                Listener.BeginAccept(AcceptCallBack, Listener);

                Log.WriteLog("语音监听监听已启用,监听地址{0}:{1}", Host, Port);
                OnListenStarted();
            }
            catch (Exception ex)
            {
                Log.WriteLog(ex.ToString());
                Log.WriteLog("语音监听启用监听失败,端口{0}", Port);
                OnListenFailed();
            }
        }
        /// <summary>
        /// 套接字接收回调
        /// </summary>
        /// <param name="result"></param>
        protected void AcceptCallBack(IAsyncResult result)
        {
            Log.WriteLog("收到请求");
            Socket listener = result.AsyncState as Socket;
            //接收请求 
            Socket client = listener.EndAccept(result);
            //继续监听
            listener.BeginAccept(AcceptCallBack, listener);
            //处理请求
            HandleRequest(client);
        }
        /// <summary>
        /// 监听到请求时触发
        /// </summary>
        /// <param name="client"></param>
        protected virtual void HandleRequest(Socket client)
        {
            CloseConnection(client);
        }
        #endregion

        #region 数据收发
        /// <summary>
        /// 接收指令
        /// </summary>
        /// <param name="socket"></param>
        /// <returns>RequestCommandsEnum.Error 连接自动中断</returns>
        protected RequestCommandsEnum ReceiveCommand(Socket socket)
        {
            RequestCommandsEnum command = RequestCommandsEnum.Default;
            int readCount = 0;
            try
            {
                readCount = socket.Receive(Buffer, RequestConstants.SocketCommandLength, 0);
            }
            catch 
            {
                command = RequestCommandsEnum.Error;
            }
            if (readCount == 0)
            {
                CloseConnection(socket);
            }
            else
            {
                string text = System.Text.Encoding.Default.GetString(Buffer, 0, 1);
                if (!Enum.TryParse<RequestCommandsEnum>(text, out command))
                {
                    Log.WriteLog("指令错误:", text);
                    CloseConnection(socket);
                }
            }
            return command;
        }
        /// <summary>
        /// 接收文本数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="length"></param>
        /// <param name="IsLengthMatchNeeded"></param>
        /// <returns></returns>
        protected string ReceiveText(Socket socket, int length = 1024)
        {
            int readCount = socket.Receive(Buffer, RequestConstants.DefaultBufferSize, SocketFlags.None);
            if (readCount == 0)
            {
                CloseConnection(socket);
                return "";
            }
            else
            {
                return System.Text.Encoding.Default.GetString(Buffer, 0, readCount);
            }
        }
        /// <summary>
        /// 发送指令及数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="command"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        protected int SendCommandText(Socket socket, RequestCommandsEnum command, string text = "")
        {
            if (CheckConnection(socket))
            {
                byte[] buffer = System.Text.Encoding.Default.GetBytes(((int)command).ToString() + text);
                return socket.Send(buffer, buffer.Length, 0);
            }
            else
            {
                CloseConnection(socket);
                return -1;
            }
        }
        /// <summary>
        /// 发送指令及数据
        /// </summary>
        /// <param name="socket"></param>
        /// <param name="command"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        protected internal int SendBuffer(Socket socket, byte[] buffer, int length = 0)
        {
            if (CheckConnection(socket))
            {
                return socket.Send(buffer, length == 0 ? buffer.Length : length, 0);
            }
            else
            {
                //CloseConnection(socket);
                return -1;
            }
        } 
        #endregion

        #endregion

        #region Events
        public delegate void EventHandler();
        public delegate void EventHandlerWithArgs(string arg1);
        public event EventHandler OnConnectionClosed = new EventHandler(() => { });
        public event EventHandler OnListenFailed = new EventHandler(() => { });
        public event EventHandler OnListenStarted = new EventHandler(() => { });
        #endregion
    }
}
