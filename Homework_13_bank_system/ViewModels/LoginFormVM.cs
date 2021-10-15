using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using static System.Windows.SystemParameters;
using static Homework_13_bank_system.JsonDataLoadSave;
using static Homework_13_bank_system.User;
using static Homework_13_bank_system.UsersLists;
using static Homework_13_bank_system.Models.appliedFunctional.DataLoader;
using System;

namespace Homework_13_bank_system.ViewModels
{

    public class LoginFormVM : BaseViewModel
    {

        public LoginFormVM()
        {

        }

        private bool authIsVisible = true;

        public bool AuthIsVisible
        {
            get => authIsVisible;
            set
            { if (authIsVisible != value)
                {
                    authIsVisible = value;
                    OnPropertyChanged();
                }
            }
        }

        string login = "логин";
        string pass = "*****";

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }
        }

        public string Pass
        {
            get => pass;
            set => pass = value;
        }

        public ICommand EnterBtn_Click
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    Debug.WriteLine(Login);
                    Debug.WriteLine(Pass);
                    LoadingChain();
                    foreach (User u in usersList)
                    {
                        if (u.Name == Login & u.Pass == Pass)
                        {
                            AuthIsVisible = false;
                            currentUser = u;
                            Debug.WriteLine(u);
                        }
                    }
                });
            }
        }
        private RelayCommand applicationForcedExit;

        public RelayCommand ApplicationForcedExit
        {
            get => applicationForcedExit ??= new(
                closeBtn_Click);
        }
        public void closeBtn_Click(object sender)
        {
            Environment.Exit(0);
        }
    }
}
