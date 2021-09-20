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
    /// Логика взаимодействия для EmployeRename.xaml
    /// </summary>
    public partial class EmployeRename : Window
    {
        public EmployeRename()
        {
            InitializeComponent();
        }

        private void AplyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (newEmployeName.Text != null)
            {
                temporaryEmploye.Rename(newEmployeName.Text);
            }
            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
