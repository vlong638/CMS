using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocketContactLib.Base
{
    public static class RequestConstants
    {
        #region Constants

        public const int DefaultBufferSize = 4096;
        public const int SocketCommandLength = 1;
        /// <summary>
        /// 主拨消息格式:{Command}{CallerID},{ReceiverID}
        /// </summary>
        public const string CallPattern = "{0},{1}";


        #endregion

        #region Command
        /// <summary>
        /// CallerID,Host,Port
        /// </summary>
        public const string SignOnPattern = "{0},{1},{2}";


        #endregion



        public const int SocketHeader = 5;
        public const int CallLength = 73;
        public const int PlayNotifySize = 4096;
        public const int WriteNotifySize = 4096;
        public const int DepressLength = 4096;
        public const bool VoiceFromFile = false;
        public const string FilePath = @"C:\Users\Administrator\Desktop\recording.mp3";
        public const bool IsPlaySaved = false;
        //单机测试:只有一个输入设备
        public const bool IsSingleTest = true;
    }

    public enum RequestCommandsEnum
    {
        //默认
        Default = 0,
        Error = 1,
        CallCommand,
        RejectCommand,
        AcceptCommand,
        CancelCommand


        //AuthorizeCommand,//身份验证
        //MyDataAccessAudioCommand,//音频传输
        //MyDataAccessCallCommand,//通话请求
        //MyDataAccessRejectCommand//终止通话
        //TextCommand,//文本传输
        //MyDataAccessFileCommand//文件传输
    }

    public enum UserState
    {
        Off = 0,
        Available = 1,
        Busy,
        Engaged//通话中

        //Busy
        //Calling,//拨号中
        //BeingCalling,//被拨号中

        //Engaged
        //Called,//主拨通话中
        //BeingCalled//被拨通话中
    }


    #region State模式

    //public abstract class StateBase
    //{
    //    protected bool IsServer;
    //    protected UserInfo Parent;

    //    public StateBase(UserInfo parent, bool isServer)
    //    {
    //        Parent = parent;
    //        IsServer = isServer;
    //    }

    //    public void Listen();
    //    public void Accept();
    //    public void Call();
    //    public void Reject();
    //}

    //public class AvailableState : StateBase
    //{
    //    public AvailableState(UserInfo parent, bool isServer)
    //        : base(parent, isServer)
    //    {
    //    }


    //    public void Listen()
    //    {

    //    }
    //    public void Accept()
    //    {

    //    }
    //    public void Call()
    //    {

    //    }
    //    public void Reject()
    //    {

    //    }
    //}
    //public class BusyState : StateBase
    //{
    //    public void Listen()
    //    {

    //    }
    //    public void Accept()
    //    {

    //    }
    //    public void Call()
    //    {

    //    }
    //    public void Reject()
    //    {

    //    }
    //}
    //public class EngagedState : StateBase
    //{
    //    public void Listen()
    //    {

    //    }
    //    public void Accept()
    //    {

    //    }
    //    public void Call()
    //    {

    //    }
    //    public void Reject()
    //    {

    //    }
    //} 
    #endregion

    #region 扩展方法

    public static class ExRequestCommand
    {
        //public static void()
    }

    #endregion
}
