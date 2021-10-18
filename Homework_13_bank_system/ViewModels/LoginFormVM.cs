using System;
using System.Diagnostics;
using System.Windows.Input;
using Homework_13_bank_system.Models.appliedFunctional;
using static Homework_13_bank_system.User;

namespace Homework_13_bank_system.ViewModels
{

    public class LoginFormVM : BaseViewModel
    {

        private bool authIsVisible = true;

        public bool AuthIsVisible
        {
            get => authIsVisible;
            set
            {
                if (authIsVisible != value)
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

        private RelayCommand clearLogin;

        public RelayCommand ClearLogin
        {
            get => clearLogin ??= new(clearLoginField);
        }

        public void clearLoginField(object sender)
        {
            Login = string.Empty;
        }
        public void clearPassField()
        {
            Pass = string.Empty;
        }

        public ICommand EnterBtn_Click
        {
            get
            {
                return new RelayCommand((obj) =>
                {
                    DataLoader<User>.LoadingChain("users.json");
                    bool finded = false;
                    foreach (User u in UsersLists<User>.usersList)
                    {
                        if (u.Login == Login & u.Pass.ToString() == Pass)
                        {
                            AuthIsVisible = false;
                            CurrentUser = u;
                            finded = true;
                        }
                    }
                    if (!finded) System.Windows.MessageBox.Show("Введены неправильные данные!");
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
