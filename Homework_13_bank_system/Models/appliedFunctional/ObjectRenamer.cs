using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_13_bank_system.Models.personsBin;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    class ObjectRenamer<T> where T : IRenamableObject
    {
        readonly T obj;
        readonly string newName;

        public ObjectRenamer(T obj, string newName)
        {
            this.obj = obj;
            this.newName = newName;
            ReName();
        }

        private void ReName()
        {
            obj.Name = newName;
        }
    }
}
