﻿using System;
using Homework_11_ConsUI.employeBin;
using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.functions.ExportToJson;
using static Homework_11_ConsUI.functions.ExportToXml;
using static Homework_11_ConsUI.structBin.OrgStructure;

namespace Homework_11_ConsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Company OneCompany = new();
            OneCompany.HireBoss(new Director(OneCompany));
            OneCompany.Hire(new Worker(100, "AAAAAAAA", 18));
            if (OneCompany.Workers.Count > 0) Console.WriteLine("true"); else Console.WriteLine("False");
            OneCompany.Sack(OneCompany.Workers[0]);
            if (OneCompany.Workers.Count > 0) Console.WriteLine("true"); else Console.WriteLine("False");
            OneCompany.AutoOpen();
            OneCompany.AutoOpen();
            OneCompany.AutoOpen();
            OneCompany.WorkPlaces[0].Hire(new Worker());
            OneCompany.WorkPlaces[0].Hire(new Worker(100, "John", 18));
            OneCompany.WorkPlaces[0].Hire(new Worker(1, "Jo4hn", 18));
            OneCompany.WorkPlaces[0].Hire(new Worker(1, "Jdohn", 18));
            OneCompany.WorkPlaces[0].Hire(new Worker(1, "Johhhgn", 18));
            OneCompany.WorkPlaces[0].AutoOpen();
            OneCompany.WorkPlaces[1].AutoOpen();
            OneCompany.WorkPlaces[0].HireBoss(new DepartmentBoss(OneCompany.WorkPlaces[0], "Johnny", 45));
            Console.WriteLine(OneCompany.WorkPlaces[0].Boss + " " + OneCompany.WorkPlaces[0].BossSalary);
            OneCompany.WorkPlaces[0].SackBoss();
            Console.WriteLine(OneCompany.WorkPlaces[0].Boss + " " + OneCompany.WorkPlaces[0].BossSalary);
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Worker(1, "John", 18));
            Console.WriteLine(OneCompany.WorkPlaces[0].WorkPlaces[0].Workers[0]);
            OneCompany.WorkPlaces[0].WorkPlaces[0].Workers[0].Rename("Vladilen");
            Console.WriteLine(OneCompany.WorkPlaces[0].WorkPlaces[0].Workers[0]);
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Worker());
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Intern());
            foreach (var e in OneCompany.WorkPlaces) Console.WriteLine(e);
            foreach (var e in OneCompany.WorkPlaces[0].WorkPlaces[0].Workers) Console.WriteLine(e);
            OneCompany.WorkPlaces[0].WorkPlaces[0].Hire(new Worker(1, "John", 18));
            OneCompany.Rename("Horns&hooves");
            Console.WriteLine(OneCompany);
            Console.WriteLine(OneCompany.Boss);
            CompanyToJson(OneCompany);
            OneCompany.SetBossSalary(OneCompany);
            CompanyToXml(OneCompany);
            Console.WriteLine(OneCompany.BossSalary);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            
            foreach (var e in workPlacesGlobal)
            {
                Console.WriteLine(e);
            }
            Console.ReadKey();
        }
    }
}
