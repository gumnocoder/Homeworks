using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    /// <summary>
    /// управляющий офисом
    /// </summary>
    public class OfficeManager : Manager
    {
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="ThisWorkPlace"></param>
        /// <param name="Name"></param>
        /// <param name="Age"></param>
        public OfficeManager(
            WorkPlace ThisWorkPlace, 
            string Name = "Lady Muck", 
            byte Age = 35
            )
        {
            Type = "Office manager";
            WorkPlace = ThisWorkPlace;
            this.Name = Name;
            this.Age = Age;
        }

        /// <summary>
        /// автоконструктор
        /// </summary>
        public OfficeManager() { }
    }
}
