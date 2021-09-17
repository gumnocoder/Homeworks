using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;

namespace Homework_11_ConsUI.employeBin
{
    public abstract class Manager : Person
    {
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
        /// конструктор
        /// </summary>
        public Manager()
        {
            workPlace = WorkPlace;
            base.Name = Name;
            base.Age = Age;
        }
    }
}
