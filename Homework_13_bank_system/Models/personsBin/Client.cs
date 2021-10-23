using System.Collections.ObjectModel;
using Homework_13_bank_system.Models.structsBin;

namespace Homework_13_bank_system.Models.personsBin
{
    public class Client : IRenamableObject
    {
        #region Поля
        private string name;
        private int reputation;
        private long clientId;
        private CreditAccount clientsCreditAccount;
        private DebitAccount clientsDebitAccount;
        private DepositAccount clientsDepositAccount;
        private CreditHandler<CreditAccount> creditHandler;
        private DepositHandler<DepositAccount> depositHandler;
        private bool creditIsActive = false;
        private bool debitIsActive = false;
        #endregion

        #region Свойства
        /// <summary>
        /// экземпляр класса для выполнения действий с депозитным счетом
        /// </summary>
        public DepositHandler<DepositAccount> DepositHandler
        {
            get => depositHandler;
            set => depositHandler = value;
        }
        /// <summary>
        /// флаг наличия активного кредита
        /// </summary>
        public bool CreditIsActive
        {
            get => creditIsActive;
            set => creditIsActive = value;
        }

        /// <summary>
        /// флаг наличия активного дебетового счета
        /// </summary>
        public bool DebitIsActive
        {
            get => debitIsActive;
            set => debitIsActive = value;
        }
        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        { get => name; set => name = value; }

        /// <summary>
        /// экземпляр кредитного счета
        /// </summary>
        public CreditAccount ClientsCreditAccount
        { get => clientsCreditAccount; set => clientsCreditAccount = value; } 

        /// <summary>
        /// экземпляр дебетового счета
        /// </summary>
        public DebitAccount ClientsDebitAccount
        { get => clientsDebitAccount; set => clientsDebitAccount = value; } 

        /// <summary>
        /// Экземпляр депозитного счета
        /// </summary>
        public DepositAccount ClientsDepositAccount
        { get => clientsDepositAccount; set => clientsDepositAccount = value; }

        /// <summary>
        /// Репутация
        /// </summary>
        public int Reputation
        { get => reputation; set => reputation = value; }

        /// <summary>
        /// ID
        /// </summary>
        public long ClientId
        { get => clientId; set => clientId = value; }
        #endregion

        /// <summary>
        /// Метод переименовывающий обьект
        /// </summary>
        /// <param name="newName"></param>
        public void ReName(string newName)
        { this.Name = newName; }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Name">Имя</param>
        /// <param name="Reputation">Репутация</param>
        public Client(string Name, int Reputation = 5)
        {
            ClientsDebitAccount = new();
            this.Name = Name;
            this.Reputation = Reputation;
        }
    }
}
