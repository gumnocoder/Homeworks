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

    public abstract class WorkPlace
    {
        protected List<Employe> workers;

        protected string workPlace;
    }
}
