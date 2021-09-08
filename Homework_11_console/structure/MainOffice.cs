using System.Collections.Generic;
using Homework_11_console.employe;
namespace Homework_11_console.structure
{

    public class MainOffice : WorkPlace
    {
        new public string workPlace = "Header office";

        public static MainOffice _instance;

        MainOffice() { }

        public MainOffice(List<Employe> Workers)
        {
            Workers = new List<Employe>();
            workers = Workers;
        }

        public List<Employe> Workers { get; set; }

    }
}
