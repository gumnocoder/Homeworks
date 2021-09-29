using System.Windows;
using System.Windows.Controls;
using Homework_11_ConsUI.employeBin;
using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.employeBin.Intern;
using static Homework_11_ConsUI.employeBin.Worker;
using static Homework_11_wpfUI.MainWindow;
using static Homework_11_ConsUI.structBin.Company;
using static Homework_11_ConsUI.structBin.Department;
namespace Homework_11_wpfUI.masterForms
{
    /// <summary>
    /// Логика взаимодействия для MasterOfManagerCreation.xaml
    /// </summary>
    public partial class MasterOfManagerCreation : Window
    {
        public Window w;

        /// <summary>
        /// запуск мастера в нужной конфигурации
        /// </summary>
        public MasterOfManagerCreation()
        {
            InitializeComponent();
            /// при запуске мастера для офиса будет 
            /// отсутствовать кнопка создания департамента
            if (temporaryWorkPlace.GetType() == typeof(Office))
            {
                createDepartmentBtn.Visibility = Visibility.Hidden;
                gridForCreatingDepartments.Visibility = Visibility.Hidden;
            }
        }

        private bool workerCreation = false;
        private bool internCreation = false;
        private bool officeCreation = false;
        private bool departmentCreation = false;

        /// <summary>
        /// создание работника по параметрам переданным в textbox`ах
        /// или по параметрам по умолчанию 
        /// </summary>
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

        /// <summary>
        /// скрывает или показывает именованные grid в xaml
        /// </summary>
        /// <param name="name"></param>
        /// <param name="switcher"></param>
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

        /// <summary>
        /// скрывает или показывает именованные Border в xaml
        /// </summary>
        /// <param name="name"></param>
        /// <param name="switcher"></param>
        private void borderVisible(
            string name, byte switcher = 1)
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

        /// <summary>
        /// преображает форму под выбранный тип сотрудника
        /// </summary>
        /// <param name="workerNameText"></param>
        /// <param name="workerSalaryText"></param>
        private void EMployeCreationFormSettings(
            string workerNameText, string workerSalaryText)
        {

            gridVisible("gridWithButtons", 0);
            borderVisible("wizardBody", 1);
            borderVisible("instuctionsFrame", 1);

            thisEmployeWorkPlace.Text = temporaryWorkPlace.Name;
            workerNameHeader.Text = workerNameText;
            workerSalaryHeader.Text = workerSalaryText;
        }
        
        /// <summary>
        /// запускает преобразование для worker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createWorkerBtn_Click(
            object sender, RoutedEventArgs e)
        {
            w = GetWindow(this);
            workerCreation = true;
            EMployeCreationFormSettings(
                "Worker`s name:", 
                "Salary (for one hour):"
                );
        }

        /// <summary>
        /// запускает преобразование под Intern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createInternBtn_Click(
            object sender, RoutedEventArgs e)
        {
            w = GetWindow(this);
            internCreation = true;

            gridVisible("gridWithButtons", 0);
            borderVisible("wizardBody", 1);
            borderVisible("instuctionsFrame", 1);

            workerNameHeader.Text = "Intern`s name:";
            workerSalaryHeader.Text = "Salary (for one month):";
        }

        private void CreateStructCycle()
        {
            string name = "";

            if (departmentCreation)
                name = $"department_{depsCount}";
            else if (officeCreation)
                name = $"office_{companyOffices}";

            if (newStructsName.Text != "")
            { name = newStructsName.Text; }


            if (departmentCreation)
                temporaryWorkPlace.Open(new Department(name));
            else if (officeCreation)
                temporaryWorkPlace.Open(new Office(name));

            var tmpwp = temporaryWorkPlace.WorkPlaces[^1];

            if (workersCountInput.Text != "")
            { HireWorkersByCount(workersCountInput.Text, tmpwp); }

            if (internsCountInput.Text != "")
            { HireInternsByCount(internsCountInput.Text, tmpwp); }

            if (officesCountInput.Text != "")
            { OpenOfficesByCount(officesCountInput.Text, tmpwp); }

            if (departmentsCountInput.Text != "")
            { OpenDepsByCount(departmentsCountInput.Text, tmpwp); }
        }

        private void HireWorkersByCount(string count, WorkPlace wp)
        {
            if (int.TryParse(count, out int tmp))
            {
                for (int i = 0; i < tmp; i++)
                { wp.Hire(new Worker()); }
            }
        }

        private void HireInternsByCount(string count, WorkPlace wp)
        {
            if (int.TryParse(count, out int tmp))
            {
                for (int i = 0; i < tmp; i++)
                { wp.Hire(new Intern()); }
            }
        }

        private void OpenDepsByCount(string count, WorkPlace wp)
        {
            if (int.TryParse(count, out int tmp))
            {
                for (int i = 0; i < tmp; i++)
                { wp.Open(new Department($"temp_department_{i}")); }
            }
        }

        private void OpenOfficesByCount(string count, WorkPlace wp)
        {
            if (int.TryParse(count, out int tmp))
            {
                for (int i = 0; i < tmp; i++)
                { wp.Open(new Office($"temp_office_{i}")); }
            }
        }

        /// <summary>
        /// запускает преобразование под оффис
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createOfficeBtn_Click(
            object sender, RoutedEventArgs e)
        {
            officeCreation = true;

        }

        WorkPlace SecondTemporallyWorkPlace = new Department();
        /// <summary>
        /// запускает преобразование под департамент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createDepartmentBtn_Click(
            object sender, RoutedEventArgs e)
        {
            departmentCreation = true;

        }

        /// <summary>
        /// отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelBtn_Click(
            object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// создать по параметрам или со значениями по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void createBtn_Click(
            object sender, RoutedEventArgs e)
        {
            if (workerCreation | internCreation)
            {
                CreateWorkerCycle();
                workerCreation = false;
                internCreation = false;
            }

            else if (officeCreation | departmentCreation)
            {
                CreateStructCycle();
                officeCreation = false;
                departmentCreation = false;
            }

            Close();
        }
    }
}