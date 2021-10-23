using System;
using System.Diagnostics;
using Homework_13_bank_system.Models.personsBin;
using static Homework_13_bank_system.Models.structsBin.Timelapse;

namespace Homework_13_bank_system.Models.structsBin
{
    /// <summary>
    /// Класс выполняющий характерные функции для депозитных счетов
    /// в виде реализации паттерна "Команда"
    /// </summary>
    /// <typeparam name="T">Депозитный счет</typeparam>
    public class DepositHandler<T> : ICommandAction
        where T : DepositAccount
    {
        #region Поля
        private readonly DepositAccount _account;
        private readonly Client _client;
        private bool _executed = false;
        #endregion

        #region Свойства
        public bool Executed
        {
            get => _executed;
            set => _executed = value;
        }
        #endregion

        #region Методы
        /// <summary>
        /// вынести за пределы класса
        /// </summary>
        public long CalculatePercentage()
        {
            return
                Convert.ToInt64(
                    Math.Round(
                        (double)(_account.AccountAmount * _account.Percent / 100)));
        }
        public void SkipMonth()
        {
            --_client.ClientsDepositAccount.ExpirationRate ;
            _account.AccountAmount += CalculatePercentage();
            Debug.WriteLine($"" +
                $"Month turned, {_client}\n" +
                $"has added {CalculatePercentage()}\n" +
                $"on deposit account\n" +
                $"account condition {_account}\n" +
                $"expires: {_account.ExpirationRate}");
        }
        //void AddMoneyFromClient(long amount)
        //{
        //    if (_account.IsActive)
        //    {
        //        _account.AccountAmount += amount;
        //        new ReputationIncreaser(_client).Execute();
        //        Execute();
        //    }
        //}
        void EndOfDepositPeriod()
        {
            if (_account.ExpirationRate == 0)
            {
                _account.AccountAmount -= _account.AccountAmount;
                _account.IsActive = false;
                new ReputationIncreaser(_client, 5).Execute();
                Execute();
            }
        }
        public void Execute()
        {
            Executed = true;
        }
        #endregion

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="client">Клиент-владелец счета</param>
        /// <param name="account">счет</param>
        public DepositHandler(Client client, T account)
        {
            _account = account;
            _client = client;
        }
    }
}
