﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            using (System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(WcfService.LibraryService)))
            {
                host.Open();
                Console.ReadLine();
            }
        }
    }
}
