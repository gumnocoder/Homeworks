using System.Collections.ObjectModel;
using System.Xml.Serialization;
using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.CountingAdminSalary;
using static Homework_11_ConsUI.structBin.OrgStructure;

namespace Homework_11_ConsUI.structBin
{
    [XmlInclude(typeof(Department))]
    [XmlInclude(typeof(Office))]
    [XmlInclude(typeof(Company))]
    public abstract class WorkPlace : NamedObject
    {

        ObservableCollection<Employe> workers;

        /// <summary>
        /// список сотрудников
        /// </summary>
        public ObservableCollection<Employe> Workers
        {
            get { return workers; }
            set { workers = value; onPropertyChanged(); }
        }

        ObservableCollection<WorkPlace> workPlaces;

        /// <summary>
        /// список отделов
        /// </summary>
        public ObservableCollection<WorkPlace> WorkPlaces {
            get { return workPlaces; }
            set 
            { 
                workPlaces = value; 
                onPropertyChanged(); 
            }
        }

        string boss;
        /// <summary>
        /// Управляющий
        /// </summary>
        public string Boss
        {
            get { return boss; }
            set { boss = value; onPropertyChanged(); }
        }

        int bossSalary;
        /// <summary>
        /// Зарплата управляющего
        /// </summary>
        public int BossSalary
        {
            get { return bossSalary; }
            set {
                bossSalary = value;
                onPropertyChanged();
            }
        }

        /// <summary>
        /// считает офисы
        /// </summary>
        /// <returns></returns>
        public int CountOffices()
        {
            int tmp = 0;
            foreach (var e in this.WorkPlaces)
            {
                if (e.GetType() == typeof(Office)) tmp++;
            }
            return tmp;
        }

        /// <summary>
        /// считает департаменты
        /// </summary>
        /// <returns></returns>
        public int CountDeps()
        {
            int tmp = 0;
            foreach (var e in this.WorkPlaces)
            {
                if (e.GetType() == typeof(Department)) tmp++;
            }
            return tmp;
        }

        /// <summary>
        /// Подсчитывает количество рабочих
        /// </summary>
        /// <returns></returns>
        public int CountWorkers()
        {
            int tmp = 0;
            foreach (var e in this.Workers)
            {
                if (e.GetType() == typeof(Worker)) tmp++;
            }
            return tmp;
        }

        /// <summary>
        /// ПОдсчитывает количество интернов
        /// </summary>
        /// <returns></returns>
        public int CountInterns()
        {
            int tmp = 0;
            foreach (var e in this.Workers)
            {
                if (e.GetType() == typeof(Intern)) tmp++;
            }
            return tmp;
        }

        /// <summary>
        /// найм работников
        /// </summary>
        /// <param name="intern">работник</param>
        public virtual void Hire(Employe employe) {
            Workers.Add(employe);
            RefreshBossesSalary();
        }

        /// <summary>
        /// найм начальника
        /// </summary>
        /// <param name="depBoss">нанимаемый начальник</param>
        public virtual void HireBoss(DepartmentBoss depBoss) { }

        /// <summary>
        /// найм управляющего
        /// </summary>
        /// <param name="director"></param>
        public virtual void HireBoss(Director director) { }

        /// <summary>
        /// найм директора
        /// </summary>
        /// <param name="officeManager"></param>
        public virtual void HireBoss(OfficeManager officeManager) { }

        /// <summary>
        /// устанавливает зп управляющего
        /// </summary>
        /// <param name="workPlace"></param>
        /// <returns></returns>
        public virtual int SetBossSalary(WorkPlace workPlace) {
            if (Boss != null) {
                return CountAdminSalary(workPlace);
            }
            else return 0;
        }

        /// <summary>
        /// увольнение сотрудника
        /// </summary>
        /// <param name="employe"></param>
        public virtual void Sack(Employe employe) {
            this.Workers.Remove(employe);
        }

        /// <summary>
        /// увольнение босса
        /// </summary>
        public virtual void SackBoss() {
            this.Boss = null;
            this.bossSalary = 0;
            onPropertyChanged();
        }

        /// <summary>
        /// создаёт отдел
        /// </summary>
        /// <param name="dep">отдел</param>
        public virtual void Open(Department dep) { }

        /// <summary>
        /// для автоматического создания отдела
        /// </summary>
        public virtual void Open() { }

        /// <summary>
        /// автоматическое создание департамента
        /// </summary>
        public virtual void OpenDep() { }

        /// <summary>
        /// создаёт подотдел
        /// </summary>
        /// <param name="office">подотдел</param>
        public virtual void Open(Office office) { }


        /// <summary>
        /// закрыть отдел
        /// </summary>
        /// <param name="workPlace"></param>
        public virtual void Close(WorkPlace workPlace) { 
            this.workPlaces.Remove(workPlace); 
        }

        /// <summary>
        /// Переименовывает управляющего
        /// </summary>
        /// <param name="name"></param>
        public virtual void RenameBoss(string name)
        {
            this.Boss = name;
            onPropertyChanged();
        }

        public override string ToString()
        {
            return $"count of departments: {CountDeps() }\n" +
                $"count of offices: {CountOffices() }\n\n" +
                $"Workers count: { CountWorkers() }\n" +
                $"Workers count: { CountInterns() }\n\n" +
                $"Boss: {Boss}\n" +
                $"Boss`s salary: {BossSalary}";
        }
    }
}
