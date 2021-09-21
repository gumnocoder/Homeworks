using System.Collections.Generic;
using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.BaseViewModel;

namespace Homework_11_ConsUI.structBin
{
    public class OrgStructure : BaseViewModel
    {
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
