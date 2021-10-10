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
using static Homework_13_bank_system.UsersLists;
using static Homework_13_bank_system.Models.structsBin.Bank;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using static Homework_13_bank_system.JsonDataLoadSave;
using static Homework_13_bank_system.User;
using System.Collections.ObjectModel;

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
            Debug.WriteLine(currentUser);
            mainWindowBorder.MouseLeftButtonDown += new MouseButtonEventHandler(DragAnywhere);
            this.Closed += MainWindow_Closed;
            Closing += MainWindow_Closing;
            //LoadingChain();
            if (usersList.Count != 0)
            {
                Debug.WriteLine("usersList if full");
            }
            else Debug.WriteLine("userlist is empty");
            //new User("admin", "admin");
            //new User("moderator", "moderator");
            //foreach (var e in usersList) Debug.WriteLine(e.Name);
            //= UsersFromJson();
            //User list = new User("admin", "admin");
            //string file = "users.json";
            //string json = JsonConvert.SerializeObject(usersList);
            //File.WriteAllText(file, json);
            //Debug.WriteLine(bd["admin"]);
            //Debug.WriteLine(bd[10000]);
            //foreach (var e in usersList)
            //{ Debug.WriteLine(e); }
            //string path = @$"{Environment.CurrentDirectory}\lists\";
            //string file = @$"{Environment.CurrentDirectory}\lists\files.txt";
            //var a = ThisBank; 
            //UsedCreditIdentificators.Add(123235567);
            //UsedCreditIdentificators.Add(12323267);
            //UsedCreditIdentificators.Add(12378875567);
            //NumberListSaver.WriteNumbers<ObservableCollection<long>>(path, file, UsedCreditIdentificators);
            //NumberListSaver.ReadNumbers<ObservableCollection<long>>(path, file, UsedCreditIdentificators);
            //foreach (var e in UsedCreditIdentificators) Debug.WriteLine(e);
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
            Close();
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
