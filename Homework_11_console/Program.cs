using System;
using static Homework_11_console.employe.Director;
using Homework_11_console.employe;
using static Homework_11_console.structure.Company;
using Homework_11_console.structure;

namespace Homework_11_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OneCompany);
            Console.WriteLine(companyDirector);
            companyDirector.Name = "Steeve Jobs";
            OneCompany.Create(new MainOffice());
            Console.WriteLine(OneCompany.workPlaces[0].GetType());
            OneCompany.workPlaces[0].Hire(new Intern(18, "John", 100, OneCompany.workPlaces[0]));
            Console.WriteLine(OneCompany.workPlaces[0]);
            Console.WriteLine(OneCompany);
            Console.ReadKey();
        }
    }
}