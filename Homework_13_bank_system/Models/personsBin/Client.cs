using System.Collections.ObjectModel;
using Homework_13_bank_system.Models.structsBin;

namespace Homework_13_bank_system.Models.personsBin
{
    public class Client : IRenamableObject
    {
        private string name;
        private ObservableCollection<BankAccount> accounts;
        private int reputation;
        private long clientId;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name
        { get => name; set => name = value; }
        /// <summary>
        /// Счета
        /// </summary>
        public ObservableCollection<BankAccount> Accounts
        { get => accounts; set => accounts = value; }
        /// <summary>
        /// Репутация
        /// </summary>
        public int Reputation
        { get => reputation; set => reputation = value; }
        /// <summary>
        /// ID
        /// </summary>
        public long ClientId
        {
            get => clientId;
            set => clientId = value;
        }

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
            this.Name = Name;
            this.Reputation = Reputation;
            this.Accounts = new();
        }
    }
}
