using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;

namespace Homework_11_ConsUI.employeBin
{
    public abstract class Manager
    {
        string type;
        WorkPlace workPlace;
        byte age;
        string name;

        /// <summary>
        /// Типа управляющего
        /// </summary>
        public string Type { 
            get { return type; } 
            set { type = value; } 
        }

        /// <summary>
        /// Рабочее место
        /// </summary>
        public WorkPlace WorkPlace { 
            get { return workPlace; } 
            set { workPlace = value; } 
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public byte Age { 
            get { return age; } 
            set { age = value; } 
        }

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { 
            get { return name; } 
            set { name = value; } 
        }

        /// <summary>
        /// конструктор
        /// </summary>
        public Manager()
        {
            workPlace = WorkPlace;
            name = Name;
            age = Age;
        }
    }
}
