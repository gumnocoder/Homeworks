using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Homework_13_bank_system.Models.structsBin;
using Homework_13_bank_system.View;
using static System.Windows.SystemParameters;
using static Homework_13_bank_system.Models.structsBin.Bank;
using System.Diagnostics;
using Homework_13_bank_system.Models.appliedFunctional;
using Homework_13_bank_system.Models.personsBin;

namespace Homework_13_bank_system.ViewModels
{
    public class MainWindowVM : BaseViewModel
    {
        #region Поля

        private RelayCommand appExit;
        private RelayCommand minimize;
        private RelayCommand maximize;
        private RelayCommand saveData;
        private string cUser;
        private bool hidden = false;
        private bool maximized = false;
        private Window mainWindow = Application.Current.MainWindow;

        public string CUser
        {
            get => cUser;
            set { if (cUser != value) cUser = value; }
        }

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
            { DataSaver<User>.SavingChain("users.json"); }
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
            DataSaver<User>.SavingChain("users.json");
        }

        #endregion

        #region
        #endregion

        #endregion

        /// <summary>
        /// конструктор
        /// </summary>
        public MainWindowVM()
        {
            UsersLists<User>.usersList = new();
            //usersList = LoadingChain();
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

            if (User.CurrentUser != null)
            {
                CUser = User.CurrentUser.ToString();
                mainWindow.Visibility = Visibility.Visible;
                lf.Close();
            }
            BankSettingsLoader bs = new(ThisBank);
            Debug.WriteLine("id " + ThisBank.CurrentDebitID.ToString());
            DataSaver<Bank>.JsonSeralize(ThisBank, "banksettings.json");

            //ObjectRenamer<User> or = new(User.CurrentUser, "Текущий пользователь");
        }
    }
}