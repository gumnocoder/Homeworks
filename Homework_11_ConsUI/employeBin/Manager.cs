using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;

namespace Homework_11_ConsUI.employeBin
{
    public abstract class Manager : NamedObject
    {
        byte age;
        string type;
        WorkPlace workPlace;

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
        /// возраст
        /// </summary>
        public byte Age
        {
            get { return age; }
            set { age = value; }
        }

        /// <summary>
        /// конструктор
        /// </summary>
        public Manager()
        {
            workPlace = WorkPlace;
            base.Name = Name;
            age = Age;
        }
    }
}
