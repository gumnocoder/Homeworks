using Homework_11_ConsUI.employeBin;
namespace Homework_11_ConsUI.structBin
{
    sealed class Company : WorkPlace
    {
        public static int depsCount = 0;
        public static int DepsCount { get { return depsCount; } }

        public static Director companyDirector;

        static Company _instance = null;
        Company()
        {
            this.Name = "'Best Coders' corp.";
            WorkPlaces = new();
        }
        public static Company OneCompany
        {
            get { if (_instance == null) _instance = new Company(); return _instance; }
        }

        public static void HireDirector(Director director)
        {
            companyDirector = director;
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
