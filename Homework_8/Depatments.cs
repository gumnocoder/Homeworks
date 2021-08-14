using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_8
{
    struct Depatments
    {
        public string depName;
        public DateTime creationDate;
        public int staffCount;

        public string DepName { get { return this.depName; } set {this.depName = value; } }
        public DateTime CreationDate { get {return this.creationDate ; } set {this.creationDate = value; } }
       
        public List<Staff> staff { get; set; }

        public Depatments(string DepName, DateTime CreationDate)
        {
            this.staff = new List<Staff>();
            this.depName = DepName;
            this.creationDate = CreationDate;
            this.staffCount = 0;
        }

        public void AddStaff(Staff newStaff)
        {
            this.staff.Add(newStaff);
            this.staffCount++;
        }
        public string Print()
        {
            return $"{this.depName,10} {this.creationDate,10} {this.staffCount,5}";
        }
    }
}
