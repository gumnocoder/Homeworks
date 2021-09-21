using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.structBin.OrgStructure;

namespace Homework_11_ConsUI.structBin
{
    public class Office : WorkPlace
    {
        static int subOfficesCount = 0;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="Name"></param>
        public Office(string Name)
        {
            this.Name = Name;
            Workers = new();
            WorkPlaces = new();
            workPlacesGlobal.Add(this);
        }

        /// <summary>
        /// автоконструктор
        /// </summary>
        public Office()
        {
            Workers = new();
            WorkPlaces = new();
            workPlacesGlobal.Add(this);
        }

        /// <summary>
        /// открыть подотдел
        /// </summary>
        /// <param name="office"></param>
        public override void Open(Office office)
        {
            ++subOfficesCount;
            WorkPlaces.Add(office);
        }

        /// <summary>
        /// открыть подотдел с параметрами по умолчанию
        /// </summary>
        public override void Open()
        {
            WorkPlaces.Add(
                new Office($"Sub-office #{subOfficesCount}")
                );
        }

        /// <summary>
        /// найм управляющего
        /// </summary>
        /// <param name="officeManager"></param>
        public override void HireBoss(OfficeManager officeManager)
        {
            this.Boss = officeManager.Name;
        }
    }
}
