using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;

namespace Homework_11_ConsUI.employeBin
{
    class DepartmentBoss : Employe
    {

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <param name="ThisWorkPlace"></param>
        public DepartmentBoss(string Name, byte Age, WorkPlace ThisWorkPlace)
        {
            this.Name = Name;
            this.Age = Age;
            this.ThisWorkPlace = ThisWorkPlace;
        }


        /// <summary>
        /// подсчет зп начальника
        /// </summary>
        /// <returns></returns>
        public override int MonthlySalary()
        {
            return CountAdminSalary(ThisWorkPlace);
        }
    }
}
