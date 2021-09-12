using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.Director;
namespace Homework_11_ConsUI.structBin
{
    sealed class Company : WorkPlace
    {
        static int depsCount = 0;
        /// <summary>
        /// количество отделов
        /// </summary>
        public static int DepsCount { get { return depsCount; } }

        /// <summary>
        /// директор
        /// </summary>
        public static Director companyDirector;


        /// <summary>
        /// конструктор
        /// </summary>
        public Company()
        {
            Name = "'Best Coders' corp.";
            WorkPlaces = new();
            Workers = new();
        }

        public override void Hire(Employe employe)
        {
            this.Workers.Add(employe);
        }

        /// <summary>
        /// найм директора
        /// </summary>
        /// <param name="director"></param>
        public override void HireBoss(Director director)
        {
            companyDirector = director;
            this.Boss = companyDirector.Name;
            this.BossSalary = companyDirector.MonthlySalary();
        }

        public override void Open(Department dep)
        {
            ++depsCount;
            this.WorkPlaces.Add(dep);
        }

        public override void AutoOpen()
        {
            ++depsCount;
            this.WorkPlaces.Add(
                new Department($"DepartmentName {depsCount}")
                );
        }
        public override string ToString()
        {
            return $"Company {Name}, count of departments " +
                $"{WorkPlaces.Count}";
        }
    }
}
