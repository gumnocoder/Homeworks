using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_11.structs;
namespace Homework_11.personal
{
    abstract class Employe
    {
        public int salary;

        public WorkPlace workPlace;
    }

    class Director : Employe
    {
        new int salary;
        public int Salary { get; set; }

        string name;

        public string Name { get; set; }

        public static Director _instance = null;
        private Director(string Name, int Salary=1300)
        {
            salary = Salary;
            name = Name;
        }
        public static Director companyDirector
        {
            get
            {
                if (_instance == null) _instance = new Director("Bill Gates");
                return _instance;
            }
        }

        public override string ToString()
        {
            return $"{Name}, {Salary}$";
        }
    }
}
