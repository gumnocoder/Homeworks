using System;

namespace Homework_8
{
    class Program
    {
        public static void delay()
        {
            Console.WriteLine($"press anykey");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            Company com = new Company("Horns&Hooves");
            
            Depatments dep = new Depatments("отдел_1", DateTime.Now);
            
            com.AddDep(new Depatments("отдел_0", DateTime.Now));

            Staff worker = new Staff("Уважаемый", "Гражданин", 15, dep.depName, 10000, 3);

            com.AddDep(dep);
            com.deps[0].AddStaff(new Staff("уважаемый", "Гражданин_0", 15, com.deps[0].depName, 20000, 1));
            com.deps[0].AddStaff(new Staff("уважаемый", "Гражданин_0", 15, com.deps[0].depName, 20000, 1));
            com.deps[0].AddStaff(new Staff("уважаемый", "Гражданин_1", 15, com.deps[0].depName, 20000, 1));
            com.deps[0].AddStaff(new Staff("уважаемый", "Гражданин_2", 15, com.deps[0].depName, 20000, 1));
            com.deps[0].AddStaff(new Staff("уважаемый", "Гражданин_3", 15, com.deps[0].depName, 20000, 1));
            com.deps[0].AddStaff(new Staff("уважаемый", "Гражданин_4", 15, com.deps[0].depName, 20000, 1));
            com.deps[0].AddStaff(new Staff("уважаемый", "Гражданин_5", 15, com.deps[0].depName, 20000, 1));
            com.deps[0].AddStaff(new Staff("уважаемый", "Гражданин_6", 15, com.deps[0].depName, 20000, 1));

            delay();

            com.PrintCompanyDeps();
            com.PrintCompanyStaff();

            delay();

            com.deps[0].AllChangeDep(com.deps[1]);

            com.PrintCompanyDeps();
            com.PrintCompanyStaff();

            com.deps[1].ChangeDep(0, com.deps[0]);

            com.deps[0].PrintDepContent();
            com.deps[1].PrintDepContent();

            delay();

            ////com.deps[0].Print();
            //Console.WriteLine($"press anykey");
            //Console.ReadKey();
            //com.deps[0].AddStaff(new Staff("Неуважаемый_1", "Гражданин_0", 15, com.deps[0].depName, 20000, 1));
            //Console.WriteLine(com.deps[0].Print());
            //com.deps[0].RemoveStaff(0);
            //Console.WriteLine($"press anykey");
            //Console.ReadKey();
            //Console.WriteLine(com.deps[0].Print());
            //com.deps[0].RemoveStaff(0);
            //Console.WriteLine($"press anykey");
            //Console.ReadKey();
            //com.deps[0].AddStaff(new Staff("Неуважаемый_1", "Гражданин_0", 15, com.deps[0].depName, 20000, 1));
            //com.RemoveDep(0);
            ////Console.WriteLine(com.deps[0].Print());
            //Console.ReadKey();



            //com.deps[0].AddStaff(new Staff("Неуважаемый_2", "Гражданин_1", 15, com.deps[0].depName, 22222, 2));
            //Console.WriteLine(com.deps[0].Print());
            //Console.ReadKey();
            //com.deps[1].AddStaff(new Staff("Неуважаемый_3", "Гражданин_2", 15, com.deps[1].depName, 25000, 3));
            //Console.ReadKey();


            ////com.deps[0].PrintDepContent();
            ////Console.WriteLine(com.deps[0].staff[0].Print());
            ////Console.WriteLine(com.deps[0].staff.Count);

            ////Console.ReadKey();
            ////Console.Clear();
            ////Console.WriteLine(dep.Print());
            ////Console.ReadKey();
            ///// string FirstName, string LastName, int Age, string Department, int Salary, int ProjectsCount

            //dep.AddStaff(new Staff("Уважаемый", "Гражданин", 15, dep.depName, 10000, 3));
            //dep.AddStaff(new Staff("Уважаемый_2", "Гражданин_2", 15, dep.depName, 20000, 1));
            //dep.AddStaff(worker);
            //Console.WriteLine(dep.Print());
            //Console.WriteLine(worker.Print());
            //com.PrintCompanyDeps();
            //com.PrintCompanyStaff();
            ////dep.PrintDepContent();
            //Console.ReadKey();

            ////Console.Clear();
            ////com.deps[1].Print();
            ////Console.WriteLine(com.deps[1].staffCount);


            //Console.ReadKey();
            //Console.Clear();
            //Console.WriteLine();
            //com.PrintCompanyDeps();
            //Console.WriteLine();
            //com.PrintCompanyStaff();
            //Console.WriteLine();
            //Console.ReadKey();

            //Console.WriteLine(dep.staff[0].Print());
            //Console.ReadKey();
        }
    }
}
