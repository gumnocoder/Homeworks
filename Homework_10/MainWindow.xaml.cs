using System;
using System.Windows;
using static Homework_10.JsonExport;
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

            logList.ItemsSource = BotMessageLog;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TrayIcon_Click(object sender, RoutedEventArgs e)
        {
            Show();
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

        private void JsonExportButton_Click(object sender, RoutedEventArgs e)
        {
            MessagesToJson();
        }
    }
}
