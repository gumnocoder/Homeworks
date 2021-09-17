using System.Xml.Serialization;

namespace Homework_11_ConsUI.employeBin
{
    [XmlInclude(typeof(Intern))]
    [XmlInclude(typeof(Director))]
    [XmlInclude(typeof(DepartmentBoss))]
    [XmlInclude(typeof(OfficeManager))]
    [XmlInclude(typeof(Worker))]
    public abstract class Employe : Person
    {
        /// <summary>
        /// тип 
        /// </summary>
        string type;
        /// <summary>
        /// зарплата
        /// </summary>
        int salary;

        /// <summary>
        /// тип работника
        /// </summary>
        public string Type { 
            get { return type; } 
            set { type = value; } 
        }

        /// <summary>
        /// зарплата
        /// </summary>
        public int Salary { 
            get { return salary; } 
            set { salary = value; } 
        }

        /// <summary>
        /// конструктор
        /// </summary>
        public Employe()
        {
            salary = Salary;
            base.Name = Name;
            base.Age = Age;
        }

        /// <summary>
        /// вывод месячной зарплаты
        /// </summary>
        /// <returns></returns>
        public virtual int MonthlySalary() { 
            return this.Salary; 
        }
    }
}
