using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading.Tasks;
using SocketContactLib.Client;
using SocketContactLib.Base;

namespace SocketContactLib.Server
{
    public class Connection
    {
        public ListenBase Parent;
        public void SetParent(ListenBase parent)
        {
            Parent = parent;
        }

        public Socket ClientC;
        public Socket ClientR;
        byte[] Buffer = new byte[RequestConstants.DefaultBufferSize];
        byte[] BufferS = new byte[RequestConstants.DefaultBufferSize];
        byte[] BufferR = new byte[RequestConstants.DefaultBufferSize];
        int Count = 0;

        public Connection(CLSClientBase caller, CLSClientBase receiver)
        {
            ClientC = caller.TargetClient;
            ClientR = receiver.TargetClient;
        }

        public Connection(Socket caller, Socket receiver)
        {
            ClientC = caller;
            ClientR = receiver;
        }

        protected bool CheckConnection(Socket socket)
        {
            if (socket == null || !socket.Connected)
                return false;

            return true;
        }
        public bool CheckConnection()
        {
            return CheckConnection(ClientC) && CheckConnection(ClientR);
        }
        
        #region 异步线程
        public void StartTransfer()
        {
            //异步线程
            Task.Factory.StartNew(() => Transfer(true));
            //Task.Factory.StartNew(() => Transfer(false));
            //Task.Factory.StartNew(() => Transfer(ClientR, ClientC));
        }
        public void Transfer(bool IsForward)
        {
            Socket sender = IsForward ? ClientC : ClientR;
            Socket receiver = IsForward ? ClientR : ClientC;
            byte[] buffer = IsForward ? BufferS : BufferR;

            if (CheckConnection(sender) && CheckConnection(receiver))
            {
                sender.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, ReceiveCallback, IsForward);
            }
            else
            {
                Close();
            }
        }
        void ReceiveCallback(IAsyncResult ar)
        {
            bool IsForward = (bool)ar.AsyncState;
            Socket sender = IsForward ? ClientC : ClientR;
            Socket receiver = IsForward ? ClientR : ClientC;
            byte[] buffer = IsForward ? BufferS : BufferR;

            try
            {
                int readCount = 0;
                if (CheckConnection(sender))
                {
                    readCount = sender.EndReceive(ar);
                }
                if (readCount != 0)
                {
                    if (CheckConnection(receiver))
                    {
                        readCount = Math.Min(readCount, RequestConstants.DefaultBufferSize);
                        Count += readCount;
                        receiver.Send(buffer, readCount, SocketFlags.None);
                        Parent.Log.WriteLog("{1}中转服传输{0}位数据", Count, IsForward ? "(C)" : "(R)");
                        Transfer(!IsForward);//增加! 双向通讯
                    }
                    else
                    {
                        Close();

                        //Parent.Log.WriteLog("中转服终止{0}传输", IsForward ? "被拨" : "主拨");
                        //receiver.Close();
                    }
                }
                else
                {
                    Parent.Log.WriteLog("中转服终止{0}传输", IsForward ? "主拨" : "被拨");
                    sender.Close(2);
                    Parent.Log.WriteLog("中转服终止{0}传输", IsForward ? "被拨" : "主拨");
                    receiver.Close(2);
                }
            }
            catch (SocketException ex)
            {
                Parent.Log.WriteLog(ex.ToString());
                Parent.Log.WriteLog("中转服异常终止传输");
                Close();
            }
        }
        #endregion
        
        #region 单线程
        //public void StartTransfer()
        //{
        //    Task.Factory.StartNew(() => Transfer());
        //}
        //public void Transfer()
        //{
        //    try
        //    {
        //        while (true)
        //        {
        //            int length = ClientC.Receive(Buffer);
        //            if (length == 0 || !ClientR.Connected)
        //                break;
        //            length = ClientR.Send(Buffer, length, SocketFlags.None);
        //            if (length == 0 || !ClientR.Connected)
        //                break;
        //            length = ClientR.Receive(Buffer);
        //            if (length == 0 || !ClientC.Connected)
        //                break;
        //            length = ClientC.Send(Buffer, length, SocketFlags.None);
        //            if (length == 0 || !ClientC.Connected)
        //                break;
        //        }
        //        Close();
        //        Parent.Log.WriteLog("中转服终止传输");
        //    }
        //    catch (SocketException ex)
        //    {
        //        Parent.Log.WriteLog(ex.ToString());
        //        Parent.Log.WriteLog("中转服异常终止传输");
        //        Close();
        //    }
        //} 
        #endregion

        public void Close()
        {
            ClientC.Close();
            ClientR.Close();
        }
    }
}
