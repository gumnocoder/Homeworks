namespace Homework_11_ConsUI.employeBin
{
    class Intern : Employe
    {
        static int internsCount = 0;
        public Intern(int Salary, string Name, byte Age)
        {
            ++internsCount;
            this.Salary = Salary;
            this.Name = Name;
            this.Age = Age;
        }
        public Intern() : this(100, $"intern_{internsCount}", 18) { ++internsCount; }
        public override string ToString()
        {
            return $"intern {Name}, {Age} y.o., salary: {Salary}";
        }

        public override int MonthlySalary()
        {
            return Salary * 20 * 8;
        }
    }
}
