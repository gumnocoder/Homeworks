﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Xml.Serialization;
using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;

namespace Homework_11_ConsUI.structBin
{
    [XmlInclude(typeof(Department))]
    [XmlInclude(typeof(Office))]
    [XmlInclude(typeof(Company))]
    public abstract class WorkPlace : NamedObject
    {
        ObservableCollection<Employe> workers;
        /// <summary>
        /// список сотрудников
        /// </summary>
        public ObservableCollection<Employe> Workers
        {
            get { return workers; }
            set { workers = value; }
        }

        ObservableCollection<WorkPlace> workPlaces;
        /// <summary>
        /// список отделов
        /// </summary>
        public ObservableCollection<WorkPlace> WorkPlaces {
            get { return workPlaces; }
            set { workPlaces = value; }
        }

        string boss;
        /// <summary>
        /// Управляющий
        /// </summary>
        public string Boss
        {
            get { return boss; }
            set { boss = value; }
        }

        int bossSalary;
        /// <summary>
        /// Зарплата управляющего
        /// </summary>
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
        public virtual void HireBoss(DepartmentBoss depBoss) { Debug.WriteLine(depBoss.Name); }
        /// <summary>
        /// найм управляющего
        /// </summary>
        /// <param name="director"></param>
        public virtual void HireBoss(Director director) { }
        /// <summary>
        /// найм директора
        /// </summary>
        /// <param name="officeManager"></param>
        public virtual void HireBoss(OfficeManager officeManager) { }

        /// <summary>
        /// устанавливает зп управляющего
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
        public virtual int SetBossSalary(WorkPlace workPlace) {
            if (Boss != null) {
                return CountAdminSalary(workPlace);
            }
            else return 0;
        }

        /// <summary>
        /// увольнение сотрудника
        /// </summary>
        /// <param name="employe"></param>
        public virtual void Sack(Employe employe) {
            this.Workers.Remove(employe);
        }

        /// <summary>
        /// увольнение босса
        /// </summary>
        public virtual void SackBoss() {
            this.Boss = null;
            this.bossSalary = 0;
        }

        /// <summary>
        /// создаёт отдел
        /// </summary>
        /// <param name="dep">отдел</param>
        public virtual void Open(Department dep) { }
        /// <summary>
        /// для автоматического создания отдела
        /// </summary>
        public virtual void Open() { }

        /// <summary>
        /// автоматическое создание департамента
        /// </summary>
        public virtual void OpenDep() { }

        /// <summary>
        /// создаёт подотдел
        /// </summary>
        /// <param name="office">подотдел</param>
        public virtual void Open(Office office) { }


        /// <summary>
        /// закрыть отдел
        /// </summary>
        /// <param name="workPlace"></param>
        public virtual void Close(WorkPlace workPlace) { 
            this.workPlaces.Remove(workPlace); 
        }
    }
}
