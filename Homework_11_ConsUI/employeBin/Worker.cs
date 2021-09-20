namespace Homework_11_ConsUI.employeBin
{
    public class Worker : Employe
    {
        static int workersCount = 0;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Salary"></param>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        public Worker(
            int Salary,
            string Name,
            byte Age
            )
        {
            ++workersCount;
            Type = "Worker";
            this.Name = Name;
            this.Age = Age;
        }

        /// <summary>
        /// автоконструктор
        /// </summary>
        public Worker() : this(
            1,
            $"worker_{workersCount}", 
            18
            )
        {
            ++workersCount; 
        }
        public override string ToString()
        {
            return $"{Name}\n\n" +
                $"----------------------\n\n" +
                $"Type {Type}\n" +
                $"{Age} y.o., salary:\n" +
                $"{Salary} per hour\n" +
                $"{MonthlySalary()} per month\n";
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
