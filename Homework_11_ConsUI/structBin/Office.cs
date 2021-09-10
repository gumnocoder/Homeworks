using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_11_ConsUI.employeBin;

namespace Homework_11_ConsUI.structBin
{
    class Office : WorkPlace
    {
        public Office(string Name)
        {
            this.Name = Name;
            this.Workers = new();
        }

        public override void Hire(Intern intern)
        {
            this.Workers.Add(intern);
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
