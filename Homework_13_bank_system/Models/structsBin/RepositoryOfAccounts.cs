using System;
using System.Collections.ObjectModel;

namespace Homework_13_bank_system.Models.structsBin
{
    class RepositoryOfAccounts : IRepositoryAccounts<IAccount>
    {
        private ObservableCollection<IAccount> clientAccounts;

        public ObservableCollection<IAccount> ClientAccounts
        {
            get => clientAccounts;
            set
            {
                if (clientAccounts == null)
                {
                    clientAccounts = new();
                }
            }
        }
        public void Create(ObservableCollection<IAccount> TAccountsCollection)
        {
            ClientAccounts = new();
        }

        public void Delete(IAccount account)
        {
            ClientAccounts.Add(account);
        }

        public void Read(ObservableCollection<IAccount> TAccountsCollection)
        {
            throw new NotImplementedException();
        }

        public void Update(IAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
