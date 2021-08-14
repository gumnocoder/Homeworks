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
            /// string FirstName, string LastName, int Age, string Department, int Salary, int ProjectsCount
            Staff worker = new Staff("Уважаемый", "Гражданин", 15, dep.depName, 10000, 3);
            Console.WriteLine(worker.Print());
            Console.ReadKey();
        }
    }
}
