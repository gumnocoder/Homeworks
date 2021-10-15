using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Homework_13_bank_system.ViewModels;
using static Homework_13_bank_system.JsonDataLoadSave;
using static Homework_13_bank_system.User;
using static Homework_13_bank_system.UsersLists;
using static Homework_13_bank_system.ViewModels.LoginFormVM;

namespace Homework_13_bank_system
{

    /// <summary>
    /// Логика взаимодействия для LoginForm.xaml
    /// </summary>
    public partial class LoginForm : Window
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
