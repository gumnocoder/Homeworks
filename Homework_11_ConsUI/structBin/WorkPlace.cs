﻿using System.Collections.Generic;
using Homework_11_ConsUI.employeBin;
namespace Homework_11_ConsUI.structBin
{
    abstract class WorkPlace
    {
        public List<Intern> Workers { get; set; }

        protected string name;
        public string Name { get; set; }

        public virtual void Hire(Intern intern) { }

        public virtual void Sack() { }

        public virtual void Open(Department dep) { }

        public virtual void Open(Office office) { }

        public virtual void Close() { }

    }
}