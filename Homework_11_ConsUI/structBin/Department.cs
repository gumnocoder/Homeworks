using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.structBin.OrgStructure;
using static Homework_11_ConsUI.structBin.Company;

namespace Homework_11_ConsUI.structBin
{
    public class Department : WorkPlace
    {

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

        /// <summary>
        /// автоконструктор
        /// </summary>
        public Department() { }

        /// <summary>
        /// открыть офис
        /// </summary>
        /// <param name="office"></param>
        public override void Open(Office office)
        {
            ++companyOffices;
            this.WorkPlaces.Add(office);
        }

        public override void Open(Department department)
        {
            ++depsCount;
            this.WorkPlaces.Add(department);
        }

        /// <summary>
        /// открыть департамент
        /// </summary>
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
            ++companyOffices;
            this.WorkPlaces.Add(new Office($"Office #{companyOffices}"));
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
