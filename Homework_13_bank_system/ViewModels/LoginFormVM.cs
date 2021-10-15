using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using static Homework_13_bank_system.JsonDataLoadSave;
using static Homework_13_bank_system.User;
using static Homework_13_bank_system.UsersLists;
using static Homework_13_bank_system.LoginForm;
using System.Windows.Input;
using System.Security;
using System.Windows.Controls;

namespace Homework_13_bank_system.ViewModels
{

    public class LoginFormVM : BaseViewModel
    {
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
                    //LoginForm lf = new();
                    //string a = lf.GetPassword();
                    //Debug.WriteLine(a);
                    Debug.WriteLine(Pass);
                    LoadingChain();
                    foreach (User u in usersList)
                    {
                        if (u.Name == Login & u.Pass == Pass)
                        {
                            AuthIsVisible = false;
                            //MainWindow w = new();
                            currentUser = u;
                            Debug.WriteLine(u);
                            //w.Show();

                        }
                    }
                });
            }
            
/*            LoadingChain();

            foreach (User u in usersList)
            {
                if (login == u.Name && pass == u.Pass)
                {
                    currentUser = u;
                    if (currentUser.Name != "admin")
                    {
                        usersList = new();
                    }
                    var window = new MainWindow();
                    Close();
                    window.Show();
                }
            }*/
        }
        private void LoadingChain()
        {
            UsersLists bd = new();
            usersList = UsersFromJson();
        }
    }
}
