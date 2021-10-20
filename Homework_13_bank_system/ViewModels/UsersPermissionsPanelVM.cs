
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using Homework_13_bank_system.View;
using Homework_13_bank_system.Models.personsBin;

namespace Homework_13_bank_system.ViewModels
{
    class UsersPermissionsPanelVM
    {
        string[] types = {
            "администратор",
            "модератор",
            "операционист",
            "специалист по ВИП",
            "специалист по Юр.лицам"
        };

        public string[] Types
        {
            get => types;
            set => types = value;
        }

        User selectedUser;

        public User SelectedUser
        {
            get
            {
                if (selectedUser != null)
                {
                    foreach (User e in UsersLists<User>.usersList)
                    {
                        if (selectedUser.UserId == e.UserId)
                        {
                            selectedUser = e;
                            Debug.WriteLine(selectedUser == e);
                        }
                    }
                }
                return selectedUser;
            }
            set
            {
                selectedUser = value;
            }
        }
        public ObservableCollection<User> Users
        {
            get => RefreshUsers();
        }

        private ObservableCollection<User> RefreshUsers()
        {
            ObservableCollection<User> tmp = new();
            foreach (var e in UsersLists<User>.usersList)
            {
                tmp.Add(e);
            }
            return tmp;
        }

        public static readonly RelayCommand CloseCommand =
            new(o => ((Window)o).Close());

        private RelayCommand deleteUserCommand;

        public RelayCommand DeleteUserCommand
        {
            get => deleteUserCommand ??= new(DeleteUser);
        }
        private void DeleteUser(object sender)
        {
            foreach (User u in UsersLists<User>.usersList)
            {
                if (SelectedUser == u)
                {
                    UsersLists<User>.RemoveFromList(u);
                    AdminPanelVM.editPermissionsWindow.Close();
                    break;
                }
            }
        }
    }
}