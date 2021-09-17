using System;
using System.Windows;
using System.Windows.Input;
using static System.Windows.SystemParameters;

namespace Homework_11_wpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        bool flag = false;
        private void maximizeBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (flag == false)
            {
                flag = true;
                this.Top = 0;
                this.Left = 0;
                this.Width = PrimaryScreenWidth;
                this.Height = PrimaryScreenHeight;
            }
            else
            {
                flag = false;
                this.Width = 800;
                this.Height = 450;
            }
        }

        private void minimizeBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            Show();
        }
    }
}
