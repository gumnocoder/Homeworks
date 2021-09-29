using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.structBin.OrgStructure;

namespace Homework_11_ConsUI.structBin
{
    public sealed class Company : WorkPlace
    {
        public static int depsCount = 0;

        public static int companyOffices = 0;

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

        /// <summary>
        /// найм директора
        /// </summary>
        /// <param name="director"></param>
        public override void HireBoss(Director director)
        {
            this.Boss = director.Name;
            this.BossSalary = SetBossSalary(this);
        }

        /// <summary>
        /// автоматическое открытие офиса
        /// </summary>
        public override void Open()
        {
            ++companyOffices;
            this.WorkPlaces.Add(
                new Office($"OfficeName {companyOffices}"
                ));
        }
        public override void Open(Office office)
        {
            ++companyOffices;
            this.WorkPlaces.Add(office);
        }

        public override void Open(Department department)
        {
            ++depsCount;
            this.WorkPlaces.Add(department);
        }

        public override void OpenDep()
        {
            ++depsCount;
            this.WorkPlaces.Add(
                new Department($"DepartmentName {depsCount}"
                ));
        }
    }
}
