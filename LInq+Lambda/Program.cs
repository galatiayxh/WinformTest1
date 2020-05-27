using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LInq_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentCollection sc = new StudentCollection();
            sc.Add(new Student { id = 0, name = "Tony" });
            sc.Add(new Student { id = 1, name = "Micheal" });
            sc.Add(new Student { id = 2, name = "Amy" });
        }
    
    }

   
}
