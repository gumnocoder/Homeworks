using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using static System.Windows.SystemParameters;
using static Homework_13_bank_system.Models.appliedFunctional.DataSaver;

namespace Homework_13_bank_system.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        #region Поля

        private RelayCommand appExit;
        private RelayCommand minimize;
        private RelayCommand maximize;
        private bool hidden = false;
        private bool maximized = false;

        #endregion

        #region Свойства

        public RelayCommand AppExit
        {
            get => appExit ??= new(
                ExitFromApplication, 
                CanMyExecute);
        }
        public RelayCommand Minimize
        {
            get => minimize ??= new(
                TaskbarIcon_TrayLeftMouseDown, 
                CanMyExecute);
        }

        public RelayCommand Maximize
        {
            get => maximize ??= new(
                maxBtn_Click, 
                CanMyExecute);
        }

        #endregion

        #region Методы
        public static void MainWindow_Closing(
                object sender,
                CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(
                "Желаете сохранить изменения перед выходом?",
                "Завершение работы приложения",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Warning);

            if (result == MessageBoxResult.Cancel)
            { e.Cancel = true; }

            else if (result == MessageBoxResult.Yes)
            { SavingChain(); }
        }

        private bool CanMyExecute(object obj)
        {
            return true;
        }

        private void ExitFromApplication(object sender)
        {
            Application.Current.MainWindow.Close();
        }

        private void maxBtn_Click(object sender)
        {
            if (!maximized)
            {
                Application.Current.MainWindow.Top = 0;
                Application.Current.MainWindow.Left = 0;
                Application.Current.MainWindow.Width = PrimaryScreenWidth;
                Application.Current.MainWindow.Height = PrimaryScreenHeight;
                maximized = true;
            }
            else
            {
                Application.Current.MainWindow.Width = 800;
                Application.Current.MainWindow.Height = 450;
                maximized = false;
            }
        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender)
        {
            if (hidden)
            {
                Application.Current.MainWindow.Show();
                hidden = false;
            }
            else
            {
                Application.Current.MainWindow.Hide();
                hidden = true;
            }
        }
        void DragAnywhere(object sender, MouseButtonEventArgs e)
        {
            Application.Current.MainWindow.DragMove();
        }

        #endregion

        public MainWindowVM()
        {
            Application.Current.MainWindow.Closing += 
                MainWindow_Closing;
            LoginForm lf = new();
            Application.Current.MainWindow.Visibility = Visibility.Hidden;
            lf.ShowDialog();
            if (User.currentUser != null)
            {
                Application.Current.MainWindow.Visibility = Visibility.Visible;
                lf.Close();
            }
            Application.Current.MainWindow.MouseLeftButtonDown +=
                new MouseButtonEventHandler(DragAnywhere);
        }
    }
}
