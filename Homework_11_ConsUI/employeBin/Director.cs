using static Homework_11_ConsUI.structBin.Company;
using Homework_11_ConsUI.structBin;
using System;

namespace Homework_11_ConsUI.employeBin
{
    /// <summary>
    /// директор компании
    /// </summary>
    sealed class Director : Manager
    {

        /// <summary>
        /// конструктор
        /// </summary>
        public Director(WorkPlace WorkPlace,
            string Name = "Bill Gates", 
            byte Age = 99
            )
        {
            this.Type = "Director";
            this.WorkPlace = WorkPlace;
            this.Name = Name;
            this.Age = Age;
        }

        public override string ToString()
        {
            return $"{this.WorkPlace}, director - " +
                $"{Name}, " +
                $"{MonthlySalary()}$ per month";
        }
    }
}