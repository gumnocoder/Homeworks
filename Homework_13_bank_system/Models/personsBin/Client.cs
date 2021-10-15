using System.Collections.ObjectModel;
using Homework_13_bank_system.Models.structsBin;

namespace Homework_13_bank_system.Models.personsBin
{
    public class Client : IClient
    {
        string name;

        ObservableCollection<IAccount> accounts;

        public ObservableCollection<IAccount> Accounts
        { get => accounts; set => accounts = value; }
        public string Name { get => name; set => name = value; }

        int reputation;

        public int Reputation
        {
            get => reputation;
            set
            {
                if (value <= 0) reputation = 0;
                else if (value >= 10) reputation = 10;
                else reputation = value;
            }
        }

        public void IncreaseRep(int value)
        {
            Reputation += value;
        }

        public void DecreaseRep(int value)
        {
            Reputation -= value;
        }
    }
}
