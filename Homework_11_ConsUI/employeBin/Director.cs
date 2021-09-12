using static Homework_11_ConsUI.structBin.Company;
namespace Homework_11_ConsUI.employeBin
{
    /// <summary>
    /// директор компании
    /// </summary>
    sealed class Director : Manager
    {

        static Director _instance = null;

        /// <summary>
        /// конструктор
        /// </summary>
        Director(
            string Name = "Bill Gates", 
            byte Age = 99
            )
        {
            WorkPlace = OneCompany;
            this.Name = Name;
            this.Age = Age;
        }

        public static Director OneDirector
        {
            get
            {
                if (_instance == null) { 
                    _instance = new Director(); 
                }
                return _instance;
            }
        }

        public override string ToString()
        {
            return $"{OneCompany}, director - " +
                $"{Name}, " +
                $"{MonthlySalary()}$ per month";
        }
    }
}