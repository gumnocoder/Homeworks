using Homework_13_bank_system.Models.personsBin;

namespace Homework_13_bank_system.Models.structsBin
{
    public static class CreditCheck
    {
        //static int SeekActiveCredits(Client client)
        //{
        //    int creditsCount = 0;
        //    foreach (BankAccount e in client.Accounts)
        //    {
        //        if (e.GetType() == typeof(CreditAccount) & e.isActive)
        //        { creditsCount++; }
        //    }
        //    return creditsCount;
        //}
        static bool IsCreditAvaible(Client client)
        {
            if (client.Reputation > 5)
            {
                //int credits = SeekActiveCredits(client);
                if (!client.CreditIsActive) return true; //(credits == 0) return true;
                //else if (credits < 2 & client.Reputation == 10) return true;
                else return false;
            }
            return false;
        }

        public static bool CheckForCredit(Client client)
        {
            return IsCreditAvaible(client);
        }

        //public static int OnlySeekCredits(Client client)
        //{
        //    return SeekActiveCredits(client);
        //}
    }
}
