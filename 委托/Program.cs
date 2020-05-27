using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{

    delegate void callback(string name);

    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Program program3 = new Program();
            Program program4 = new Program();

            program.GreetPeople(ChineseGreeting);
            
            //callback callback = EnglishGreeting;
            //callback += ChineseGreeting;
            //program.GreetPeople(callback);

        }

        public void GreetPeople(callback Greet)
        {
            Greet("张三");
            Console.ReadKey();
        }

        public static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }

        public static void EnglishGreeting(string name)
        {
            Console.WriteLine("good morning, " + name);
        }
    }
}
