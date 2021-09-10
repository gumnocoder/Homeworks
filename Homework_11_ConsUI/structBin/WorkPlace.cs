using System.Collections.Generic;
using Homework_11_ConsUI.employeBin;
namespace Homework_11_ConsUI.structBin
{
    abstract class WorkPlace
    {
        public List<Employe> Workers { get; set; }
        //public List<Intern> Workers { get; set; }
        public List<Department> Departments { get; set; }
        public List<Office> Offices { get; set; }

        public string Name { get; set; }

        public virtual void Hire(Intern intern) { }

        public virtual void Sack() { }

        public virtual void Open(Department dep) { }

        public virtual void Open(Office office) { }

        public virtual void Close() { }

    }
}
