﻿using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.structBin.OrgStructure;

namespace Homework_11_ConsUI.structBin
{
    public class Department : WorkPlace
    {
        //string boss;
        //new public string Boss { get { return boss; } set { boss = value; } }

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
            workPlacesGlobal.Add(this);
        }

        public Department() { }

        /// <summary>
        /// открыть подотдел
        /// </summary>
        /// <param name="office"></param>
        public override void Open(Office office)
        {
            ++officeCount;
            this.WorkPlaces.Add(office);
        }

        public override void OpenDep()
        {
            ++Company.depsCount;
            this.WorkPlaces.Add(
                new Department($"DepartmentName {Company.depsCount}")
                );
        }

        /// <summary>
        /// открыть подотдел с параметрами по умолчанию
        /// </summary>
        public override void Open()
        {
            ++officeCount;
            this.WorkPlaces.Add(new Office($"Office #{officeCount}"));
        }

        public override string ToString()
        {
            return $"{Name} \n\n" +
                $"---------------------\n\n" +
                $"Substructs count: {WorkPlaces.Count}\n" +
                $"Workers count: {Workers.Count}\n\n" +
                $"Boss: {Boss}\n" +
                $"Boss monthly salary: {BossSalary}";
        }



        /// <summary>
        /// найм управляющего
        /// </summary>
        /// <param name="depBoss"></param>
        public override void HireBoss(DepartmentBoss depBoss)
        {
            Boss = depBoss.Name;
            //BossSalary = SetBossSalary(this);
        }
    }
}
