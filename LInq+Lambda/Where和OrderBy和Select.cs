using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInq_Lambda
{

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Teacher> Teachers { get; set; }
    }

    public class Teacher
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Where和OrderBy和Select
    {
        static void WhereDemo()
        {
            List<string> list = new List<string> {
                "aa","bb","cc"
            };

            var list2 = list.Where(x => x == "aa").ToList();
            foreach (var item in list2)
            {
                Console.WriteLine(item);
            }
            //测试含有对象的
            List<Teacher> t1 = new List<Teacher> {
            new Teacher { Name = "小丁",Age = 81 },
            new Teacher { Name = "小王", Age = 71 }
            };
            List<Teacher> t2 = new List<Teacher> {
            new Teacher { Name = "棒棒",Age = 81 },
            new Teacher { Name = "呵呵", Age = 71 }
            };

            List<Student> stu = new List<Student>
            {
                new Student{Name ="大黑狗",Age = 8,Teachers =t1 },
                new Student{Name = "磊哥" ,Age =25,Teachers =t2 }
            };
            //stu.Where(x => x.Name == "磊哥").ToList();
            foreach (var item in stu)
            {
                item.Teachers.Where(x => x.Name == "小丁").ToList();
            }

            var list3 = stu.Where(x => x.Name == "磊哥").ToList();

            //循环遍历
            foreach (var item in list3)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

    }
}
