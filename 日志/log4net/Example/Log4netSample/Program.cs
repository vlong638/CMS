using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4netSample
{
    class Program
    {

        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            log.Debug("Debug");
            log.Info("Info");
            log.Warn("Warn");
            log.Error("Error", new Exception("Error"));
            log.Fatal("Fatal", new Exception("Fatal"));
            Console.ReadLine();
        }
    }
}
