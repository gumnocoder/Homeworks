using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.structBin.OrgStructure;

namespace Homework_11_ConsUI.structBin
{
    public class Department : WorkPlace
    {

        static int officeCount = 0;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Name"></param>
        public Department(string Name)
        {
            Workers = new();
            WorkPlaces = new();
            this.Name = Name;
            workPlacesGlobal.Add(this);
        }

        public Department() { }

        /// <summary>
        /// открыть подотдел
        /// </summary>
        /// <param name="office"></param>
        public override void Open(Office office)
        {
            ++officeCount;
            this.WorkPlaces.Add(office);
        }

        public override void OpenDep()
        {
            ++Company.depsCount;
            this.WorkPlaces.Add(
                new Department($"DepartmentName {Company.depsCount}")
                );
        }

        /// <summary>
        /// открыть подотдел с параметрами по умолчанию
        /// </summary>
        public override void Open()
        {
            ++officeCount;
            this.WorkPlaces.Add(new Office($"Office #{officeCount}"));
        }


        /// <summary>
        /// найм управляющего
        /// </summary>
        /// <param name="depBoss"></param>
        public override void HireBoss(DepartmentBoss depBoss)
        {
            Boss = depBoss.Name;
        }
    }
}
