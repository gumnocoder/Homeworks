using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Homework_8
{
    struct Staff
    {
        static string source = "number.ini";

        #region ПОЛЯ
        /// <summary>
        /// имя
        /// </summary>
        public string firstName;

        /// <summary>
        /// фамилия
        /// </summary>
        public string lastName;

        /// <summary>
        /// департамент
        /// </summary>
        public string department;

        /// <summary>
        /// уникальный номер
        /// </summary>
        public int number;

        /// <summary>
        /// возраст
        /// </summary>
        public int age;

        /// <summary>
        /// зарплата
        /// </summary>
        public int salary;

        /// <summary>
        /// количество открытых проектов
        /// </summary>
        public int projectsCount;

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
        private int Number 
        { 
            get { return this.number; } 
            // set { this.number = value; } 
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
                $"{this.number, 5} " +
                $"{this.firstName, 10} " +
                $"{this.lastName, 10} " +
                $"{this.age, 5} " +
                $"{this.department, 15} " +
                $"{this.salary, 10} " +
                $"{this.projectsCount, 5}";
        }

        public bool CheckNumFile()
        {
            
            if (!File.Exists(source)) return true;
            else return false;
        }

        public int ParseFile()
        {
            string tmp = File.ReadAllText(source);
            return int.Parse(tmp);
        }
        public int Count() 
        {
            if (CheckNumFile())
            {
                createNumFile();
                numFileFillFirst();
                return 1;
            }  
            else
            {
                return ParseFile();
            }
        }

        public void WriteNewNum(int nextNum)
        {
            File.WriteAllText(source, nextNum.ToString());
        }

        #endregion

        #region КОНСТРУКТОР

        /// <summary>
        /// конструктов 7 атрибутов
        /// </summary>
        /// <param name="Number">уникальный номер</param>
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
