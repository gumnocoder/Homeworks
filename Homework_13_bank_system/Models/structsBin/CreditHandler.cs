using System;
using Homework_13_bank_system.Models.personsBin;


namespace Homework_13_bank_system.Models.structsBin
{
    public class CreditHandler<T> : ICommandAction 
        where T : CreditAccount
    {
        #region Поля
        private readonly T _account;
        private readonly Client _client;
        private bool _executed = false;
        #endregion

        public bool Executed
        {
            get => _executed; 
            set => _executed = value; 
        }

        public CreditHandler(Client client)
        {
            this._client = client;
            this._account = (T)(BankAccount)client.ClientsCreditAccount;
        }
        #region Методы
        public void ExtendCreditAmount(long amount)
        {
            if (_client.Reputation > 7)
            {
                _account.AccountAmount -= amount;
                new ReputationDecreaser(_client).Execute();
                Execute();
            }
        }

        public void CalculatePercentage()
        {
            throw new NotImplementedException();
        }

        public void PayOff()
        {
            _account.AccountAmount -= _account.AccountAmount;
            _client.CreditIsActive = false;
            new ReputationIncreaser(_client, 2).Execute();
            Execute();
        }

        //public void AddCreditPercent()
        //{
        //    _account.AccountAmount = 
        //        Convert.ToInt64(
        //            Math.Round((double)(
        //            _account.AccountAmount * _account.Percent / 100)));
        //}

        public void Execute()
        {
            Executed = true;
        }
        #endregion
    }
}

