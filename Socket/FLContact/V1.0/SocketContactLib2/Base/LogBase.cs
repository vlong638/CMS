using System;
using System.Text;
using System.Windows.Controls;
using System.IO;

namespace SocketContactLib.Base
{

    /// <summary>
    /// log相关
    /// </summary>
    public class LogBase
    {
        public bool IsClient;

        protected enum OuterType
        {
            Default,
            TextBox,
            Action
        }
        public void SetOuter(object obj)
        {
            if (obj is TextBox)
            {
                Outer = obj;
                OType = OuterType.TextBox;
            }
        }
        internal string path = @"C:\FLLog.txt";
        protected StringBuilder Log = new StringBuilder();
        protected Object Outer { set; get; }
        protected Action OAction { set; get; }
        protected OuterType OType { set; get; }

        private static object LogLock = new object();
        public void WriteLog(string message)
        {
            lock (LogLock)
            {
                message = string.Format("{0}{1}{2}", (IsClient ? "(C)" : "(S)"), message, "\r\n");
                using (FileStream stream = File.Open(path, FileMode.Append, FileAccess.Write))
                {
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(message.ToString());
                    stream.Write(bytes, 0, bytes.Length);
                }
                Log.AppendLine(message);
                //outer
                switch (OType)
                {
                    case OuterType.TextBox:
                        var control = Outer as TextBox;
                        Action action = () =>
                        {
                            if (control.Text.Length>400)
                            {
                                control.Text = message;
                            }
                            else
                            {
                                control.Text += message;
                            }
                            control.ScrollToEnd();
                            control.UpdateLayout();
                        };
                        control.Parent.Dispatcher.BeginInvoke(action);
                        break;
                    case OuterType.Action:
                        OAction();
                        break;
                    default:
                        break;
                }
            }
        }
        public void WriteLog(string message, params object[] args)
        {
            WriteLog(string.Format(message, args));
        }

        public string ReadLog()
        {
            return Log.ToString();
        }
    }
}
