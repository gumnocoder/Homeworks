using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.Director;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;
using static Homework_11_ConsUI.structBin.OrgStructure;
using System;

namespace Homework_11_ConsUI.structBin
{
    public sealed class Company : WorkPlace
    {

        //int bossSalary;
        //public int BossSalary { get { return bossSalary; } set { bossSalary = value; } }

        static int depsCount = 0;

        /// <summary>
        /// директор
        /// </summary>
        //public static Director companyDirector;


        /// <summary>
        /// конструктор
        /// </summary>
        public Company()
        {
            Name = "'Best Coders' corp.";
            WorkPlaces = new();
            Workers = new();
            workPlacesGlobal.Add(this);
        }

        public override void Hire(Employe employe)
        {
            this.Workers.Add(employe);
            //this.BossSalary = SetBossSalary(this);
            RefreshBossesSalary();
        }

        /// <summary>
        /// найм директора
        /// </summary>
        /// <param name="director"></param>
        public override void HireBoss(Director director)
        {
            //companyDirector = director;
            this.Boss = director.Name;
            this.BossSalary = SetBossSalary(this);
        }

        public override void Open(Department dep)
        {
            ++depsCount;
            this.WorkPlaces.Add(dep);
        }

        public override void AutoOpen()
        {
            ++depsCount;
            this.WorkPlaces.Add(
                new Department($"DepartmentName {depsCount}")
                );
        }

        public override string ToString()
        {
            return $"Company {Name}, " +
                $"count of departments " +
                $"{WorkPlaces.Count} {Boss}{BossSalary}";
        }
    }
}
