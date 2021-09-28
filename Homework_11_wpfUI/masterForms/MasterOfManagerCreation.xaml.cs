using System.ComponentModel;
using System.Windows;
using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.employeBin.BaseViewModel;
using static Homework_11_wpfUI.MainWindow;
using Homework_11_wpfUI;
using System.Windows.Controls;
using static Homework_11_ConsUI.employeBin.Worker;
using static Homework_11_ConsUI.employeBin.Intern;
using Homework_11_ConsUI.structBin;
namespace Homework_11_wpfUI.masterForms
{
    /// <summary>
    /// Логика взаимодействия для MasterOfManagerCreation.xaml
    /// </summary>
    public partial class MasterOfManagerCreation : Window
    {
        public Window w;
        public MasterOfManagerCreation()
        {
            InitializeComponent();
            if (temporaryWorkPlace.GetType() == typeof(Office))
            {
                createDepartmentBtn.Visibility = Visibility.Hidden;
            }
        }

        private bool workerCreation = false;
        private bool internCreation = false;
        private bool officeCreation = false;
        private bool departmentCreation = false;

        private void CreateWorkerCycle()
        {
            string name = "";
            if (workerCreation)
            { name = $"worker_{workersCount}"; }
            else if (internCreation)
            { name = $"intern_{internsCount}"; }
           
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

            if (workerCreation)
            { temporaryWorkPlace.Hire(new Worker(salary, name, age)); }
            else if (internCreation)
            { temporaryWorkPlace.Hire(new Intern(salary, name, age)); }
        }

        private void gridVisible(string name, byte switcher = 1)
        {
            switch (switcher)
            {
                case 1:
                    ((Grid)w.FindName(name)).Visibility = Visibility.Visible;
                    break;
                case 0:
                    ((Grid)w.FindName(name)).Visibility = Visibility.Hidden;
                    break;
            }
        }

        private void borderVisible(string name, byte switcher = 1)
        {
            switch (switcher)
            {
                case 1:
                    ((Border)w.FindName(name)).Visibility = Visibility.Visible;
                    break;
                case 0:
                    ((Border)w.FindName(name)).Visibility = Visibility.Hidden;
                    break;
            }
        }
        private void createWorkerBtn_Click(object sender, RoutedEventArgs e)
        {
            w = GetWindow(this);
            workerCreation = true;

            gridVisible("gridWithButtons", 0);
            borderVisible("wizardBody", 1);
            borderVisible("instuctionsFrame", 1);

            thisEmployeWorkPlace.Text = temporaryWorkPlace.Name;
            workerNameHeader.Text = "Worker`s name:";
            workerSalaryHeader.Text = "Salary (for one hour):";
        }

        private void createInternBtn_Click(object sender, RoutedEventArgs e)
        {
            w = GetWindow(this);
            internCreation = true;

            gridVisible("gridWithButtons", 0);
            borderVisible("wizardBody", 1);
            borderVisible("instuctionsFrame", 1);

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
            if (workerCreation | internCreation)
            {
                CreateWorkerCycle();
                workerCreation = false;
                internCreation = false;
            }

            else if (officeCreation | departmentCreation)
            {
                officeCreation = false;
                departmentCreation = false;
            }

            Close();
        }
    }
}