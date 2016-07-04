using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIATTester.Helper
{
    public static class GlobalLogHelper
    {
        private static LogHelper _instance;
        public static LogHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LogHelper();

                return _instance;
            }
        }

        public static void WriteLog(string message, params object[] args)
        {
            Instance.WriteLog(string.Format(message, args));
        }
        public static void WriteLog(Exception ex)
        {
            Instance.WriteLog(ex.ToString());
        }
    }

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
            this.OType = OuterType.Default;
        }
        public LogHelper(string path)
        {
            this.OType = OuterType.Default;
            this.Path = path;
        }

        public void SetOuter(OuterType type)
        {
            OType = type;
        }
        internal string Path = @"D:\WorkSpace\Projects\MyCMS\FIATTester\FIATTester\Helper\Log.txt";
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
                string directory = Path.Substring(0, Path.LastIndexOf("\\"));
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
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
