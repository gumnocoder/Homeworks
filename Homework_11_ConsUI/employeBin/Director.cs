using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.structBin.Company;

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

        private int workersSalarySum;

        /// <summary>
        /// подсчет сумм всех зарплат
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
        private int CountingAllDepSalary(WorkPlace workPlace)
        {
            if (workPlace.Workers != null)
            {
                if (workPlace.Workers.Count > 0)
                {
                    for (int i = 0; i < workPlace.Workers.Count; i++)
                    {
                        workersSalarySum += workPlace.Workers[i].MonthlySalary();
                    }
                }
            }

            if (workPlace.WorkPlaces != null)
            {
                if (workPlace.WorkPlaces.Count > 0)
                {
                    foreach (var wp in workPlace.WorkPlaces)
                    {
                        workersSalarySum += CountingAllDepSalary(wp);
                    }
                }
            }

            return workersSalarySum;
        }

        /// <summary>
        /// подсчет зарплаты начальника
        /// </summary>
        /// <returns></returns>
        public int MonthlySalary()
        {
            workersSalarySum = 0;
            workersSalarySum += CountingAllDepSalary(OneCompany);
            if (workersSalarySum > 1300)
                return workersSalarySum;
            else return 1300;
        }
    }
}