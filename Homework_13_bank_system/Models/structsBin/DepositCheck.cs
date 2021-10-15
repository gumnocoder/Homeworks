using Homework_13_bank_system.Models.personsBin;

namespace Homework_13_bank_system.Models.structsBin
{
    public static class DepositCheck
    {
        public static int minDeposit = 1000;

        public static bool CheckForDeposit(Client client, long amount)
        {
            if (CreditCheck.OnlySeekCredits(client) > 0) return false;
            if (amount < minDeposit) return false;
            else return true;
        }
    }
}
