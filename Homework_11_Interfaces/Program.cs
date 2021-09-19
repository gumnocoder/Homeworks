using System;

namespace Homework_11_Interfaces
{
    interface I1
    {
        static void M() { Console.WriteLine("I1.M()"); }
    }

    interface I2
    {
        void M() { Console.WriteLine("I2.M()"); }
    }

    class A : I1, I2
    {
        public void M() { Console.WriteLine("A.M()"); }

    }

    class B : A, I1, I2
    {
        new public void M() { Console.WriteLine("A.B()"); }
    }

    class C
    {
        public void M()
        {
            I1.M();
        }
    }

    class Program
    {
        static void Main()
        {
            I1 b = new B();
            b.M();
            Console.ReadKey();
        }
    }
}
