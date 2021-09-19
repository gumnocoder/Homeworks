using System;
using static Homework_11_Interfaces.B;

namespace Homework_11_Interfaces
{
    interface I1
    {
        void M();
    }

    interface I2
    {
        void M();
    }

    class A : I1, I2
    {
        public void M() { Console.WriteLine("A.M()"); }
    }

    class B : A
    {
        new public void M()
        {
            Console.WriteLine("B.M()");
        }
    }

    class Program
    {
        static void Main()
        {
            A a = new();
            B b = new();
            a.M();
            b.M();
            a = new B();
            a.M();
            Console.ReadKey();
        }
    }
}
