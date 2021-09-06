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
    /// для создания обьекта файл в текущем каталоге
    /// </summary>
    public class RootContent
    {
        /// <summary>
        /// название
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// расширение
        /// </summary>
        public string FileExtension { get; set; }
        /// <summary>
        /// размер
        /// </summary>
        public float FileSize { get; set; }

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="FileName">название</param>
        /// <param name="FileExtension">расширение</param>
        /// <param name="FileSize">размер</param>
        public RootContent(string FileName, string FileExtension, float FileSize)
        {
            this.FileName = FileName;
            this.FileExtension = FileExtension;
            this.FileSize = FileSize;
        }
        public override string ToString()
        {
            return $"{this.FileName} {this.FileSize} байт";
        }
    }
        
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

        private void ToTrayImageExplorer_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }

        private void CloseImageExplorer_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TrayIcon_Click(object sender, RoutedEventArgs e)
        {
            ShowDialog();
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

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (fileName.Text != "")
            {
                using (FileStream stream = File.OpenRead(Environment.CurrentDirectory + @"\" + fileName.Text))
                bot.SendDocumentAsync(
                    chatId: CurrentUserId,
                    document: new InputOnlineFile(
                        content: stream,
                        fileName: fileName.Text),
                    caption: fileName.Text);
            }
            else FileNotChosenError();
        }

        public void FileNotChosenError()
        {
            fileNotChosenError fe = new();
            fe.ShowDialog();
        }
    }
}
