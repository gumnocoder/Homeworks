using Homework_13_bank_system.Models.structsBin;

namespace Homework_13_bank_system.Models.personsBin
{
    /// <summary>
    /// повышает репутацию клиента
    /// </summary>
    public class ReputationIncreaser : ICommandAction
    {
        private readonly Client client;
        private readonly int value;
        private bool executed;
        public bool Executed => executed;

        /// <summary>
        /// конструктор коасса повышающего репутацию клиента
        /// </summary>
        /// <param name="client">клиент</param>
        /// <param name="value">значение на которое будет повышена репутация (1 по умолчанию)</param>
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
