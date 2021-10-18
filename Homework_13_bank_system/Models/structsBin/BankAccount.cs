namespace Homework_13_bank_system.Models.structsBin
{
    //public class IDSetter<T> where T : BankAccount
    //{
    //    public void SetID(T accountType)
    //    {
    //        if (accountType.GetType() == typeof(CreditAccount))
    //    }
    //}

    public abstract class BankAccount
    {
        public long id;

        public bool isActive = true;

        long accountAmount = 0;
        public long AccountAmount
        { get => accountAmount; set => accountAmount = value; }
    }
}

