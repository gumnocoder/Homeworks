using System;

namespace Homework_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Depatments dep = new Depatments("отдел_0", DateTime.Now);
            string a = dep.Print();
            Console.WriteLine(a);
            Console.ReadKey();
        }
    }
}
