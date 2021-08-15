using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    class CompareNumber : IComparer<Staff>
    {
        public int Compare(Staff i1, Staff i2)
        {
            if (i1.Number > i2.Number) return 1;
            else if (i1.Number < i2.Number) return -1;
            else return 0;
        }
    }
}
