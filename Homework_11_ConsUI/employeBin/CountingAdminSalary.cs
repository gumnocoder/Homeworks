using System;
using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    class CountingAdminSalary
    {
        static int workersSalarySum;

        /// <summary>
        /// расчёт 15% от всех зп
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static int PercentOfSalary(int num)
        {
            float result;
            result = (15f / 100f) * num;
            return Convert.ToInt32(result);
        }

        /// <summary>
        /// сбрасывает workersSalarySum и запускает рекурсию
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
        public static int CountAdminSalary(WorkPlace workPlace)
        {
            workersSalarySum = 0;
            CountingAllDepSalary(workPlace);
            workersSalarySum = PercentOfSalary(workersSalarySum);
            if (workersSalarySum < 1300) { return 1300; }
            return workersSalarySum;
        }
        
        /// <summary>
        /// выполняет проверки для текущего листа Workers
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
        private static bool CheckWorkersList(WorkPlace workPlace)
        {
            if (workPlace.Workers != null) {
                if (workPlace.Workers.Count > 0) {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// выполняет проверки для текущего листа WorkPlaces
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
        private static bool CheckWorkPlacesList(WorkPlace workPlace)
        {
            if (workPlace.WorkPlaces != null) {
                if (workPlace.WorkPlaces.Count > 0) {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// подсчет всех зарплат
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
        private static void CountingAllDepSalary(WorkPlace workPlace)
        {
            if (CheckWorkersList(workPlace)) {
                foreach (var e in workPlace.Workers) {
                    workersSalarySum += e.MonthlySalary();
                }
            }

            if (CheckWorkPlacesList(workPlace)) {
                foreach (var e in workPlace.WorkPlaces) {
                    CountingAllDepSalary(e);
                }
            }

            return;
        }
    }
}
