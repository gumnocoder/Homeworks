using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.Director;
namespace Homework_11_ConsUI.structBin
{
    sealed class Company : WorkPlace
    {
        string boss;
        public string Boss { get { return boss; } set { boss = value; } }

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
            //Boss = OneDirector;
            //HireDirector(new Director(this));
            Name = "'Best Coders' corp.";
            WorkPlaces = new();

        }



        /// <summary>
        /// найм директора
        /// </summary>
        /// <param name="director"></param>
        public void HireDirector(Director director)
        {
            companyDirector = director;
            this.Boss = companyDirector.Name;
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
