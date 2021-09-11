using System;
using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.structBin.Company;
using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.Director;
namespace Homework_11_ConsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            HireDirector(oneDirector);
            OneCompany.AutoOpen();
            OneCompany.AutoOpen();
            OneCompany.AutoOpen();
            OneCompany.WorkPlaces[0].AutoOpen();

            OneCompany.WorkPlaces[0].Hire(new DepartmentBoss("Johnny", 45, OneCompany.WorkPlaces[0]));
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Intern(4, "John", 18));
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Intern());

            foreach (var e in OneCompany.WorkPlaces) Console.WriteLine(e);
            foreach (var e in OneCompany.WorkPlaces[0].WorkPlaces[0].Workers) Console.WriteLine(e);

            OneCompany.Rename("Horns&hooves");
            Console.WriteLine(OneCompany);
            Console.WriteLine(companyDirector);
            Console.ReadKey();
        }
    }
}
