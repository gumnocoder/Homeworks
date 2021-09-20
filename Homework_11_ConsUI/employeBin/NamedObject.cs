using System.Xml.Serialization;

namespace Homework_11_ConsUI.employeBin
{
    [XmlInclude(typeof(Intern)), 
        XmlInclude(typeof(Director)), 
        XmlInclude(typeof(DepartmentBoss)), 
        XmlInclude(typeof(OfficeManager)),
        XmlInclude(typeof(Worker))]
    public abstract class NamedObject : BaseViewModel
    {
        /// <summary>
        /// имя 
        /// </summary>
        string name;

        /// <summary>
        /// имя
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; onPropertyChanged(); }
        }

        public void Rename(string newName) { 
            this.Name = newName; 
        }
    }
}