using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_ConsUI.employeBin
{
    class Intern
    {
        public int Salary { get; set; }
        public Intern(int Salary)
        {
            this.Salary = Salary;
        }
        public override string ToString()
        {
            return $"intern, salary: {Salary}";
        }
    }
}
