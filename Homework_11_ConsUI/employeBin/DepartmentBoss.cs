using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    class DepartmentBoss : Employe
    {
        int workersSalarySum = 0;
        //int SalaryCounter(Department dep)
        //{

        //}
        public DepartmentBoss(string Name, byte Age, Department Dep, int Salary = 1300)
        {
            this.Name = Name;
            this.Age = Age;
            this.Dep = Dep;
        }
    }
}
