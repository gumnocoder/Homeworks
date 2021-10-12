using System;
using System.Diagnostics;
using System.Windows;
using Homework_13_bank_system.ViewModels;
using static Homework_13_bank_system.JsonDataLoadSave;
using static Homework_13_bank_system.User;
using static Homework_13_bank_system.UsersLists;
using static Homework_13_bank_system.ViewModels.LoginFormVM;

namespace Homework_13_bank_system
{
    public interface IPasswordGetter
    {
        string GetPassword();
    }

    /// <summary>
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window, IPasswordGetter
    {

        public LoginForm()
        {
            InitializeComponent();
            //LoginFormVM vm = new();
            //DataContext = vm;
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

/*        private void enterBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginFieldValue.Text;
            string pass = passFieldValue.Password;

            LoadingChain();

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
            }
        }*/

        private void LoadingChain()
        {
            UsersLists bd = new();
            usersList = UsersFromJson();
        }

        private void enterBtn_Click(object sender, RoutedEventArgs e)
        {
            //LoginFormVM.login = loginFieldValue.Text;
            //LoginFormVM.EnterBtn_Click(sender, e);
        }

        public string GetPassword()
        {
            return uuu.Text;
        }

        private void uuu_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            Debug.WriteLine(uuu.Text);
        }
    }
}
