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

        string fileName;

        string fileExtension;

        float fileSize;

        string FileName { get; set; }
        string FileExtension { get; set; }
        float FileSize { get; set; }

        public RootContent(string FileName, string FileExtension, float FileSize)
        {
            this.fileName = FileName;
            this.fileExtension = FileExtension;
            this.fileSize = FileSize;
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
        }

        private void ToTrayImageExplorer_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void CloseImageExplorer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TrayIcon_Click(object sender, RoutedEventArgs e)
        {
            this.Show();
        }
        private void FillFilesExplorer()
        {
            foreach (var file in di.GetFiles())
            {
                var name = file.Name.ToString();
                var ext = file.Extension.ToString();
                
                //file.ToString().Substring(file.ToString().LastIndexOf('.'));
                float size = di.GetFiles().Length;
                Debug.WriteLine($"{name} {ext} {size}");
                AllFiles.Add(new RootContent(name, ext, size));
            }
        }

        private void SendFile_Click(object sender, RoutedEventArgs e)
        {
            FillFilesExplorer();
        }
    }
}
