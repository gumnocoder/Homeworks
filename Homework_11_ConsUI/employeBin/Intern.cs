namespace Homework_11_ConsUI.employeBin
{
    public class Intern : Employe
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
            this.Type = "Intern";
            this.Salary = Salary;
            this.Name = Name;
            this.Age = Age;
        }

        /// <summary>
        /// автоконструктор
        /// </summary>
        public Intern() : this(
            100, 
            $"intern_{internsCount}", 
            18
            ) 
        { 
            ++internsCount; 
        }

        public override string ToString()
        {
            return $"{Name} {Age} y.o., {Salary}$ per month";
        }
    }
}
