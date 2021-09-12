﻿using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;

namespace Homework_11_ConsUI.employeBin
{
    abstract class Manager
    {
        WorkPlace workPlace;
        byte age;
        string name;

        public WorkPlace WorkPlace { 
            get { return workPlace; } 
            set { workPlace = value; } 
        }
        public byte Age { 
            get { return age; } 
            set { age = value; } 
        }
        public string Name { 
            get { return name; } 
            set { name = value; } 
        }

        public Manager()
        {
            workPlace = WorkPlace;
            name = Name;
            age = Age;
        }

        public virtual int MonthlySalary() { 
            return CountAdminSalary(workPlace); 
        }
    }
}
