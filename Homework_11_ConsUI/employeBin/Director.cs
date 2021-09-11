using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.structBin.Company;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;
namespace Homework_11_ConsUI.employeBin
{
    /// <summary>
    /// директор компании
    /// </summary>
    class Director
    {
        /// <summary>
        /// конструктор
        /// </summary>
        public Director() { }


        /// <summary>
        /// подсчет зарплаты начальника
        /// </summary>
        /// <returns></returns>
        public int MonthlySalary()
        {
            return CountAdminSalary(OneCompany);
        }
    }
}