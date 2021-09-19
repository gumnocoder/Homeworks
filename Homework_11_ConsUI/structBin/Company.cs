using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.structBin.OrgStructure;

namespace Homework_11_ConsUI.structBin
{
    public sealed class Company : WorkPlace
    {
        internal static int depsCount = 0;

        static int companyOffices = 0;

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
            RefreshBossesSalary();
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

        public override void Open()
        {
            ++companyOffices;
            this.WorkPlaces.Add(
                new Office($"OfficeName {companyOffices}"
                ));
        }

        public override void OpenDep()
        {
            ++depsCount;
            this.WorkPlaces.Add(
                new Department($"DepartmentName {depsCount}"
                ));
        }

        //public override void AutoOpen()
        //{
        //    ++depsCount;
        //    this.WorkPlaces.Add(
        //        new Department($"DepartmentName {depsCount}")
        //        );
        //}

        public override string ToString()
        {
            return $"Company {Name}, " +
                $"count of departments " +
                $"{WorkPlaces.Count} {Boss}{BossSalary}";
        }
    }
}
