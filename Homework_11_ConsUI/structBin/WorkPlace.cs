using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;

namespace Homework_11_ConsUI.structBin
{
    [XmlInclude(typeof(Department))]
    [XmlInclude(typeof(Office))]
    [XmlInclude(typeof(Company))]
    public abstract class WorkPlace
    {
        /// <summary>
        /// список сотрудников
        /// </summary>
        public List<Employe> Workers { get; set; }

        /// <summary>
        /// список отделов
        /// </summary>
        public List<WorkPlace> WorkPlaces { get; set; }

        string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        string boss;
        public string Boss
        {
            get { return boss; }
            set { boss = value; }
        }

        int bossSalary;
        public int BossSalary
        {
            get { return bossSalary; }
            set { bossSalary = value; }
        }

        /// <summary>
        /// найм работников
        /// </summary>
        /// <param name="intern">работник</param>
        public virtual void Hire(Employe employe) { }

        /// <summary>
        /// найм начальника
        /// </summary>
        /// <param name="depBoss">нанимаемый начальник</param>
        public virtual void HireBoss(DepartmentBoss depBoss) { }

        public virtual void HireBoss(Director director) { }
        public virtual void HireBoss(OfficeManager officeManager) { }

        public virtual int SetBossSalary(WorkPlace workPlace) { 
            if (this.Boss != null) return CountAdminSalary(workPlace); 
            else return 0; 
        }
        public virtual void Sack() { }

        /// <summary>
        /// создаёт отдел
        /// </summary>
        /// <param name="dep">отдел</param>
        public virtual void Open(Department dep) { }

        /// <summary>
        /// создаёт подотдел
        /// </summary>
        /// <param name="office">подотдел</param>
        public virtual void Open(Office office) { }

        /// <summary>
        /// автоматическое создание отдела
        /// </summary>
        public virtual void AutoOpen() { }

        public virtual void Close() { }

        /// <summary>
        /// переименование отдела или компании
        /// </summary>
        /// <param name="newName"></param>
        public virtual void Rename(string newName) { this.Name = newName; }
    }
}
