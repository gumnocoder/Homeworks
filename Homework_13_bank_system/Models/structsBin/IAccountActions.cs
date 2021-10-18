namespace Homework_13_bank_system.Models.structsBin
{
    public interface IAccountActions
    {
        void Execute();
        public bool Executed { get; }
        //long SetId();
        //long CheckAmount();
    }

    public class OpenCreditAccount : IAccountActions
    {
        private bool executed;
        public bool Executed => executed;

        public void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}