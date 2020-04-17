using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 导出Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "nasdhhdajsajsdasdhajsda";
           var array  = str.Split(new char[] {'a','n' });
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
