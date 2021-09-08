using System;
using static Homework_11_console.employe.Director;
using static Homework_11_console.structure.Company;

namespace Homework_11_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(companyDirector);
            companyDirector.Name = "Steeve Jobs";

            Console.WriteLine(OneCompany);
            Console.ReadKey();
        }
    }
}