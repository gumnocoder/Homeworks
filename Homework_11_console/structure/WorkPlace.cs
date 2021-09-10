using System;
using System.Collections.Generic;
using Homework_11_console.employe;

namespace Homework_11_console.structure
{
    public interface IHR
    {
        //List<Employe> workers { get; set; }

        public void Hire(Employe worker);

        public void Sack(Employe worker);
    }

    public interface IWorkPlaceCreator
    {
        //List<WorkPlace> workPlaces { get; set; }

        public void Create(WorkPlace workPlace);

        public void Remove(WorkPlace workPlace);
    }

    public class WorkPlace : IHR, IWorkPlaceCreator
    {


        public List<Employe> workers { get; set; }
        public List<WorkPlace> workPlaces;
        public string workPlace;
        /// <summary>
        /// добавляет персонал в коллекцию
        /// </summary>
        /// <param name="worker">добавляемый работник</param>
        public virtual void Hire(Employe worker){

            workers.Add(worker);
            Console.WriteLine("added");
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
