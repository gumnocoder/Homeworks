using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.structBin.Company;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;
namespace Homework_11_ConsUI.employeBin
{
    /// <summary>
    /// директор компании
    /// </summary>
    sealed class Director
    {
        static string name;

        public static string Name { 
            get { return name; } 
            set { name = value; } 
        }

        static Director _instance = null;

        /// <summary>
        /// конструктор
        /// </summary>
        Director(string Name = "Bill Gates") { name = Name; }

        public static Director oneDirector
        {
            get
            {
                if (_instance == null) _instance = new Director();
                return _instance;
            }
        }

        /// <summary>
        /// подсчет зарплаты начальника
        /// </summary>
        /// <returns></returns>
        public int MonthlySalary()
        {
            return CountAdminSalary(OneCompany);
        }

        public override string ToString()
        {
            return $"{OneCompany}, director {Name}, {MonthlySalary()}$ per month";
        }
    }
}