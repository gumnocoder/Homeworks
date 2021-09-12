using System.Collections.Generic;
using Homework_11_ConsUI.employeBin;
namespace Homework_11_ConsUI.structBin
{
    abstract class WorkPlace
    {
        /// <summary>
        /// список сотрудников
        /// </summary>
        public List<Employe> Workers { get; set; }
        /// <summary>
        /// список отделов
        /// </summary>
        public List<WorkPlace> WorkPlaces { get; set; }

        public string Name { get; set; }
        public string Boss { get; set; }

        public int BossSalary { get; set; }


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
