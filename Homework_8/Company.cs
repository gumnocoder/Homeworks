using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    struct Company
    {
        #region ПОЛЯ и СВОЙСТВА

        /// <summary>
        /// Наименование компании
        /// </summary>
        public string companyName;

        public string CompanyName 
        { 
            get { return this.companyName; } 
            set { this.companyName = value; } 
        }
        
        /// <summary>
        /// Коллекция департаментов компании
        /// </summary>
        public List<Depatments> deps { get; set; }

        #endregion

        #region МЕТОДЫ

        /// <summary>
        /// выводит информацию о компании
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"ООО {this.CompanyName}";
        }
        /// <summary>
        /// выводит список департаментов компании
        /// </summary>
        public void PrintCompanyDeps()
        {
            Console.WriteLine($"{"Наименование",15} " +
                $"{"Дата создания",15} " +
                $"{"Количество персонала",15} ");

            foreach (var dep in this.deps) Console.WriteLine(dep.Print());
        }
        /// <summary>
        /// выводит список всех сотрудников компании из всех деп.
        /// </summary>
        public void PrintCompanyStaff()
        {
            Console.WriteLine($"{"ID",10} " +
                $"{"Имя",15} " +
                $"{"Фамилия",15} " +
                $"{"Возраст",10} " +
                $"{"Отдел",15} " +
                $"{"Зарплата",15} " +
                $"{"Проекты",10}");

            /// перебирает департаменты
            foreach (var dep in this.deps)
            {
                /// перебирает сотрудников в них
                foreach (var staff in dep.staff)
                {
                    /// выводит на консоль
                    Console.WriteLine(staff.Print());
                }
            }
        }

        /// <summary>
        /// метод добавления департамента
        /// </summary>
        /// <param name="newDep"></param>
        public void AddDep(Depatments newDep)
        {
            this.deps.Add(newDep);
        }

        #endregion

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="CompanyName"></param>
        public Company(string CompanyName) : this()
        {
            this.deps = new List<Depatments>();
            this.companyName = CompanyName;
        }
    }
}
