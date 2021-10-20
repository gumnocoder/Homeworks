using Homework_13_bank_system.Models.structsBin;

namespace Homework_13_bank_system.Models.personsBin
{
    public class ReputationIncreaser : ICommandAction
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
}
