using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MD5Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(GetMd5Buffer("123"));
            Console.ReadKey();
        }

        public static string GetMd5Buffer(string str)
        {
            MD5 md5 = MD5.Create();

            var normleStr = Encoding.Default.GetBytes(str);
             var md5Buffer = md5.ComputeHash(normleStr);
            return Encoding.Default.GetString(md5Buffer);
        }
    }
}
