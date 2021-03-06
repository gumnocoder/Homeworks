using static Homework_11_ConsUI.structBin.Company;
using Homework_11_ConsUI.structBin;
using System;

namespace Homework_11_ConsUI.employeBin
{
    /// <summary>
    /// директор компании
    /// </summary>
    public sealed class Director : Manager
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

        /// <summary>
        /// автоконструктор
        /// </summary>
        public Director() { }

        public override string ToString()
        {
            return $"{this.WorkPlace}, director - " +
                $"{Name}, " +
                $"{this.WorkPlace.BossSalary}$ per month";
        }
    }
}