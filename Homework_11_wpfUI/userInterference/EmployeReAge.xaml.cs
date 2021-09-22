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
    /// Логика взаимодействия для EmployeReAge.xaml
    /// </summary>
    public partial class EmployeReAge : Window
    {
        public EmployeReAge()
        {
            InitializeComponent();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) AplyBtn_Click(sender, e);
        }

        private void AplyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (newEmployeAge.Text != "")
            {
                if (byte.TryParse(newEmployeAge.Text, out byte tmp))
                {
                    if (tmp > 17 & tmp < 100)
                    { thisEmployeAge = tmp; }
                    else Close();
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
