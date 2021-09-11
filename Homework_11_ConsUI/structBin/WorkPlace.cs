using System.Collections.Generic;
using Homework_11_ConsUI.employeBin;
namespace Homework_11_ConsUI.structBin
{
    abstract class WorkPlace
    {
        public List<Employe> Workers { get; set; }
        public List<WorkPlace> WorkPlaces { get; set; }
        public string Name { get; set; }

        public Employe Boss { get; set; }

        public virtual void Hire(Intern intern) { }

        public virtual void Hire(DepartmentBoss depBoss) { }

        public virtual void Sack() { }

        public virtual void Open(Department dep) { }

        public virtual void Open(Office office) { }

        public virtual void Close() { }

        public virtual void AutoOpen() { }

        public virtual void Rename(string newName) { this.Name = newName; }

    }
}
