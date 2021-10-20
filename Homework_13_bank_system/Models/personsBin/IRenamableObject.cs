using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13_bank_system.Models.personsBin
{
    interface IRenamableObject
    {
        string Name { get; set; }
        void ReName(string newName);
    }
}
