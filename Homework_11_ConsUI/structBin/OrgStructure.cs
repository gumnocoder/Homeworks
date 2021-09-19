using System.Collections.Generic;

namespace Homework_11_ConsUI.structBin
{
    public static class OrgStructure
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
