using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    struct Company
    {
        public string companyName;
        public string CompanyName { get { return this.companyName; } set { this.companyName = value; } }
        public List<Depatments> deps { get; set; }


        public string Print()
        {
            return $"ООО {this.CompanyName}";
        }

        public void PrintCompanyDeps()
        {
            Console.WriteLine($"{"Наименование",15} " +
                $"{"Дата создания",15} " +
                $"{"Количество персонала",15} ");

            foreach (var dep in this.deps) Console.WriteLine(dep.Print());
        }

        public void PrintCompanyStaff()
        {
            Console.WriteLine($"{"ID",10} " +
                $"{"Имя",15} " +
                $"{"Фамилия",15} " +
                $"{"Возраст",10} " +
                $"{"Отдел",15} " +
                $"{"Зарплата",15} " +
                $"{"Проекты",10}");

            foreach (var dep in this.deps)
            {
                foreach (var staff in dep.staff)
                {
                    Console.WriteLine(staff.Print());
                }
            }
        }

        public void AddDep(Depatments newDep)
        {
            this.deps.Add(newDep);
        }
        public Company(string CompanyName) : this()
        {
            this.deps = new List<Depatments>();
            this.companyName = CompanyName;
        }
    }
}
