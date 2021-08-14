using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    struct Depatments
    {
        public string depName;
        public DateTime creationDate;

        public string DepName { get { return this.depName; } set {this.depName = value; } }
        public DateTime CreationDate { get {return this.creationDate ; } set {this.creationDate = value; } }
       
        public List<Staff> staff { get; set; }

        public Depatments(string DepName, DateTime CreationDate)
        {
            this.staff = new List<Staff>();
            this.depName = DepName;
            this.creationDate = CreationDate;
        }

        public void AddStaff(Staff newStaff)
        {
            this.staff.Add(newStaff);
        }
        public string Print()
        {
            return $"{this.depName,10} {this.creationDate,10} {this.staff.Count, 5}";
        }

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
    }
}
