using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13_bank_system.Models.structsBin
{
    class Bank
    {
        static ObservableCollection<long> usedCreditIdentificators;

        static ObservableCollection<long> usedDebitIdentificators;

        public static ObservableCollection<long> UsedCreditIdentificators
        {
            get => usedCreditIdentificators;
            set => usedCreditIdentificators = value;
        }

        public static ObservableCollection<long> UsedDebitIdentificators
        {
            get => usedDebitIdentificators;
            set => usedDebitIdentificators = value;
        }

        string name;
        public string Name { get => name; set => name = value; }

        static Bank thisBank = null;
        public static Bank ThisBank
        {
            get
            {
                if (thisBank == null) thisBank = new();
                return thisBank;
            }
        }

        private Bank(string Name = "ЗАО 'Банк России'")
        {
            UsedCreditIdentificators = new();
            UsedDebitIdentificators = new();
        }

        public void OpenAccount<T>()
        {

        }
    }
}
