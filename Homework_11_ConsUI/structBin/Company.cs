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

        protected List<Department> departments;
        public List<Department> Departments { get; set; }

        public Company()
        {
            this.departments = Departments;
            Departments = new();
        }

        public override void Open(Department dep)
        {
            ++depsCount;
            this.Departments.Add(dep);
        }

        public void AutoOpen()
        {
            ++depsCount;
            this.Departments.Add(
                new Department($"DepartmentName {depsCount}")
                );
        }

        public override string ToString()
        {
            return $"Company, count of departments " +
                $"{Departments.Count}";
        }
    }
}
