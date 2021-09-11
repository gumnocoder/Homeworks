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
            Company com = new Company();
            Console.WriteLine(com);
            com.AutoOpen();
            Console.WriteLine(depsCount);
            com.AutoOpen();
            Console.WriteLine(depsCount);
            com.AutoOpen();
            com.WorkPlaces[0].AutoOpen();
            com.WorkPlaces[0].Hire(new DepartmentBoss("Johnny", 45, com.WorkPlaces[0]));
            com.WorkPlaces[0].WorkPlaces[0].Hire(new Intern(100, "John", 18));
            com.WorkPlaces[0].WorkPlaces[0].Hire(new Intern());
            Console.WriteLine(com.WorkPlaces[0].WorkPlaces[0].Workers[0].MonthlySalary());
            foreach (var e in com.WorkPlaces[0].WorkPlaces[0].Workers) Console.WriteLine(e);
            Console.WriteLine(com.WorkPlaces[0].WorkPlaces[0]);
            Console.WriteLine(com.WorkPlaces[0].WorkPlaces[0].Workers[0]);
            Console.WriteLine(depsCount);
            Console.WriteLine(com);
            foreach (var e in com.WorkPlaces) Console.WriteLine(e);
            Console.WriteLine($"dep 0 depboss salary = {com.WorkPlaces[0].Boss.MonthlySalary()}");
            Console.ReadKey();
        }
    }
}
