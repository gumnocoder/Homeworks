namespace Homework_11_ConsUI.employeBin
{
    class Worker : Employe
    {
        static int workersCount = 0;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Salary"></param>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        public Worker(int Salary, string Name, byte Age)
        {
            ++workersCount;
            this.Type = "Worker";
            this.Salary = Salary;
            this.Name = Name;
            this.Age = Age;
        }

        /// <summary>
        /// автоконструктор
        /// </summary>
        public Worker() : this(5, $"worker_{workersCount}", 18) 
        { 
            ++workersCount; 
        }
        public override string ToString()
        {
            return $"Worker {Name}, " +
                $"{Age} y.o., salary: " +
                $"{Salary} per hour";
        }

        /// <summary>
        /// пересчёт почасовой
        /// </summary>
        /// <returns></returns>
        public override int MonthlySalary()
        {
            return Salary * 20 * 8;
        }
    }
}
