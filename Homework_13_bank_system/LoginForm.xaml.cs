using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Homework_13_bank_system.binaries;
using static Homework_13_bank_system.UsersLists;
using static Homework_13_bank_system.JsonDataLoadSave;
using static Homework_13_bank_system.User;

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
            Close();
        }

        private void enterBtn_Click(object sender, RoutedEventArgs e)
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
        }

        private void LoadingChain()
        {
            UsersLists bd = new();
            usersList = UsersFromJson();
        }
    }
}
