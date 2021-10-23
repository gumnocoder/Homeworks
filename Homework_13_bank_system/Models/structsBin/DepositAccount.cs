using System;
using System.Diagnostics;
using Homework_13_bank_system.Models.appliedFunctional;
using Homework_13_bank_system.Models.personsBin;
using static Homework_13_bank_system.Models.structsBin.Bank;
using static Homework_13_bank_system.Models.structsBin.Timelapse;

namespace Homework_13_bank_system.Models.structsBin
{
    /// <summary>
    /// Депозитный счёт
    /// </summary>
    public class DepositAccount : BankAccount, IPercentContainer
    {
        #region Поля
        int expiration;
        double percent;
        #endregion
        #region Свойства

        /// <summary>
        /// Процент вклада
        /// </summary>
        public double Percent
        {
            get => percent;
            set
            {
                if (value > 7) percent = 7;
                else if (value < 1) percent = 1;
                else percent = value;
            }
        }

        /// <summary>
        /// Срок вклада
        /// </summary>
        public int Expiration
        {
            get => expiration;
            set
            {
                if (value > 48) expiration = 48;
                else if (value < 12) expiration = 12;
                else expiration = value;
            }
        }
        public int ExpirationRate { get; set; }
        #endregion

        public DepositAccount()
        {
            SetId();
        }
        /// <summary>
        /// Конструктор депозитного счета
        /// </summary>
        /// <param name="DepositAmount">Сумма депозита</param>
        /// <param name="client">Клиент-владелец</param>
        /// <param name="percent">Процент вклада (минимальный 1, максимальный 7)</param>
        /// /// <param name="expiration">Срок вклада (минимальный 12, максимальный 48)</param>
        public DepositAccount(long DepositAmount, Client client, int percent, int expiration)
        {
            if (!client.DebitIsActive)
            {
                SetId();
                Percent = percent;
                Expiration = expiration;
                ExpirationRate = Expiration;
                AccountAmount = +DepositAmount;
                client.DebitIsActive = true;
                new ReputationIncreaser(client);
                client.ClientsDepositAccount = this;
                client.DepositHandler = new(client, this);
                MonthPropertyChanged += client.DepositHandler.SkipMonth;
            }
            else Debug.WriteLine("Депозитный счёт уже открыт!");
        }
        public override void SetId()
        {
            ID = ++ThisBank.CurrentDepositID;
        }
    }
}
