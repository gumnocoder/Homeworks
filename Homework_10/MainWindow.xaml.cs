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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Homework_9;
using static Homework_10.TeleBot;
namespace Homework_10
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        [Obsolete]
        public MainWindow()
        {
            InitializeComponent();

            TeleBot teleBot = new TeleBot(this);

            logList.ItemsSource = teleBot.BotMessageLog;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TrayButton_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void TrayIcon_Click(object sender, RoutedEventArgs e)
        {
            this.Show();
        }
    }
}
