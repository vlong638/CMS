using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultBool = new WCFTester.ServiceReference1.Service1Client().GetRandomGT60();
            var resultStudent = new WCFTester.ServiceReference1.Service1Client().GetStudent();
            Console.ReadLine();
        }
    }
}
