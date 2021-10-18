using System;
using System.Diagnostics;
using Homework_13_bank_system.Models.personsBin;
using static Homework_13_bank_system.Models.structsBin.Bank;


namespace Homework_13_bank_system.Models.structsBin
{
    class CreditAccount : BankAccount, ICredited, IAccountActions
    {

        Random rnd = new Random();

        public long SetId()
        {
            return ++ThisBank.CurrentCreditID;
        }

        public void Overdraft(long amount, Client client)
        {
            AccountAmount -= amount;
            //client.DecreaseRep(1);
        }

        public void PayOff(Client client)
        {
            AccountAmount -= AccountAmount;
            isActive = false;
            //client.IncreaseRep(2);
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
            { if (id != 0) { id = SetId(); } }
        }

        public bool Executed => throw new NotImplementedException();

        public CreditAccount(long CreditAmount, Client client)
        {
            if (CreditCheck.CheckForCredit(client))
            {
                AccountAmount = -CreditAmount;
                isActive = true;
                id = SetId();
                client.Accounts.Add(this);
            }
            else Debug.WriteLine("credit not avaible for that person");
        }

        public override string ToString()
        {
            return $"type: {GetType()}, " +
                $"Activity - {isActive}," +
                $" ID - {id}, " +
                $"Amount - {AccountAmount}";
        }

        public long CheckAmount()
        {
            return AccountAmount;
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}

