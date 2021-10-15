using System;
using System.Diagnostics;
using Homework_13_bank_system.Models.personsBin;
using static Homework_13_bank_system.Models.structsBin.Bank;

namespace Homework_13_bank_system.Models.structsBin
{
    class CreditAccount : BankAccount, ICredited
    {

        Random rnd = new Random();

        public long SetId()
        {
            long creditAc = rnd.Next(1_000_000, 9_000_000);

            foreach (var e in UsedCreditIdentificators)
            { if (e == creditAc) return SetId(); }

            return creditAc;
        }

        public void Overdraft(long amount, Client client)
        {
            AccountAmount -= amount;
            client.DecreaseRep(1);
        }

        public void PayOff(Client client)
        {
            AccountAmount -= AccountAmount;
            isActive = false;
            client.IncreaseRep(2);
        }

        public void Pay(long amount)
        {
            AccountAmount += amount;
            if (AccountAmount >= 0)
            { isActive = false; }
        }

        public long Id
        {
            get => id;
            set
            { if (!idExiscts) { id = SetId(); } }
        }

        public CreditAccount(long CreditAmount, Client client)
        {
            if (CreditCheck.CheckForCredit(client))
            {
                this.AccountAmount = -CreditAmount;
                isActive = true;
                if (!idExiscts)
                {
                    id = SetId();
                    idExiscts = true;
                }

                client.Accounts.Add(this);
            }
            else Debug.WriteLine("credit not avaible for that person");
        }

        public override string ToString()
        {
            return $"type: {GetType()}, Activity - {isActive}, ID - {id}, Amount - {AccountAmount}";
        }

        public long CheckAmount()
        {
            return this.AccountAmount;
        }
    }
}
