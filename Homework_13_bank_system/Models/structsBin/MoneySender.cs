using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_13_bank_system.Models.structsBin
{
    class MoneySender<T> : IMoneySender<T> where T : BankAccount
    {
        public void SendMoney(long sum, T sender, T reciever)
        {
            if (sender.GetType() != typeof(DepositAccount))
            {
                if (reciever != null)
                {
                    if (sender.AccountAmount >= sum!)
                    {
                        sender.AccountAmount -= sum;
                        reciever.AccountAmount += sum;
                    }
                    else Debug.WriteLine("not enough money on sender account");
                }
                else Debug.WriteLine("reciever account is not exists");
            }
            else Debug.WriteLine("dender account cant be an Deposit account");
        }
    }
}
