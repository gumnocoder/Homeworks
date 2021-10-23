using System;
using System.Diagnostics;
using Homework_13_bank_system.Models.appliedFunctional;
using Homework_13_bank_system.Models.personsBin;
using static Homework_13_bank_system.Models.structsBin.Bank;


namespace Homework_13_bank_system.Models.structsBin
{
    public class CreditAccount : BankAccount, IPercentContainer
    {
        double percent;
        int expiration;
        public double Percent 
        { 
            get => percent; 
            set 
            { 
                if (value > 12) percent = 12; 
                else if (value < 2) percent = 2; 
                else percent = value; 
            } 
        }
        public int Expiration
        { 
            get => expiration;
            set 
            {
                if (value > 36) expiration = 36;
                else if (value < 6) expiration = 6;
                else expiration = value;
            } 
        }

        public override void SetId()
        {
            ID = ++ThisBank.CurrentCreditID;
        }

        public CreditAccount(long CreditAmount, Client client)
        {
            if (!client.CreditIsActive)
            {
                AccountAmount = -CreditAmount;
                SetId();
                client.CreditIsActive = true;
                client.ClientsCreditAccount = this;
            }
            else Debug.WriteLine("credit not avaible for that person");
        }
    }
}

