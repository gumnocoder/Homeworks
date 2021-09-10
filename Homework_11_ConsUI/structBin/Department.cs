using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Homework_11_ConsUI.structBin.Company;

namespace Homework_11_ConsUI.structBin
{
    class Department : WorkPlace
    {
        static int officeCount = 0;
        public static int OfficeCount { get { return officeCount; } }

        public Department(string Name)
        {
            Offices = new();
            this.Name = Name;
        }

        public override void Open(Office office)
        {
            ++officeCount;
            Offices.Add(office);
        }

        public void AutoOpen()
        {
            Offices.Add(new Office($"Office #{officeCount}"));
        }
        public override string ToString()
        {
            return $"Department {Name}";
        }
    }
}
