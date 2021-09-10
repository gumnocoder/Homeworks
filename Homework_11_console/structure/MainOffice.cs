using System;
using System.Collections.Generic;
using System.Diagnostics;
using Homework_11_console.employe;
namespace Homework_11_console.structure
{

    public class MainOffice : WorkPlace
    {
        new public string workPlace = "Header office";


        new public List<Employe> workers;

        new public void Hire(Employe worker)
        {
            if (workers != null)
                workers.Add(worker);
            else Debug.WriteLine($"MainOffice.workers == null!");
        }


        static MainOffice _instance = null;

        public static MainOffice mainOffice() 
        { 
            if (_instance == null)
            {
                _instance = new MainOffice();
                Console.WriteLine("main office created in MainOffice.mainOffice()");
                //_instance.workers = new();
            }
            return _instance;
        }

        public MainOffice() { 
            this.workers = new List<Employe>(); 
            
        }

        public override string ToString()
        {
            return $"{workPlace} employe count: {workers.Count}";
        }
    }
}
