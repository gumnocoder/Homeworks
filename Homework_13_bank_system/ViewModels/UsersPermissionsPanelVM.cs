using System;
using System.Collections.ObjectModel;
using System.Windows;
using static Homework_13_bank_system.UsersLists;

namespace Homework_13_bank_system.ViewModels
{
    class UsersPermissionsPanelVM
    {
        public ObservableCollection<User> Users
        {
            get => RefreshUsers();
        }

        private ObservableCollection<User> RefreshUsers()
        {
            ObservableCollection<User> tmp = new();
            foreach (var e in usersList)
            {
                tmp.Add(e);
            }
            return tmp;
        }

        public static readonly RelayCommand CloseCommand =
            new( o => ((Window)o).Close());

    }
}
