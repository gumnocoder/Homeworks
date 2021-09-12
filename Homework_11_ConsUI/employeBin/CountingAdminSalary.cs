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
        
        private static bool CheckWorkersList(WorkPlace workPlace)
        {
            if (workPlace.Workers != null)
            {
                if (workPlace.Workers.Count > 0)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckWorkPlacesList(WorkPlace workPlace)
        {
            if (workPlace.WorkPlaces != null)
            {
                if (workPlace.WorkPlaces.Count > 0)
                {
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
        private static int CountingAllDepSalary(WorkPlace workPlace)
        {
            var wPW = workPlace.Workers;

            var wPWP = workPlace.WorkPlaces;

            if (CheckWorkPlacesList(workPlace))
            {
                foreach (var wplace in workPlace.WorkPlaces)
                {
                    if (CheckWorkPlacesList(wplace)) { 
                        return CountingAllDepSalary(wplace); 
                    }
                    if (CheckWorkersList(wplace)) { 
                        for (int i = 0; i < wplace.Workers.Count; i++) { 
                            workersSalarySum += wplace.Workers[i].MonthlySalary(); 
                        }
                    }
                }
            }
            if (CheckWorkersList(workPlace))
            {
                for (int i = 0; i < workPlace.Workers.Count; i++)
                {
                    workersSalarySum += workPlace.Workers[i].MonthlySalary();
                }
            }
/*
            if (wPWP != null)
            {
                if (wPWP.Count > 0)
                {
                    foreach (var wp in wPWP)
                    {
                        if (wp.Workers != null) if (wp.Workers.Count > 0) { }
                        workersSalarySum += CountingAllDepSalary(wp);
                    }
                }
            }

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



            if (wPWP != null)
            {
                if (wPWP.Count > 0)
                {
                    foreach (var wp in wPWP)
                    {
                        workersSalarySum += CountingAllDepSalary(wp);
                    }
                }
            }*/

            return workersSalarySum;
        }
    }
}
