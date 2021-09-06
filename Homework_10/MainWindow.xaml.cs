using System;
using System.Windows;
using static Homework_10.JsonExport;
using static Homework_9.TeleBot;
using static Homework_10.TeleBot;
using static Homework_10.MessageLog;
using System.Diagnostics;

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
            if (selectedUserId.Text != "")
            {
                CurrentUserId = selectedUserId.Text;
                Debug.WriteLine(selectedUserId.Text);
                ImageExplorer a = new();
                a.Show();
            }
            else 
            {
                TargetError();
            }
        }

        private void JsonExportButton_Click(object sender, RoutedEventArgs e)
        {
            MessagesToJson();
        }

        private void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (selectedUserId.Text != "")
            {
                if (messageToUser.Text != "")
                {
                    bot.SendTextMessageAsync(
                        selectedUserId.Text,
                        messageToUser.Text
                        );
                }
                else
                {
                    MessageContentError();
                }
            }
            else
            {
                TargetError();
            }
        }
        public void MessageContentError()
        {
            messageContentError ce = new();
            ce.ShowDialog();
        }
        public void TargetError()
        {
            targerError te = new();
            te.ShowDialog();
        }
    }
}
