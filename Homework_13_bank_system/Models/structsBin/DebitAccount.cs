using System.Diagnostics;
using Homework_13_bank_system.Models.appliedFunctional;
using Homework_13_bank_system.Models.personsBin;
using static Homework_13_bank_system.Models.structsBin.Bank;

namespace Homework_13_bank_system.Models.structsBin
{
    /// <summary>
    /// Дебетовый счет
    /// </summary>
    public class DebitAccount : BankAccount
    {
        /// <summary>
        /// Метод присваивающий номер счета
        /// </summary>
        public override void SetId()
        {
            ID = ++ThisBank.CurrentDebitID;
        }
        /// <summary>
        /// конструктор без параметров
        /// </summary>
        public DebitAccount()
        {
            SetId();
        }
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="DebitStartAmount">Первоначальная сумма на счету</param>
        /// <param name="client">Клиент-владелец данного счета</param>
        public DebitAccount(long DebitStartAmount, Client client)
        {
            if (!client.DebitIsActive)
            {
                AccountAmount = +DebitStartAmount;
                client.DebitIsActive = true;
                new ReputationIncreaser(client);
                IdSetter<DebitAccount>.SetId(this);
                client.ClientsDebitAccount = this;
            }
            else Debug.WriteLine("Дебетовый счёт уже открыт!");
        }
    }
}
