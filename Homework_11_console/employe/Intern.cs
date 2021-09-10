using Homework_11_console.structure;
namespace Homework_11_console.employe
{
    class Intern : Employe
    {

        public int Age { get; set; }

        public Intern(
            int Age,
            string Name, 
            int Salary 
            //WorkPlace workPlace
            )
        {
            this.Age = Age;
            this.Name = Name;
            this.Salary = Salary;
            //this.WorkPlace = workPlace;
        }

        public override string ToString()
        {
            return $"{Name} {Age} y.o., {Salary}$, {WorkPlace}";
        }
    }
}
