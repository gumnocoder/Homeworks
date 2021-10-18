using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13_bank_system.Models.structsBin
{
    interface IClientActions
    {
        void Execute();
        public bool Executed { get; }
    }
}