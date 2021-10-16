using System.Collections.ObjectModel;

namespace Homework_13_bank_system.Models.structsBin
{
    interface IRepositoryAccounts<T> 
        where T : IAccount
    {
        void Create(ObservableCollection<T> TAccountsCollection);
        void Read(ObservableCollection<T> TAccountsCollection);
        void Update(T account);
        void Delete(T account);

    }
}
