namespace Homework_11_ConsUI.employeBin
{
    class Intern : Employe
    {
        static int internsCount = 0;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Salary"></param>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        public Intern(int Salary, string Name, byte Age)
        {
            ++internsCount;
            this.Salary = Salary;
            this.Name = Name;
            this.Age = Age;
        }

        /// <summary>
        /// автоконструктор
        /// </summary>
        public Intern() : this(3, $"intern_{internsCount}", 18) { ++internsCount; }
        public override string ToString()
        {
            return $"intern {Name}, {Age} y.o., salary: {Salary} per hour";
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
