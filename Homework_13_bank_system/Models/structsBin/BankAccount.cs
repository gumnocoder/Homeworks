namespace Homework_13_bank_system.Models.structsBin
{
    abstract class BankAccount
    {
        public long id;

        public bool idExiscts = false;

        public bool isActive = true;

        long accountAmount = 0;
        public long AccountAmount
        { get => accountAmount; set => accountAmount = value; }
    }
}
