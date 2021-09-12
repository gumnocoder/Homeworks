using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    class DepartmentBoss : Manager
    {

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        /// <param name="ThisWorkPlace"></param>
        public DepartmentBoss(
            WorkPlace ThisWorkPlace, 
            string Name = "Lord Muck", 
            byte Age = 50
            )
        {
            this.Type = "Department Boss";
            this.WorkPlace = ThisWorkPlace;
            this.Name = Name;
            this.Age = Age;
        }

    }
}
