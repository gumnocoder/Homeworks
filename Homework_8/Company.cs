using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    public struct Company
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
        public List<Departments> deps { get; set; }

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
        public void AddDep(Departments newDep)
        {
            this.deps.Add(newDep);
        }

        /// <summary>
        /// вывод ошибки при удалении непустого департамента
        /// </summary>
        public void Error()
        {
            Console.WriteLine("Невозможно удалить департамент, пока в нём числятся сотрудники!" +
                "\nпереведите их в другой отдел перед удалением.");
        }

        /// <summary>
        ///  метод удаления департамента
        /// </summary>
        /// <param name="pos"></param>
        public void RemoveDep(int pos)
        {
            /// если департамент пуст
            if (this.deps[pos].staff.Count == 0)
            {
                /// удаляем
                this.deps.RemoveAt(pos);
            }
            else Error();
        }

        /// <summary>
        /// проверяет находится ли в допустимом диапазоне
        /// </summary>
        /// <param name="pos">указанный индекс </param>
        /// <returns></returns>
        public bool CheckPos(int pos)
        {
            if (pos > 0 & pos < this.deps.Count) return true;
            else return false;
        }

        /// <summary>
        /// проверяет валидность ввода даты
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool CheckDate(string date)
        {
            if (DateTime.TryParse(date, out DateTime tmp)) return true;
            else return false;
        }

        /// <summary>
        /// ползволяет отредактировать название департамента
        /// </summary>
        /// <param name="pos">индекс</param>
        /// <param name="newName">новое название</param>
        public void EditDepName(int pos, string newName)
        {
            if (CheckPos(pos))
            {
                /// создаём переменную для хранения экземпляра
                /// так как в коллекции находится только копия
                /// и её свойствам не удастся присвоить новые значения
                Departments d = this.deps[pos];
                /// меняем имя
                d.DepName = newName;
                this.deps[pos] = d;
                if (d.staff.Count > 0)
                {
                    for (int i = 0; i < d.staff.Count; i++)
                    {
                        d.ChangeDep(i, d);
                    }
                }
            }
        }

        /// <summary>
        /// позволяет оредактировать дату создания департамента
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="newDate"></param>
        public void EditDepDate(int pos, string newDate)
        {
            if (CheckPos(pos) & CheckDate(newDate))
            {
                Departments d = this.deps[pos];
                d.CreationDate = DateTime.Parse(newDate);
                this.deps[pos] = d;
            }
        }

        #endregion

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="CompanyName"></param>
        public Company(string CompanyName) : this()
        {
            this.deps = new List<Departments>();
            this.companyName = CompanyName;
        }
    }
}
