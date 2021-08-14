﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    struct Depatments
    {
        #region ПОЛЯ
        /// <summary>
        /// название отдела
        /// </summary>
        public string depName;
        /// <summary>
        /// дата создания отдела
        /// </summary>
        public DateTime creationDate;

        #endregion

        #region СВОЙСТВА

        /// <summary>
        /// название отдела
        /// </summary>
        public string DepName 
        { 
            get { return this.depName; } 
            set {this.depName = value; } 
        }

        /// <summary>
        /// дата создания отдела
        /// </summary>
        public DateTime CreationDate 
        { 
            get {return this.creationDate ; } 
            set {this.creationDate = value; } 
        }

        /// <summary>
        /// коллекция сотрудников департамента
        /// </summary>
        public List<Staff> staff { get; set; }

        #endregion

        #region МЕТОДЫ

        /// <summary>
        /// проверяет вместимость департамента
        /// </summary>
        /// <returns></returns>
        public bool checkCapacity()
        {
            if (this.staff.Count < 1_000) return true;
            else return false;
        }

        /// <summary>
        /// добавляет сотрудника в коллекцию
        /// </summary>
        /// <param name="newStaff">добавляемый сотрудник</param>
        public void AddStaff(Staff newStaff)
        {
            /// если место есть добавляет
            if (checkCapacity()) this.staff.Add(newStaff);
            /// если нет выводит ошибку
            else Errors(0);
        }

        /// <summary>
        /// вывод ошибок на консоль
        /// </summary>
        /// <param name="code"></param>
        public void Errors(int code)
        {
            switch (code)
            {
                case 0:
                    Console.WriteLine("\nШтат департамента максимально раздут!\n");
                    break;
            }
        }

        /// <summary>
        /// вывод строки содержащей информацию об отделе
        /// </summary>
        /// <returns></returns>
        public string Print()
        {
            return $"{this.depName,10} {this.creationDate,10} {this.staff.Count, 5}";
        }

        /// <summary>
        /// вывод списка сотрудников текущего отдела на консоль
        /// </summary>
        public void PrintDepContent()
        {
            Console.WriteLine($"{"ID", 10} " +
                $"{"Имя", 15} " +
                $"{"Фамилия", 15} " +
                $"{"Возраст",10} " +
                $"{"Отдел", 15} " +
                $"{"Зарплата",15} " +
                $"{"Проекты", 10}");

            foreach (var staff in this.staff) Console.WriteLine(staff.Print());
        }

        #endregion

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="DepName">Название отдела</param>
        /// <param name="CreationDate">Дата создания</param>
        public Depatments(string DepName, DateTime CreationDate)
        {
            this.staff = new List<Staff>();
            this.depName = DepName;
            this.creationDate = CreationDate;
        }
    }
}
