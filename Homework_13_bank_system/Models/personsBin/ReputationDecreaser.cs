using Homework_13_bank_system.Models.structsBin;

namespace Homework_13_bank_system.Models.personsBin
{
    public class ReputationDecreaser : ICommandAction
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
}
