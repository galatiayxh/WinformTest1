using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInq_Lambda
{
    //student数据结构
    class Student
    {
        public int id;
        public string name;
    }
    //student 集合
    class StudentCollection : IEnumerable
    {
        public List<Student> students = new List<Student>();
        public void Add(Student student)
        {
            students.Add(student);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class IEnumerable实现
    {
    }
}
