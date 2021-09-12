using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    class OfficeManager : Manager
    {
        public OfficeManager(
            WorkPlace ThisWorkPlace, 
            string Name = "Lady Muck", 
            byte Age = 35
            )
        {
            this.Type = "Office manager";
            this.WorkPlace = ThisWorkPlace;
            this.Name = Name;
            this.Age = Age;
        }
    }
}
