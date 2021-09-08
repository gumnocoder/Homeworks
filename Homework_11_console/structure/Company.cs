using System.Collections.Generic;
using Homework_11_console.employe;
using static Homework_11_console.employe.Director;

namespace Homework_11_console.structure
{
    sealed class Company
    {
        public string Name { get; set; }

        public Director director = companyDirector;

        public List<WorkPlace> offices = new();

        public static Company _instance;
        private Company(string Name = "OAO Coders")
        {
            this.Name = Name;
        }
        public static Company OneCompany
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Company();
                }
                return _instance;
            }
        }
        public override string ToString()
        {
            int officesCount = offices.Count;
            if (officesCount == null) officesCount = 0;
            return $"Company {this.Name}, " +
                $"count of offices: {(offices.Count == null ? 0 : offices.Count)}, " +
                $"director: {director}";
        }
    }
}


