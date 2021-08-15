using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    class CompareProjects : IComparer<Staff>
    {
        public int Compare(Staff i1, Staff i2)
        {
            if (i1.ProjectsCount > i2.ProjectsCount) return 1;
            else if (i1.ProjectsCount < i2.ProjectsCount) return -1;
            else return 0;
        }
    }
}
