using System.ComponentModel;
using System.Windows;
using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.BaseViewModel;
using static Homework_11_wpfUI.MainWindow;
using Homework_11_wpfUI;
using System.Windows.Controls;
using static Homework_11_ConsUI.employeBin.Worker;

namespace Homework_11_wpfUI.masterForms
{
    /// <summary>
    /// Логика взаимодействия для MasterOfManagerCreation.xaml
    /// </summary>
    public partial class MasterOfManagerCreation : Window
    {
        public Window w;
        //MasterOfManagerCreation master = new();
        public MasterOfManagerCreation()
        {
            InitializeComponent();
            
            //frame.Navigate(home);
        }

        private void tittle_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Window w = Window.GetWindow(this);
            //if (null != w)
            //{
            //    ((UserControl)w.FindName("a")).Visibility = Visibility.Hidden;
            //    ((UserControl)w.FindName("b")).Visibility = Visibility.Visible;
            //}
        }

        private bool workerCreation = false;
        private bool internCreation = false;
        private bool officeCreation = false;
        private bool departmentCreation = false;

        private void CreateWorkerCycle()
        {
            string name = $"worker_{workersCount}";
            if (workerNameBox.Text != "")
            { name = workerNameBox.Text; }

            byte age = 18;
            if (workerAgeBox.Text != "")
            {
                if (byte.TryParse(workerAgeBox.Text, out byte tmp))
                { 
                    if (tmp > 17 & tmp < 100)
                    { age = tmp; }
                }
            }

            int salary = 1;
            if (workerSalaryBox.Text != "")
            {
                if (int.TryParse(workerSalaryBox.Text, out int tmp))
                { salary = tmp; }
            }

            temporaryWorkPlace.Hire(new Worker(salary, name, age));
        }
        private void createWorkerBtn_Click(object sender, RoutedEventArgs e)
        {
            w = GetWindow(this);
            workerCreation = true;

            ((Grid)w.FindName("gridWithButtons")).Visibility = Visibility.Hidden;
            ((Border)w.FindName("wizardBody")).Visibility = Visibility.Visible;
            ((Border)w.FindName("instuctionsFrame")).Visibility = Visibility.Visible;

            thisEmployeWorkPlace.Text = temporaryWorkPlace.Name;
            workerNameHeader.Text = "Worker`s name:";
            workerSalaryHeader.Text = "Salary (for one hour):";
        }

        private void createInternBtn_Click(object sender, RoutedEventArgs e)
        {
            w = GetWindow(this);
            internCreation = true;

            ((Grid)w.FindName("gridWithButtons")).Visibility = Visibility.Hidden;
            ((Border)w.FindName("wizardBody")).Visibility = Visibility.Visible;
            ((Border)w.FindName("instuctionsFrame")).Visibility = Visibility.Visible;

            workerNameHeader.Text = "Intern`s name:";
            workerSalaryHeader.Text = "Salary (for one month):";
        }

        private void createOfficeBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void createDepartmentBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void createBtn_Click(object sender, RoutedEventArgs e)
        {
            if (workerCreation)
            {
                CreateWorkerCycle();
                workerCreation = false;
                Close();
            }
            else if (internCreation)
            {
                internCreation = false;
            }
            else if (officeCreation)
            {
                officeCreation = false;
            }
            else if (departmentCreation)
            {
                departmentCreation = false;
            }
        }
    }
}