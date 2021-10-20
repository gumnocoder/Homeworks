using Homework_13_bank_system.Models.personsBin;
using Homework_13_bank_system.Models.structsBin;
using static Homework_13_bank_system.Models.structsBin.Bank;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    static class IdSetter<T>
    {
        static string type;
        static IdSetter() { }
        public static void SetId(T requester)
        {
            string requesterType = requester.GetType().ToString();

            switch (requesterType)
            {
                case ("User"):
                    (requester as User).UserId = ++ThisBank.CurrentUserID;
                    break;
                case ("Client"):
                    (requester as Client).ClientId = ++ThisBank.CurrentClientID;
                    break;
                case ("CreditAccount"):
                    (requester as CreditAccount).Id = ++ThisBank.CurrentCreditID;
                    break;
                case ("DebitAccount"):
                    (requester as DebitAccount).Id = ++ThisBank.CurrentDebitID;
                    break;
            }
        }
    }
}
