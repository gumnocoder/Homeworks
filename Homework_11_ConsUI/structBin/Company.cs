using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_ConsUI.structBin
{
    class Company : WorkPlace
    {
        public static int depsCount = 0;
        public static int DepsCount { get { return depsCount; } }

        public Company()
        {
            WorkPlaces = new();
        }

        public override void Open(Department dep)
        {
            ++depsCount;
            this.WorkPlaces.Add(dep);
        }

        public override void AutoOpen()
        {
            ++depsCount;
            this.WorkPlaces.Add(
                new Department($"DepartmentName {depsCount}")
                );
        }

        public override string ToString()
        {
            return $"Company, count of departments " +
                $"{WorkPlaces.Count}";
        }
    }
}
