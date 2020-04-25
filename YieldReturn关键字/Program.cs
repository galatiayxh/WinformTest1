using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YieldReturn关键字
{
    class Program
    {
        static private List<int> _numArray; //用来保存1-100 这100个整数

        Program() //构造函数。我们可以通过这个构造函数往待测试集合中存入1-100这100个测试数据
        {
            _numArray = new List<int>(); //给集合变量开始在堆内存上开内存，并且把内存首地址交给这个_numArray变量

            for (int i = 1; i <= 100; i++)
            {
                _numArray.Add(i);  //把1到100保存在集合当中方便操作
            }
        }

        static void Main(string[] args)
        {

            new Program();

            TestMethod();

        }

        //测试求1到100之间的全部偶数
        static public void TestMethod()
        {
            foreach (var item in GetAllEvenNumber())
            {
                Console.WriteLine(item); //输出偶数测试
            }
            Console.ReadLine();
        }

        //测试我们正常情况下拿到全部偶数的方法
        static IEnumerable<int> GetAllEvenNumber()
        {
            List<int> result = new List<int>(); //开集合内存存偶数用

            foreach (int num in _numArray)
            {
                if (num % 2 == 0) //判断是不是偶数
                {
                    //yield return num;
                    result.Add(num); //存入集合
                }
            }

            //返回偶数集合变量   可能有人会觉得奇怪返回类型不是List<int>这样可以吗
            //这个就要回到我们的里氏替换原则了，子类是可以替换父类的，也就是当父类用
            //比如我这个方法是想得到IEnumerable<int> 类型变量，但是我给了List<int>类型变量
            //注意List<int> 是继承 IEnumerable<int> 的，什么意思当我们把子类当父类使用，
            //那么大才小用，因为子类很多都是继承父亲，你自身增加很多字段或者方法，这样就不能用了。
            return result;
            //yield break;
        }
    }
}
