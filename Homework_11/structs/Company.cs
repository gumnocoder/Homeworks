using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_11.personal;
using static Homework_11.personal.Director;

namespace Homework_11.structs
{
    sealed class Company
    {
        public string Name { get; set; }

        public Director Director = companyDirector;

        public List<WorkPlace> offices;

        public static Company _instance;
        private Company(string Name) { this.Name = Name; }
        public static Company OneCompany
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Company("OAO Coders");
                }
                return _instance;
            }
        }
        public override string ToString()
        {
            return $"Company {this.Name}, " +
                $"count of offices: {offices.Count}, " +
                $"director: {Director}";
        }
    }
}
