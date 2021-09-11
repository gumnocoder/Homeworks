using Homework_11_ConsUI.employeBin;

namespace Homework_11_ConsUI.structBin
{
    class Department : WorkPlace
    {
        static int officeCount = 0;
        public static int OfficeCount { get { return officeCount; } }

        public Department(string Name)
        {
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

        public override void Hire(DepartmentBoss depBoss)
        {
            this.Boss = depBoss;
        }
    }
}
