﻿namespace Homework_11_console.employe
{
    class Director : Employe
    {
        public string Name { get; set; }

        public static Director _instance;
        private Director(string Name = "Bill Gates", int Salary = 1300)
        {
            base.Salary = Salary;
            // base.WorkPlace;
            this.Name = Name;
        }
        public static Director companyDirector
        {
            get
            {
                if (_instance == null) { _instance = new Director(); }
                _instance.Salary += 1000;
                return _instance;
            }
        }

        public override string ToString()
        {
            return $"{Name}, {Salary}$";
        }
    }
}
