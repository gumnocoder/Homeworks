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
            com.Departments[0].AutoOpen();
            com.Departments[0].Offices[0].Hire(new Intern(100, "John", 18));
            com.Departments[0].Offices[0].Hire(new Intern());
            foreach (var e in com.Departments[0].Offices[0].Workers) Console.WriteLine(e);
            Console.WriteLine(com.Departments[0].Offices[0]);
            Console.WriteLine(com.Departments[0].Offices[0].Workers[0]);
            Console.WriteLine(depsCount);
            Console.WriteLine(com);
            foreach (var e in com.Departments) Console.WriteLine(e);
            Console.ReadKey();
        }
    }
}
