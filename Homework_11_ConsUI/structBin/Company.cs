using Homework_11_ConsUI.employeBin;
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
        /// будет содержать ссылку на экземпляр класса Company
        /// </summary>
        static Company _instance = null;

        /// <summary>
        /// конструктор
        /// </summary>
        Company()
        {
            this.Name = "'Best Coders' corp.";
            WorkPlaces = new();
        }

        /// <summary>
        /// проверяет существует ли экземпляр
        /// </summary>
        public static Company OneCompany
        {
            get {
                /// если нет то создаёт его и помещает ссылку в переменную
                if (_instance == null) 
                    _instance = new Company(); 
                return _instance; 
            }
        }

        /// <summary>
        /// найм директора
        /// </summary>
        /// <param name="director"></param>
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
