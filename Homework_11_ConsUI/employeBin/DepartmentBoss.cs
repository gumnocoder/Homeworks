using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    class DepartmentBoss : Employe
    {
        int workersSalarySum = 0;

        public DepartmentBoss(string Name, byte Age, WorkPlace ThisWorkPlace)
        {
            this.Name = Name;
            this.Age = Age;
            this.ThisWorkPlace = ThisWorkPlace;
        }

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
        public override int MonthlySalary()
        {
            workersSalarySum = 0;
            workersSalarySum += CountingAllDepSalary(ThisWorkPlace);
            if (workersSalarySum > 1300)
                return workersSalarySum;
            else return 1300;
        }
    }
}
