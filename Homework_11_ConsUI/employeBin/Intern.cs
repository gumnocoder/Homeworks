using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_ConsUI.employeBin
{
    class Intern : Employe
    {
        static int internsCount = 0;

        public Intern(int Salary, string Name, byte Age)
        {
            ++internsCount;
            this.Type = "Intern";
            this.Salary = Salary;
            this.Name = Name;
            this.Age = Age;
        }

        public Intern() : this(100, $"intern_{internsCount}", 18) { ++internsCount; }

        public override string ToString()
        {
            return $"{Name} {Age} y.o., {Salary}$ per month";
        }
    }
}
