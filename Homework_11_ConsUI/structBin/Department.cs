using Homework_11_ConsUI.employeBin;

namespace Homework_11_ConsUI.structBin
{
    class Department : WorkPlace
    {
        static int officeCount = 0;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Name"></param>
        public Department(string Name)
        {
            Workers = new();
            this.WorkPlaces = new();
            this.Name = Name;
        }

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
        }
        public override void HireBoss(DepartmentBoss depBoss)
        {
            this.Boss = depBoss.Name;
            this.BossSalary = depBoss.MonthlySalary();
        }
    }
}
