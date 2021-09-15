using System;
using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.structBin.Company;
using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.Director;
using static Homework_11_ConsUI.functions.ExportImportJson;
using static Homework_11_ConsUI.functions.ExportToXml;
namespace Homework_11_ConsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Company OneCompany = new();
            OneCompany.HireBoss(new Director(OneCompany));
            OneCompany.Hire(new Intern());
            OneCompany.AutoOpen();
            OneCompany.AutoOpen();
            OneCompany.AutoOpen();
            OneCompany.WorkPlaces[0].Hire(new Worker());
            OneCompany.WorkPlaces[0].AutoOpen();
            OneCompany.WorkPlaces[1].AutoOpen();
            OneCompany.WorkPlaces[0].HireBoss(new DepartmentBoss(OneCompany.WorkPlaces[0], "Johnny", 45));
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Worker(100, "John", 18));
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Worker());
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Intern());
            foreach (var e in OneCompany.WorkPlaces) Console.WriteLine(e);
            foreach (var e in OneCompany.WorkPlaces[0].WorkPlaces[0].Workers) Console.WriteLine(e);

            OneCompany.Rename("Horns&hooves");
            Console.WriteLine(OneCompany);
            Console.WriteLine(companyDirector);
            //CompanyToJson(OneCompany);
            CompanyToXml(OneCompany);
            Console.ReadKey();
        }
    }
}
