using System.Collections.Generic;
using Homework_11_console.employe;
using static Homework_11_console.employe.Director;

namespace Homework_11_console.structure
{
    sealed class Company : WorkPlace
    {
        public string Name { get; set; }

        public Director director = companyDirector;



        new public List<WorkPlace> workPlaces = new();

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

        new public void Create(WorkPlace workPlace)
        {
            this.workPlaces.Add(workPlace);
        }

        public override string ToString()
        {
            int officesCount = workPlaces.Count;
            
            return $"Company {this.Name}, " +
                $"count of offices: {officesCount}, " +
                $"director: {director}";
        }
    }
}


