using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    public struct Departments
    {
        #region ПОЛЯ
        /// <summary>
        /// название отдела
        /// </summary>
        string depName;
        /// <summary>
        /// дата создания отдела
        /// </summary>
        DateTime creationDate;

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
        /// удаляет сотрудника
        /// </summary>
        /// <param name="pos">по указанному индексу</param>
        public void RemoveStaff(int pos)
        {
            /// если индекс доступен
            if (pos > -1 & pos < this.staff.Count + 1)
            {
                /// если список не пуст - удаляет сотрудника из коллекции
                if (this.staff.Count != 0) this.staff.RemoveAt(pos);
                else Errors(2);
            }
            else Errors(1);
        }

        /// <summary>
        /// смена департамента одним сотрудником
        /// </summary>
        /// <param name="pos">индекс сотрудника в коллекции</param>
        /// <param name="otherDep">конечный департамент</param>
        public bool ChangeDep(int pos, Departments otherDep)
        {
            /// если индекс доступен
            if (pos > -1 & pos < this.staff.Count)
            {
                /// если есть место в конечном департаменте
                if (otherDep.checkCapacity())
                {
                    /// создаём переменную для хранения экземпляра
                    /// так как в коллекции находится только копия
                    /// и её свойствам не удастся присвоить новые значения
                    Staff s = this.staff[pos];
                    /// меняем принадлежность к департаменту
                    s.Department = otherDep.DepName;
                    /// меняем элемент коллекции -> добавляем в 
                    /// кол. другого деп. -> удаляем ненужное
                    this.staff[pos] = s;
                    otherDep.AddStaff(this.staff[pos]);
                    this.RemoveStaff(pos);
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// перемещение всех сотрудников в другой департамент
        /// </summary>
        /// <param name="otherDep">конечный департамент</param>
        public bool AllChangeDep(Departments otherDep)
        {
            /// по аналогии с методом ChangeDep()
            if (otherDep.checkCapacity())
            {
                int a = this.staff.Count;
                for (int i = 0; i < a; i++)
                {
                    Staff s = this.staff[0];
                    s.Department = otherDep.DepName;
                    this.staff[0] = s;
                    otherDep.AddStaff(this.staff[0]);
                    this.RemoveStaff(0);
                }
                return true;
            }
            else return false;
        }

        /// <summary>
        /// проверяет находится ли в допустимом диапазоне
        /// </summary>
        /// <param name="pos">указанный индекс </param>
        /// <returns></returns>
        public bool CheckPos(int pos)
        {
            if (pos > -1 & pos < this.staff.Count) return true;
            else return false;
        }

        /// <summary>
        /// меняет имя
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="newName"></param>
        public bool ChangeStaffName(int pos, string newName)
        {
            if (CheckPos(pos))
            {
                Staff s = this.staff[pos];
                s.FirstName = newName;
                this.staff[pos] = s;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// меняет фамилию
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="newLastName"></param>
        public bool ChangeStaffLastName(int pos, string newLastName)
        {
            if (CheckPos(pos))
            {
                Staff s = this.staff[pos];
                s.LastName = newLastName;
                this.staff[pos] = s;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// изменение возраста
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="newAge"></param>
        public bool ChangeAge(int pos, int newAge)
        {
            if (CheckPos(pos))
            {
                Staff s = this.staff[pos];
                s.Age = newAge;
                this.staff[pos] = s;
                return true;
            }
            else return false;
        }
        /// <summary>
        /// изменение зп
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="newSalary"></param>
        public bool ChangeSalary(int pos, int newSalary)
        {
            if (CheckPos(pos))
            {
                Staff s = this.staff[pos];
                s.Salary = newSalary;
                this.staff[pos] = s;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// изменение текущих проектов
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="newProjects"></param>
        public bool ChangeProjects(int pos, int newProjects)
        {
            if (CheckPos(pos))
            {
                Staff s = this.staff[pos];
                s.ProjectsCount = newProjects;
                this.staff[pos] = s;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// вывод ошибок на консоль
        /// </summary>
        /// <param name="code"></param>
        public static void Errors(int code)
        {
            switch (code)
            {
                case 0:
                    Console.WriteLine("\nШтат департамента максимально раздут!\n");
                    break;
                case 1:
                    Console.WriteLine("\nИндекс находится за пределами размера данного департамента!\n");
                    break;
                case 2:
                    Console.WriteLine("\nВ департаменте нет работников!\n");
                    break;
                case 3:
                    Console.WriteLine("\nНет места для перевода в данный департамент, выберите другой.\n");
                    break;
                case 4:
                    Console.WriteLine("\nНужно ввести целое положительное число\n");
                    break;
                case 5:
                    Console.WriteLine("Введено недопустимое значение, попробуйте снова!");
                    break;
                case 6:
                    Console.WriteLine("В организации нет департаментов!");
                    break;
                case 7:
                    Console.WriteLine("В департаменте нет сотрудников!");
                    break;
                case 8:
                    Console.WriteLine("Файл отсутствует!");
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
        public Departments(string DepName, DateTime CreationDate)
        {
            this.staff = new List<Staff>();
            this.depName = DepName;
            this.creationDate = CreationDate;
        }
    }
}
