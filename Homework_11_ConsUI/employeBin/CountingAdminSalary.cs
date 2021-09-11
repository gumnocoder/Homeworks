using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    class CountingAdminSalary
    {
        static int workersSalarySum;

        public static int CountAdminSalary(WorkPlace workPlace)
        {
            workersSalarySum = 0;
            if (CountingAllDepSalary(workPlace) > 1300) return workersSalarySum;
            else return 1300;
        }
        

        /// <summary>
        /// подсчет всех зарплат
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
        private static int CountingAllDepSalary(WorkPlace workPlace)
        {
            var wPW = workPlace.Workers;
            

            if (wPW != null)
            {
                if (wPW.Count > 0)
                {
                    for (int i = 0; i < wPW.Count; i++)
                    {
                        workersSalarySum += wPW[i].MonthlySalary();
                    }
                }
            }

            var wPWP = workPlace.WorkPlaces;

            if (wPWP != null)
            {
                if (wPWP.Count > 0)
                {
                    foreach (var wp in wPWP)
                    {
                        workersSalarySum += CountingAllDepSalary(wp);
                    }
                }
            }

            return workersSalarySum;
        }
    }
}
