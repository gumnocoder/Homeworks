using Homework_13_bank_system.Models.personsBin;

namespace Homework_13_bank_system.Models.structsBin
{
    interface ICredited : IAccount, ICreditActions
    {
        void Overdraft(long amount, Client client);
        void PayOff(Client client);
        void Pay(long amount);
    }
}
