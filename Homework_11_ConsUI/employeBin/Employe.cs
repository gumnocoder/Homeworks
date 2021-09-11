using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    abstract class Employe
    {
        int salary;
        string name;
        WorkPlace thisWorkPlace;
        byte age;

        public int Salary { 
            get { return salary; } 
            set { salary = value; } 
        }
        public string Name { 
            get { return name; } 
            set { name = value; } 
        }
        public WorkPlace ThisWorkPlace
        { 
            get { return thisWorkPlace; } 
            set { thisWorkPlace = value; } 
        }
        public byte Age { 
            get { return age; } 
            set { age = value; } 
        }

        public Employe()
        {
            salary = Salary;
            name = Name;
            thisWorkPlace = ThisWorkPlace;
            age = Age;
        }

        public virtual int MonthlySalary() { return this.Salary; }
    }
}
