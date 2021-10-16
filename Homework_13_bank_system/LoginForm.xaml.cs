using System.Windows;
using static System.Windows.SystemParameters;

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
            Left = (PrimaryScreenWidth / 2) - 225;
            Top = (PrimaryScreenHeight / 2) - 150;
        }
    }
}
