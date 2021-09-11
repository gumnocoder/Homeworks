using System;
using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.structBin.Company;
using Homework_11_ConsUI.employeBin;
namespace Homework_11_ConsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            HireDirector(new Director());
            Console.WriteLine(OneCompany);
            OneCompany.AutoOpen();
            Console.WriteLine(DepsCount);
            OneCompany.AutoOpen();
            Console.WriteLine(DepsCount);
            OneCompany.AutoOpen();
            OneCompany.WorkPlaces[0].AutoOpen();
            OneCompany.WorkPlaces[0].Hire(new DepartmentBoss("Johnny", 45, OneCompany.WorkPlaces[0]));
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Intern(100, "John", 18));
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Intern());
            Console.WriteLine(OneCompany.WorkPlaces[0].WorkPlaces[0].Workers[0].MonthlySalary());
            foreach (var e in OneCompany.WorkPlaces[0].WorkPlaces[0].Workers) Console.WriteLine(e);
            Console.WriteLine(OneCompany.WorkPlaces[0].WorkPlaces[0]);
            Console.WriteLine(OneCompany.WorkPlaces[0].WorkPlaces[0].Workers[0]);
            Console.WriteLine(DepsCount);
            Console.WriteLine(OneCompany);
            foreach (var e in OneCompany.WorkPlaces) Console.WriteLine(e);
            Console.WriteLine($"dep 0 depboss salary = {OneCompany.WorkPlaces[0].Boss.MonthlySalary()}");
            Console.WriteLine($"director salary = {companyDirector.MonthlySalary()}");
            OneCompany.Rename("Horns&hooves");
            Console.WriteLine(OneCompany);
            Console.ReadKey();
        }
    }
}
