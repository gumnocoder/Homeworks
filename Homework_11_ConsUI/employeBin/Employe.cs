using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    class Employe
    {
        int salary;
        string name;
        Department dep;
        byte age;
        public int Salary { get { return salary; } set { salary = value; } }
        public string Name { get { return name; } set { name = value; } }
        public Department Dep { get { return dep; } set { dep = value; } }
        public byte Age { get { return age; } set { age = value; } }

        public Employe()
        {
            salary = Salary;
            name = Name;
            dep = Dep;
            age = Age;
        }

    }
}
