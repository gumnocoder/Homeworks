using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_ConsUI.structBin
{
    public static class OrgStructure
    {
        public static List<WorkPlace> workPlacesGlobal = new();

        public static void RefreshBossesSalary()
        {
            foreach (var e in workPlacesGlobal)
            {
                e.BossSalary = e.SetBossSalary(e);
                Console.WriteLine($"{e.Name}, {e.Workers.Count}, boss salary {e.BossSalary}");
            }
        }
    }
}
