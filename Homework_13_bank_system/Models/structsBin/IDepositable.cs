using Homework_13_bank_system.Models.personsBin;

namespace Homework_13_bank_system.Models.structsBin
{
    interface IDepositable : IAccount
    {
        void ToDeposit(Client client, long amount);
        void BorrowToBank(Client client, long amount);
        void DepositWithdraw();
    }
}
