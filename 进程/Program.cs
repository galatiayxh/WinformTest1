using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 进程
{
    class Program
    {
        static void Main(string[] args)
        {
            //var pro = Process.GetProcesses();
            //foreach (var item in pro)
            //{
            //    //item.Kill();
            //    Console.WriteLine(item.ToString());
            //}

            Process.Start("calc");

            Console.ReadKey();
        }
    }
}
