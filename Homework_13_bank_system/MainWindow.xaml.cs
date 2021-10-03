using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static System.Windows.SystemParameters;

namespace Homework_13_bank_system
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        void DragAnywhere(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
        public MainWindow()
        {
            InitializeComponent();
            mainWindowBorder.MouseLeftButtonDown += new MouseButtonEventHandler(DragAnywhere);
            this.Closed += MainWindow_Closed;
            Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Желаете сохранить изменения перед выходом?", 
                "Завершение работы приложения", 
                MessageBoxButton.YesNoCancel, 
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.Cancel) e.Cancel = true;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Close();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void minBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void maxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Width < PrimaryScreenWidth | Height < PrimaryScreenHeight)
            {
                Top = 0;
                Left = 0;
                Width = PrimaryScreenWidth; 
                Height = PrimaryScreenHeight; 
            }  
            else { Width = 800; Height = 450; }
        }
    }
}
