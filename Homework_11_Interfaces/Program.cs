using System;

namespace Homework_11_Interfaces
{
    interface I1
    {
        void M() { Console.WriteLine("I1.M()"); }
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
        
    }
}
