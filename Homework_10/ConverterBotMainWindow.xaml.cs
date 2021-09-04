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

namespace Homework_10
{
    /// <summary>
    /// Логика взаимодействия для ConverterBotMainWindow.xaml
    /// </summary>
    public partial class ConverterBotMainWindow : Window
    {
        public ConverterBotMainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TrayIcon_Click(object sender, RoutedEventArgs e)
        {
            this.Show();
        }

        private void TrayButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void ExplorerButton_Click(object sender, RoutedEventArgs e)
        {
            ImageExplorer a = new ImageExplorer();
            a.Show();
        }
    }
}
