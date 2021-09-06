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
            /// создаётся коллекция сообщений 
            /// и запускаются подписки на события
            TeleBot teleBot = new TeleBot(this);
            /// лог сообщений привязывается к листу logList
            logList.ItemsSource = BotMessageLog;
        }

        /// <summary>
        /// нажатие на кнопку выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// кнопка вызвать из трея
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayIcon_Click(object sender, RoutedEventArgs e)
        {
            Show();
        }

        /// <summary>
        ///  кнопка свернуть в трей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrayButton_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// обзор файлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExplorerButton_Click(object sender, RoutedEventArgs e)
        {
            /// сработает только после выбора получателя
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
        
        /// <summary>
        /// запускает цикл сохранения лога в json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JsonExportButton_Click(object sender, RoutedEventArgs e)
        {
            MessagesToJson();
        }

        /// <summary>
        /// послать сообщение 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /// только если выбран получатель
            if (selectedUserId.Text != "")
            {
                /// и набран текст в соответствующем поле
                if (messageToUser.Text != "")
                {
                    await bot.SendTextMessageAsync(
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

        /// <summary>
        /// вызов окна с сообщением об ошибке
        /// </summary>
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
