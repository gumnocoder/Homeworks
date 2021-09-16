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
/*        private static int PercentOfSalary(int num)
        {
            double result;
            result = (15f / 100f) * num;
            return Convert.ToInt32(result);
        }*/

        /// <summary>
        /// сбрасывает workersSalarySum и запускает рекурсию
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
        public static int CountAdminSalary(WorkPlace workPlace)
        {
            Console.WriteLine("------------------ Start counting ------------------");
            workersSalarySum = 0;
            //workersSalarySum = PercentOfSalary(
               // CountingAllDepSalary(workPlace)
              //  );
            CountingAllDepSalary(workPlace);
            //Console.WriteLine(workersSalarySum);
            if (workersSalarySum < 300) return 300;
            Console.WriteLine("------------------ End counting ------------------");
            return workersSalarySum;
        }
        
        /// <summary>
        /// выполняет проверки для текущего листа Workers
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
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

        /// <summary>
        /// выполняет проверки для текущего листа WorkPlaces
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
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
        private static void CountingAllDepSalary(WorkPlace workPlace)
        {
            if (CheckWorkersList(workPlace))
            {
                foreach (var e in workPlace.Workers)
                {
                    workersSalarySum += e.MonthlySalary();
                    Console.WriteLine("worker counted!");
                }
            }

            if (CheckWorkPlacesList(workPlace))
            {
                foreach (var e in workPlace.WorkPlaces)
                {
                    Console.WriteLine("-------------------------> Go Tree");
                    CountingAllDepSalary(e);
                }
            }
            Console.WriteLine(workPlace);
            Console.WriteLine(workersSalarySum);
            return;
            //return workersSalarySum;

                //if (CheckWorkersList(workPlace))
                //{
                //    for (int i = 0; i < workPlace.Workers.Count; i++)
                //    {
                //        //Console.WriteLine(workPlace.Workers[i]);
                //        workersSalarySum += workPlace.Workers[i].MonthlySalary();
                //    }
                //}

            //if (CheckWorkPlacesList(workPlace))
            //{
            //    foreach (var wplace in workPlace.WorkPlaces)
            //    {
            //        Console.WriteLine(wplace);
            //        /*return */workersSalarySum += CountingAllDepSalary(wplace);

            //        //if (CheckWorkersList(wplace)) 
            //        //{ 
            //        //    for (int i = 0; i < wplace.Workers.Count; i++) { 
            //        //        workersSalarySum += wplace.Workers[i].MonthlySalary();
            //        //        Console.WriteLine($"worker {wplace.Workers[i]} salary is {wplace.Workers[i].MonthlySalary()}");
            //        //    }
            //        //}
            //    }
            //}


            //Console.WriteLine(workersSalarySum);
            //return workersSalarySum;
        }
    }
}
