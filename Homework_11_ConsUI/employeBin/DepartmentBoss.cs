using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    /// <summary>
    /// управляющий департаментом
    /// </summary>
    public class DepartmentBoss : Manager
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
            Type = "Department Boss";
            WorkPlace = ThisWorkPlace;
            this.Name = Name;
            this.Age = Age;
        }

        /// <summary>
        /// автоконструктор
        /// </summary>
        public DepartmentBoss() { }
    }
}
