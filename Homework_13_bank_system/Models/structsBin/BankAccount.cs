using System.Diagnostics;

namespace Homework_13_bank_system.Models.structsBin
{
    //public class IDSetter<T> where T : BankAccount
    //{
    //    public void SetID(T accountType)
    //    {
    //        if (accountType.GetType() == typeof(CreditAccount))
    //    }
    //}

    public abstract class BankAccount/*<T> : IBankAccount<T>*/
    {
        long id;

        bool isActive = true;

        public long ID
        {
            get => id;
            set => id = value;
        }

        public bool IsActive
        {
            get => isActive;
            set => isActive = value;
        }

        public abstract void SetId();

        long accountAmount = 0;

        /// <summary>
        /// Баланс счета
        /// </summary>
        public long AccountAmount
        { get => accountAmount; set => accountAmount = value; }

/*        private T account;
        public T Account => account;

        public void SetAccountType(T account)
        {
            this.account = account;
        }*/
        public long CheckAmount()
        {
            return AccountAmount;
        }
        public void AddMoneyToAccount(long value)
        {
            AccountAmount += value;
            Debug.WriteLine($"client add {value}$ to account. account condition: {this}");
        }
        public override string ToString()
        {
            return $"type: {GetType()}, " +
                $" ID - {id}, " +
                $"Amount - {AccountAmount}";
        }
    }
}

