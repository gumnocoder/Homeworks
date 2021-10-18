using System.Collections.ObjectModel;
using Homework_13_bank_system.Models.structsBin;

namespace Homework_13_bank_system.Models.personsBin
{
    public class ReputationIncreaser : IClientActions
    {
        private readonly Client client;
        private readonly int value;
        private bool executed;
        public bool Executed => executed;

        public ReputationIncreaser(Client client, int value = 1)
        {
            this.client = client;
            this.value = value;
            executed = false;
        }
        public void Execute()
        {
            if (client.Reputation >= 10)
            { client.Reputation = 10; }

            else
            { client.Reputation += value; }

            executed = true;
        }
    }
    public class ReputationDecreaser : IClientActions
    {
        private readonly Client client;
        private readonly int value;
        private bool executed;
        public bool Executed => executed;

        public ReputationDecreaser(Client client, int value = 1)
        {
            this.client = client;
            this.value = value;
            executed = false;
        }

        public void Execute()
        {
            if (client.Reputation <= 0) { client.Reputation = 0; }
            else { client.Reputation -= value; }

            executed = true;
        }
    }

    public class Client : IClient
    {
        string name;
        ObservableCollection<IAccountActions> accounts;
        int reputation;

        public string Name
        { get => name; set => name = value; }
        public ObservableCollection<IAccountActions> Accounts
        { get => accounts; set => accounts = value; }

        public int Reputation
        { get => reputation; set => reputation = value; }
    }
}
