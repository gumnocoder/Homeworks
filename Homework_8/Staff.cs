using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homework_8
{
    public struct Staff
    {
        static string source = "number.ini";

        #region ПОЛЯ
        /// <summary>
        /// имя
        /// </summary>
        string firstName;

        /// <summary>
        /// фамилия
        /// </summary>
        string lastName;

        /// <summary>
        /// департамент
        /// </summary>
        string department;

        /// <summary>
        /// уникальный номер
        /// </summary>
        int number;

        /// <summary>
        /// возраст
        /// </summary>
        int age;

        /// <summary>
        /// зарплата
        /// </summary>
        int salary;

        /// <summary>
        /// количество открытых проектов
        /// </summary>
        int projectsCount;

        #endregion

        #region СВОЙСТВА

        /// <summary>
        /// имя
        /// </summary>
        public string FirstName 
        { 
            get { return this.firstName; } 
            set { this.firstName = value; } 
        }

        /// <summary>
        /// фамилия
        /// </summary>
        public string LastName 
        { 
            get { return this.lastName; } 
            set { this.lastName = value; } 
        }

        /// <summary>
        /// департамент
        /// </summary>
        public string Department 
        { 
            get { return this.department; } 
            set { this.department = value; } 
        }

        /// <summary>
        /// уникальный номер
        /// </summary>
        public int Number 
        { 
            get { return this.number; } 
            set { this.number = value; } 
        }

        /// <summary>
        /// возраст
        /// </summary>
        public int Age 
        { 
            get { return this.age; } 
            set { this.age = value; } 
        }

        /// <summary>
        /// зарплата
        /// </summary>
        public int Salary 
        { 
            get { return this.salary; } 
            set { this.salary = value; } 
        }

        /// <summary>
        /// количество проектов
        /// </summary>
        public int ProjectsCount 
        { 
            get { return this.projectsCount; } 
            set { this.projectsCount = value; } 
        }
        #endregion

        #region МЕТОДЫ

        public void createNumFile()
        {
            using FileStream fs = File.Create(source);
        }

        public void numFileFillFirst()
        {
            string firstNum = "1";
            File.AppendAllText(source, firstNum);
        }

        /// <summary>
        /// возвращает строку содержащую все данные текущей еденицы
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"" +
                $"{this.number,10} " +
                $"{this.firstName, 15} " +
                $"{this.lastName, 15} " +
                $"{this.age,10} " +
                $"{this.department, 15} " +
                $"{this.salary, 15} " +
                $"{this.projectsCount,10}";
        }

        /// <summary>
        /// проверяет наличие файла содержащего текущий номер-идентификатор
        /// </summary>
        /// <returns></returns>
        public bool CheckNumFile()
        {
            
            if (!File.Exists(source)) return true;
            else return false;
        }

        /// <summary>
        /// парсит файл с номером-идентификатором
        /// </summary>
        /// <returns></returns>
        public int ParseFile()
        {
            string tmp = File.ReadAllText(source);
            return int.Parse(tmp);
        }

        /// <summary>
        /// запускает цепочку для возврата нового номера идентификатора
        /// </summary>
        /// <returns></returns>
        public int Count() 
        {
            /// если файла нет
            if (CheckNumFile())
            {
                /// создает
                createNumFile();
                ///записывает туда 1
                numFileFillFirst();
                return 1;
            }
            ///если файл есть
            else
            {
                return ParseFile();
            }
        }

        /// <summary>
        /// записывает новые данные в файл
        /// </summary>
        /// <param name="nextNum"></param>
        public void WriteNewNum(int nextNum)
        {
            File.WriteAllText(source, nextNum.ToString());
        }

        #endregion

        #region КОНСТРУКТОР

        /// <summary>
        /// конструктов 6 атрибутов
        /// </summary>
        /// <param name="FirstName">имя</param>
        /// <param name="LastName">фамилия</param>
        /// <param name="Age">возраст</param>
        /// <param name="Department">департамент</param>
        /// <param name="Salary">зарплата</param>
        /// <param name="ProjectsCount">проекты</param>
        public Staff(string FirstName, string LastName, int Age, string Department, int Salary, int ProjectsCount) : this()
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.department = Department;
            this.number = Count();
            this.age = Age;
            this.salary = Salary;
            this.projectsCount = ProjectsCount;
            this.WriteNewNum(this.number + 1);
        }
        #endregion
    }
}
