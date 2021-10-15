using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Homework_13_bank_system.ViewModels;
using static System.Windows.SystemParameters;
using static Homework_13_bank_system.JsonDataLoadSave;
using static Homework_13_bank_system.UsersLists;

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
            Visibility = Visibility.Hidden;
            LoginForm lf = new();
            lf.ShowDialog();
            if (User.currentUser != null)
                Visibility = Visibility.Visible;
            mainWindowBorder.MouseLeftButtonDown +=
                new MouseButtonEventHandler(DragAnywhere);
            Closed += MainWindow_Closed;
            Closing += MainWindow_Closing;
        }

        private void SavingChain()
        {
            JsonSeralize(usersList, "users.json");
        }

        private void LoadingChain()
        {
            UsersLists bd = new();
            usersList = UsersFromJson();
        }
        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Желаете сохранить изменения перед выходом?", 
                "Завершение работы приложения", 
                MessageBoxButton.YesNoCancel, 
                MessageBoxImage.Warning);
            if (result == MessageBoxResult.Cancel) e.Cancel = true;
            else if(result == MessageBoxResult.Yes)
            {
                SavingChain();
            }
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Close();
        }

        private void closeBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void minBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            hidden = true;
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

        private bool hidden = false;
        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            if (hidden)
            { Show(); hidden = false; }
            else { Hide(); hidden = true; }
        }

        private void savingBtn_Click(object sender, RoutedEventArgs e)
        {
            SavingChain();
        }
    }
}
