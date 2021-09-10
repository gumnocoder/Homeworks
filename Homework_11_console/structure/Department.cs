using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_11_console.employe;
using static Homework_11_console.structure.WorkPlace;

namespace Homework_11_console.structure
{

    class Department : WorkPlace
    {
        new List<Employe> workers = new();

        public List<Employe> Workers { get { return this.workers; } }
        public string Name { get; set; }

        public Department(string Name = "default Dep")
        {
            this.workers = Workers;
            //workers = new();
            this.Name = Name;
        }

        public override void Hire(Employe worker)
        {
            workers.Add(worker);
            Console.WriteLine("hired!");
            foreach (var e in workers) Console.WriteLine(e);
        }

        public override string ToString()
        {
            return $"Department {Name}, workers: {workers.Count}";
        }
    }
}
