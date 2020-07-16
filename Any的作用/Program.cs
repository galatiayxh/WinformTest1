using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Any的作用
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Teacher> t1 = new List<Teacher>
            {
                new Teacher{ Name = "张三1",Age =55 },
                new Teacher{ Name = "张三2",Age =45 },
                new Teacher{ Name = "张三3",Age =35 }
            };

            List<Teacher> t2 = new List<Teacher>
            {
                new Teacher{ Name = "李四1",Age =55 },
                new Teacher{ Name = "李四2",Age =45 },
                new Teacher{ Name = "李四3",Age =15 }
            };

            List<int> t3 = new List<int>
            {
              1,5,15,54,55,45
            };
            List<int> t4 = new List<int>
            {
              221,15,145,54,55
            };

            var temp1 = t1.Where(x => t2.Any(y => y.Age == x.Age)).ToList();

            var temp2 = t1.Where(x => t3.Any(y => y == x.Age)).ToList();

            var temp3 = t3.Where(x => t4.Any(y => y == x) == false).ToList();

            foreach (var item in temp1)
            {
                Console.WriteLine(item.Name + "-----" + item.Age);
            }

            Console.WriteLine("--------------------------------------");


            foreach (var item in temp2)
            {
                Console.WriteLine(item.Name + "-----" + item.Age);
            }

            Console.WriteLine("--------------------------------------");


            foreach (var item in temp3)
            {
                Console.WriteLine(item);
            }


            Console.ReadKey();
        }
    }

    class Teacher
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
