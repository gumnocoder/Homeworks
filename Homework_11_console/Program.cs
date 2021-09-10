using System;
using static Homework_11_console.employe.Director;
using Homework_11_console.employe;
using static Homework_11_console.structure.Company;
using static Homework_11_console.structure.MainOffice;
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
            OneCompany.Create(new Department("1"));
            OneCompany.workPlaces[1].Hire(new Intern(20, "Jim", 110));
            Console.WriteLine(OneCompany.workPlaces[0].ToString());
            //mainOffice().Hire(new Intern(18, "John", 100));
            //Console.WriteLine(mainOffice().workers.Count);

            OneCompany.workPlaces[1].Hire(new Intern(25, "Joe", 112));
            OneCompany.workPlaces[1].Hire(new Intern(21, "Joy", 110));
            Console.WriteLine(OneCompany.workPlaces[1]);
            //foreach (var e in OneCompany.workPlaces[1])
            Department dep = new("11");
            dep.Hire(new Intern(23, "Joely", 112));

            Console.WriteLine();
            //Console.WriteLine(OneCompany.workPlaces[1].workers.Count);
            Console.WriteLine(dep.GetType());
            Console.WriteLine();
            foreach (var workPlworkerace in OneCompany.workPlaces[1].workers)
            {
                Console.WriteLine(workPlworkerace);
/*                foreach (var worke in workPlace.workers)
                    Console.WriteLine(worke);*/
            }

            //foreach(var e in dep.workers)
            Console.WriteLine(OneCompany);
            Console.ReadKey();
        }
    }
}