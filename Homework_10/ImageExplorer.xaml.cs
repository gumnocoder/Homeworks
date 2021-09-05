using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
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
    public class RootContent
    {

        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public float FileSize { get; set; }

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
        public static ObservableCollection<RootContent> AllFiles = new();
        public static string path = Environment.CurrentDirectory;
        public static DirectoryInfo di = new DirectoryInfo(path);
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

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            AllFiles.Clear();
            FillFilesExplorer();
        }
    }
}
