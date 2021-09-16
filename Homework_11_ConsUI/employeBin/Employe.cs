using System.Collections;
using System.Xml.Serialization;
using Homework_11_ConsUI.structBin;

namespace Homework_11_ConsUI.employeBin
{
    [XmlInclude(typeof(Intern))]
    [XmlInclude(typeof(Director))]
    [XmlInclude(typeof(DepartmentBoss))]
    [XmlInclude(typeof(OfficeManager))]
    [XmlInclude(typeof(Worker))]
    public abstract class Employe
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
        /// имя 
        /// </summary>
        string name;
        /// <summary>
        /// возраст
        /// </summary>
        byte age;

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
        /// имя
        /// </summary>
        public string Name { 
            get { return name; } 
            set { name = value; } 
        }


        /// <summary>
        /// возраст
        /// </summary>
        public byte Age { 
            get { return age; } 
            set { age = value; } 
        }

        /// <summary>
        /// конструктор
        /// </summary>
        public Employe()
        {
            salary = Salary;
            name = Name;
            age = Age;
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
