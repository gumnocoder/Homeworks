using Homework_11_ConsUI.employeBin;

namespace Homework_11_ConsUI.structBin
{
    class Office : WorkPlace
    {
        public Office(string Name)
        {
            this.Name = Name;
            Workers = new();
        }

        public override void Hire(Employe employe)
        {
            Workers.Add(employe);
        }

        public override void HireBoss(OfficeManager officeManager)
        {
            this.Boss = officeManager.Name;
            this.BossSalary = officeManager.MonthlySalary();
        }
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
