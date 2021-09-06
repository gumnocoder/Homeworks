using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows;
using Telegram.Bot.Types.InputFiles;
using static Homework_10.MessageLog;
using static Homework_9.TeleBot;

namespace Homework_10
{
        
    /// <summary>
    /// Логика взаимодействия для ImageExplorer.xaml
    /// </summary>
    public partial class ImageExplorer : Window
    {
        /// <summary>
        /// список файлов в текущем каталоге
        /// </summary>
        public static ObservableCollection<RootContent> AllFiles = new();
        /// <summary>
        /// директория для вывода файлов
        /// </summary>
        public static string path = Environment.CurrentDirectory;
        public static DirectoryInfo di = new DirectoryInfo(path);

        /// <summary>
        /// конструктор
        /// </summary>
        public ImageExplorer()
        {
            InitializeComponent();
            FillFilesExplorer();
            rootContent.ItemsSource = AllFiles;
        }

        private void CloseImageExplorer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// заполняет коллекцию списком файлов
        /// </summary>
        private void FillFilesExplorer()
        {
            foreach (var file in di.GetFiles())
            {
                var name = file.Name.ToString();
                var ext = file.Extension.ToString();
                float size = file.Length;

                Debug.WriteLine($"{name} {ext} {size} byte");
                Debug.WriteLine(name.Substring(name.IndexOf(".")));
                AllFiles.Add(new RootContent(name, ext, size));
            }
        }

        /// <summary>
        /// обновляет список файлов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            AllFiles.Clear();
            FillFilesExplorer();
        }


        /// <summary>
        /// отправка файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Send_Click(object sender, RoutedEventArgs e)
        {
            /// если файл выбран
            if (fileName.Text != "")
            {
                using (FileStream stream = File.OpenRead(Environment.CurrentDirectory + @"\" + fileName.Text))
                    await bot.SendDocumentAsync(
                        chatId: CurrentUserId,
                        document: new InputOnlineFile(
                            content: stream,
                            fileName: fileName.Text),
                        caption: fileName.Text);
            }
            /// если файл не выбран
            else FileNotChosenError();
        }

        /// <summary>
        /// ошибка при не выбранном файле
        /// </summary>
        public void FileNotChosenError()
        {
            fileNotChosenError fe = new();
            fe.ShowDialog();
        }
    }
}
