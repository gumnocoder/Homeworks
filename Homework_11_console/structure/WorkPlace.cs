using System;
using System.Collections.Generic;
using Homework_11_console.employe;

namespace Homework_11_console.structure
{
    public interface IHR
    {
        List<Employe> workers { get; set; }

        public void Hire(Employe worker);

        public void Sack(Employe worker);
    }

    public interface IWorkPlaceCreator
    {
        List<WorkPlace> workPlaces { get; set; }

        public void Create(WorkPlace workPlace);

        public void Remove(WorkPlace workPlace);
    }

    public abstract class WorkPlace : IHR, IWorkPlaceCreator
    {
        List<Employe> IHR.workers { get; set; }
        List<WorkPlace> IWorkPlaceCreator.workPlaces 
        { get ; set; }

        protected List<Employe> workers;
        protected List<WorkPlace> workPlaces;
        protected string workPlace;
        /// <summary>
        /// добавляет персонал в коллекцию
        /// </summary>
        /// <param name="worker">добавляемый работник</param>
        public virtual void Hire(Employe worker){
            if (workers != null)
            workers.Add(worker);
            else
            {
                workers = new List<Employe>();
                Hire(worker);
                Console.WriteLine(workers.Count);
                foreach(var e in workers)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// удаляет персонал из коллекции
        /// </summary>
        /// <param name="worker">удаляемый работник</param>
        public void Sack(Employe worker){
            workers.Remove(worker);
        }
        /// <summary>
        /// создаёт отдел в коллекции
        /// </summary>
        /// <param name="workPlace">создаваемый отдел</param>
        public void Create(WorkPlace workPlace){
            //if (workPlaces == null) workPlaces = new List<WorkPlace>();
            workPlaces.Add(workPlace);
        }
        /// <summary>
        /// удаляет отдел из коллекции
        /// </summary>
        /// <param name="workPlace">удаляемый отдел</param>
        public void Remove(WorkPlace workPlace){
            workPlaces.Remove(workPlace);
        }
    }
}
