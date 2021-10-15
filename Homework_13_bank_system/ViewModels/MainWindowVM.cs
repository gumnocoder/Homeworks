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
        private RelayCommand saveData;
        private bool hidden = false;
        private bool maximized = false;
        private Window mainWindow = Application.Current.MainWindow;

        #endregion

        #region Команды

        public RelayCommand SaveData
        {
            get => saveData ??= new(
                DataSaving);
        }
        public RelayCommand AppExit
        {
            get => appExit ??= new(
                ExitFromApplication);
        }
        public RelayCommand Minimize
        {
            get => minimize ??= new(
                TaskbarIcon_TrayLeftMouseDown);
        }

        public RelayCommand Maximize
        {
            get => maximize ??= new(
                maxBtn_Click);
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

        private void ExitFromApplication(object sender)
        {
            mainWindow.Close();
        }

        private void maxBtn_Click(object sender)
        {
            if (!maximized)
            {
                mainWindow.Top = 0;
                mainWindow.Left = 0;
                mainWindow.Width = PrimaryScreenWidth;
                mainWindow.Height = PrimaryScreenHeight;
                maximized = true;
            }
            else
            {
                mainWindow.Width = 800;
                mainWindow.Height = 450;
                maximized = false;
            }
        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender)
        {
            if (hidden)
            {
                mainWindow.Show();
                hidden = false;
            }
            else
            {
                mainWindow.Hide();
                hidden = true;
            }
        }
        void DragAnywhere(object sender, MouseButtonEventArgs e)
        {
            mainWindow.DragMove();
        }

        #endregion

        #region Взаимодействие с моделью

            #region Прикладные методы

        private void DataSaving(object sender)
        {

        }

            #endregion

        #endregion

        /// <summary>
        /// конструктор
        /// </summary>
        public MainWindowVM()
        {
            /// в конутрукторе реализована подписка 
            /// на закрытие программы с выводом 
            /// проверки на актуальность действий
            /// и подписка на перемещение окна мышкой за любой участок окна
            mainWindow.Closing += 
                MainWindow_Closing;

            mainWindow.MouseLeftButtonDown +=
                new MouseButtonEventHandler(DragAnywhere);

            /// при старте главное окно скрывается
            /// и запускается форма авторизации
            /// если пользователь авторизуется авторизация закрывается
            /// а главное окно активируется.
            /// если пользователь закрыл окно авторизации
            /// программа завершается
            LoginForm lf = new();
            mainWindow.Visibility = Visibility.Hidden;
            lf.ShowDialog();

            if (User.currentUser != null)
            {
                mainWindow.Visibility = Visibility.Visible;
                lf.Close();
            }
        }
    }
}
