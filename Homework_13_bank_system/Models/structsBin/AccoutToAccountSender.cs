namespace Homework_13_bank_system.Models.structsBin
{
    public class AccoutToAccountSender<T> where T : BankAccount
    {
        T accountSender;
        T accountReciever;
        long money;

        public AccoutToAccountSender(
            T AccountSender, 
            T AccountReciever, 
            long moneyAmount)
        {
            accountSender = AccountSender;
            accountReciever = AccountReciever;
            this.money = moneyAmount;

            if (CheckAccountCapacity(accountSender, money))
            {
                AccountTransaction(accountSender, accountReciever, money);
            }
         }

        private bool CheckAccountCapacity(
            T AccountSender, 
            long moneyToSend)
        {
            if (AccountSender.AccountAmount >= moneyToSend)
            {
                return true;
            }
            return false;
        }

        private void AccountTransaction(
            T AccountSender, 
            T AccountReciever, 
            long moneyAmount)
        {
            AccountSender.AccountAmount -= moneyAmount;
            AccountReciever.AccountAmount += moneyAmount;
        }
    }
}
