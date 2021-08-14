using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    struct Staff
    {
        #region ПОЛЯ
        public string firstName;
        public string lastName;
        public string department;
        public int number;
        public int age;
        public int salary;
        public int projectsCount;
        #endregion

        #region СВОЙСТВА
        public string FirstName 
        { 
            get { return this.firstName; } 
            set { this.firstName = value; } 
        }
        public string LastName 
        { 
            get { return this.lastName; } 
            set { this.lastName = value; } 
        }
        public string Department 
        { 
            get { return this.department; } 
            set { this.department = value; } 
        }
        public int Number 
        { 
            get { return this.number; } 
            set { this.number = value; } 
        }
        public int Age 
        { 
            get { return this.age; } 
            set { this.age = value; } 
        }
        public int Salary 
        { 
            get { return this.salary; } 
            set { this.salary = value; } 
        }
        public int ProjectsCount 
        { 
            get { return this.projectsCount; } 
            set { this.projectsCount = value; } 
        }
        #endregion

        #region КОНСТРУКТОР
        public Staff(int Number, string FirstName, string LastName, int Age, string Department, int Salary, int ProjectsCount)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.department = Department;
            this.number = Number;
            this.age = Age;
            this.salary = Salary;
            this.projectsCount = ProjectsCount;
        }
    }
}
