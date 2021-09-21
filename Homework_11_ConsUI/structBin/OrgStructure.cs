using System.Collections.Generic;
using Homework_11_ConsUI.employeBin;

namespace Homework_11_ConsUI.structBin
{
    public class OrgStructure : BaseViewModel
    {
        /// <summary>
        /// список всех воркплейсов для пересчёта зп
        /// </summary>
        public static readonly List<WorkPlace> workPlacesGlobal = new();

        /// <summary>
        /// обновляет зарплаты всех управляющих
        /// </summary>
        public static void RefreshBossesSalary()
        {
            foreach (WorkPlace e in workPlacesGlobal)
            { e.BossSalary = e.SetBossSalary(e); }
        }
    }
}
