using Homework_11_ConsUI.employeBin;

namespace Homework_11_ConsUI.structBin
{
    class Office : WorkPlace
    {
        static int subOfficesCount = 0;
        public Office(string Name)
        {
            this.Name = Name;
            Workers = new();
            WorkPlaces = new();
        }

        public override void Hire(Employe employe)
        {
            Workers.Add(employe);
        }

        public override void Open(Office office)
        {
            ++subOfficesCount;
            WorkPlaces.Add(office);
        }

        public override void AutoOpen()
        {
            WorkPlaces.Add(new Office($"Sub-office #{subOfficesCount}"));
        }
        public override void HireBoss(OfficeManager officeManager)
        {
            this.Boss = officeManager.Name;
            this.BossSalary = officeManager.MonthlySalary();
        }


        public override string ToString()
        {
            return $"{Name}, workers {Workers.Count}, sub-structures: {WorkPlaces.Count}";
        }
    }
}
