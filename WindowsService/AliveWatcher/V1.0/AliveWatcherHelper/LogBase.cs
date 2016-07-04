using System;
using System.Text;
//using System.Windows.Controls;
using System.IO;

namespace AliveWatcherHelper
{
    public enum OuterType
    {
        Default,
        TextBox,
        Consolo,
        Action
    }
    /// <summary>
    /// log相关
    /// </summary>
    public class LogHelper
    {
        public LogHelper()
        {
            OType = OuterType.Default;
        }

        public void SetOuter(OuterType type)
        {
            OType = type;

            //if (obj is TextBox)
            //{
            //    Outer = obj;
            //    OType = OuterType.TextBox;
            //}
        }
        internal string Path = @"C:\log.txt";
        protected StringBuilder Log = new StringBuilder();
        protected Object Outer { set; get; }
        protected Action OAction { set; get; }
        protected OuterType OType { set; get; }
        public void UpdatePath(string path)
        {
            Path = path;
        }
        private static object LogLock = new object();
        public void WriteLog(string message)
        {
            lock (LogLock)
            {
                string directory=Path.Substring(0,Path.LastIndexOf("\\"));
                if (!string.IsNullOrEmpty(directory)&&!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                };
                using (FileStream stream = File.Open(Path, FileMode.Append, FileAccess.Write))
                {
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(message + "\r\n");
                    stream.Write(bytes, 0, bytes.Length);
                }
                Log.AppendLine(message);

                switch (OType)
                {
                    case OuterType.Default:
                        break;
                    case OuterType.TextBox:
                        break;
                    case OuterType.Consolo:
                        Console.WriteLine(message);
                        break;
                    case OuterType.Action:
                        break;
                    default:
                        break;
                }
                //outer
                //switch (OType)
                //{
                //    case OuterType.TextBox:
                //        var control = Outer as TextBox;
                //        Action action = () =>
                //        {
                //            if (control.Text.Length>400)
                //            {
                //                control.Text = message;
                //            }
                //            else
                //            {
                //                control.Text += message;
                //            }
                //            control.ScrollToEnd();
                //            control.UpdateLayout();
                //        };
                //        control.Parent.Dispatcher.BeginInvoke(action);
                //        break;
                //    case OuterType.Action:
                //        OAction();
                //        break;
                //    default:
                //        break;
                //}
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
