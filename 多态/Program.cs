using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 多态
{
    public class Animal
    {
        public int a = 1;
        public virtual void Eat()
        {
            Console.WriteLine("Animal eat");
        }
    }

    public class Cat : Animal
    {
        public int a = 2;
        public override void Eat()
        {
            Console.WriteLine("Cat eat");
        }


        public void Sleep()
        {
            Console.WriteLine("Cat Sleep");
        }
    }

    public class Dog : Animal
    {
        public int a = 3;
        public override void Eat()
        {
            Console.WriteLine("Dog eat");
        }
    }
    class Program
    {


        //由此得出多态作用就是当父类的引用指向子类对象时，就发生了向上转型，“即把子类类型对象转成了父类类型“。向上转型的好处是隐藏了子类类型，提高了代码的扩展性。
        //但向上转型也有弊端，只能使用父类共性的内容，而无法使用子类特有功能，功能有限制。
        static void Main(string[] args)
        {
            /**多态成员方法
             * 编译时期：参考引用变量所属的类，如果没有类中没有调用的方法，编译失败。
             * 运行时期：参考引用变量所指的对象所属的类，并运行对象所属类中的成员方法。
             * 简而言之：编译看左边，运行看右边。
             */
            //Animal[] animals = new Animal[3];

            //animals[0] = new Animal();
            //animals[1] = new Cat();
            //animals[2] = new Dog();

            //for (int i = 0; i < 3; i++)
            //{
            //    animals[i].Eat();
            //}


            /**
             * 多态成员变量
             * 当子父类中出现同名的成员变量时，多态调用该变量时：
             * 编译时期：参考的是引用型变量所属的类中是否有被调用的成员变量。没有，编译失败。
             * 运行时期：也是调用引用型变量所属的类中的成员变量。
             * 简单记：编译和运行都参考等号的左边。编译运行看左边。
             */
            Animal animal = new Cat();
            animal.Sleep();
            Console.WriteLine(animal.a);
            Console.ReadKey();
        }

        //       多态总结:
        //什么时候使用向上转型：
        //	当不需要面对子类类型时，通过提高扩展性，或者使用父类的功能就能完成相应的操作，这时就可以使用向上转型。
        //	如：Animal a = new Dog();
        //       a.eat();
        //什么时候使用向下转型
        //       当要使用子类特有功能时，就需要使用向下转型。
        //		如：Dog d = (Dog)a; //向下转型
        //       d.lookHome();//调用狗类的lookHome方法
        //		向下转型的好处：可以使用子类特有功能。
        //		弊端是：需要面对具体的子类对象；在向下转型时容易发生ClassCastException类型转换异常。在转换之前必须做类型判断。
        //	如：if( !a instanceof Dog){…}
    }
}
