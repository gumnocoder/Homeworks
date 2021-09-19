using System.Xml.Serialization;

namespace Homework_11_ConsUI.employeBin
{
    [XmlInclude(typeof(Intern)), XmlInclude(typeof(Director)), XmlInclude(typeof(DepartmentBoss)), XmlInclude(typeof(OfficeManager)), XmlInclude(typeof(Worker))]
    public abstract class Person
    {
        /// <summary>
        /// имя 
        /// </summary>
        string name;
        /// <summary>
        /// возраст
        /// </summary>
        byte age;

        /// <summary>
        /// имя
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        /// <summary>
        /// возраст
        /// </summary>
        public byte Age
        {
            get { return age; }
            set { age = value; }
        }

        internal void Rename(string newName) { 
            this.Name = newName; 
        }
    }
}