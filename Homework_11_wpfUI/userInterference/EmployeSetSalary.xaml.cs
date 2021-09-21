using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Homework_11_wpfUI.MainWindow;

namespace Homework_11_wpfUI.userInterference
{
    /// <summary>
    /// Логика взаимодействия для EmployeSetSalary.xaml
    /// </summary>
    public partial class EmployeSetSalary : Window
    {
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) AplyBtn_Click(sender, e);
        }
        public EmployeSetSalary()
        {
            InitializeComponent();
        }

        private void AplyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (newEmployeSalary.Text != null)
            {
                if (int.TryParse(newEmployeSalary.Text, out int tmp))
                {
                    if (tmp > 0 & tmp <  1_000_000)
                    {
                        thisEmployeSalary = tmp;
                    }
                }
            }
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
