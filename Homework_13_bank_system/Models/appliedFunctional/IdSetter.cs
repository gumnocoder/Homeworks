using System.Diagnostics;
using Homework_13_bank_system.Models.personsBin;
using Homework_13_bank_system.Models.structsBin;
using static Homework_13_bank_system.Models.structsBin.Bank;

namespace Homework_13_bank_system.Models.appliedFunctional
{
    static class IdSetter<T>
    {
        public static void SetId(T requester)
        {
            switch (requester.GetType().ToString())
            {
                case ("Homework_13_bank_system.Models.personsBin.User"):
                    ++ThisBank.CurrentUserID;
                    (requester as User).UserId = ThisBank.CurrentUserID; 
                    break;
                case ("Homework_13_bank_system.Models.personsBin.Client"):
                    ++ThisBank.CurrentClientID;
                    (requester as Client).ClientId = ThisBank.CurrentClientID; 
                    break;
                case ("Homework_13_bank_system.Models.structsBin.CreditAccount"):
                    ++ThisBank.CurrentCreditID;
                    (requester as CreditAccount).ID = ThisBank.CurrentCreditID; 
                    break;
                case ("Homework_13_bank_system.Models.structsBin.DebitAccount"):
                    ++ThisBank.CurrentDebitID;
                    (requester as DebitAccount).ID = ThisBank.CurrentDebitID;
                    break;
                case ("Homework_13_bank_system.Models.structsBin.DepositAccount"):
                    ++ThisBank.CurrentDepositID;
                    (requester as DepositAccount).ID = ThisBank.CurrentDepositID;
                    break;
            }
        }
    }
}
