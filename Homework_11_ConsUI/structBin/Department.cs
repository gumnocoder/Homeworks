using System;
using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;
using static Homework_11_ConsUI.structBin.OrgStructure;

namespace Homework_11_ConsUI.structBin
{
    public class Department : WorkPlace
    {

        static int officeCount = 0;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Name"></param>
        public Department(string Name)
        {
            Workers = new();
            WorkPlaces = new();
            this.Name = Name;
            //BossSalary = SetBossSalary(this);
            workPlacesGlobal.Add(this);
        }

        public Department() { }
        public override void Open(Office office)
        {
            ++officeCount;
            this.WorkPlaces.Add(office);
        }

        public override void AutoOpen()
        {
            this.WorkPlaces.Add(new Office($"Office #{officeCount}"));
        }
        public override string ToString()
        {
            return $"Department {Name}";
        }

        public override void Hire(Employe employe)
        {
            this.Workers.Add(employe);
            BossSalary = SetBossSalary(this);
            RefreshBossesSalary();
        }
        public override void HireBoss(DepartmentBoss depBoss)
        {
            Boss = depBoss.Name;
            BossSalary = SetBossSalary(this);
            //this.BossSalary = depBoss.MonthlySalary();
        }

        //public int SetBossSalary()
        //{
        //    Console.WriteLine("SetBossSalary");
        //    return CountAdminSalary(this);
        //}
    }
}
