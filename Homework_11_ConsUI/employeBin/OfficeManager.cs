using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    public class OfficeManager : Manager
    {
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
        public OfficeManager() { }
    }
}
