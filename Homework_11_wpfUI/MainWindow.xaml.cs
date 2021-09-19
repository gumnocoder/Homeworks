using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Homework_11_ConsUI.employeBin;
using Homework_11_ConsUI.structBin;
using Homework_11_wpfUI.messagesBin;
using Homework_11_wpfUI.userInterference;
using static System.Windows.SystemParameters;
using static Homework_11_ConsUI.functions.ExportToJson;
using static Homework_11_ConsUI.functions.ExportToXml;

namespace Homework_11_wpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region ОКНА

        public MainWindow()
        {
            InitializeComponent();
        }

        #region HOT KEYS

        private void OnKeyDown(
            object sender, 
            KeyEventArgs e)
        {
            switch (e.KeyboardDevice.Modifiers)
            {
                case ModifierKeys.Control:
                    switch (e.Key)
                    {
                        case Key.Q:
                            CreateCompanyBtn(sender, e);
                            break;
                        case Key.W:
                            CompanyDepartmentOpen(sender, e);
                            break;
                        case Key.E:
                            CompanyOfficeOpen(sender, e);
                            break;
                        case Key.X:
                            exitBtn_Click(sender, e);
                            break;
                    }
                    break;
                case ModifierKeys.Shift:
                    switch (e.Key)
                    {
                        case Key.A:
                            AutoFillingCompanyStructBtn(sender, e);
                            break;
                    }
                    break;
            }
        }

        private void OnListKeyDown(
            object sender, 
            KeyEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                switch (e.KeyboardDevice.Modifiers)
                {
                    case ModifierKeys.Control:
                        switch (e.Key)
                        {
                            case Key.H:
                                hireWorker_Click(sender, e);
                                break;
                            case Key.O:
                                openSubStructDep_Click(sender, e);
                                break;
                        }
                        break;

                    case ModifierKeys.Shift:
                        switch (e.Key)
                        {
                            case Key.H:
                                HireIntern_Click(sender, e);
                                break;
                            case Key.O:
                                openOffice_Click(sender, e);
                                break;
                        }
                        break;
                }
            }
        }

        #endregion

        /// <summary>
        /// Выход
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitBtn_Click(
            object sender, 
            RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// приложение работает на весь экран
        /// </summary>
        bool maximixedWindowFlag = false;

        /// <summary>
        /// развернуть приложение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maximizeBtn_MouseDown(
            object sender, 
            MouseButtonEventArgs e)
        {
            if (maximixedWindowFlag == false)
            {
                maximixedWindowFlag = true;
                Top = 0;
                Left = 0;
                Width = PrimaryScreenWidth;
                Height = PrimaryScreenHeight;
            }
            else
            {
                maximixedWindowFlag = false;
                Width = 800;
                Height = 450;
            }
        }

        /// <summary>
        /// свернуть в трей
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minimizeBtn_MouseDown(
            object sender, 
            MouseButtonEventArgs e)
        {
            Hide();
        }

        /// <summary>
        /// восстановить из трея
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskbarIcon_TrayLeftMouseDown(
            object sender, 
            RoutedEventArgs e)
        {
            Show();
        }

        /// <summary>
        /// при выборе строки с отделом выводит список сотрудников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void structContent_MouseDown(
            object sender, 
            MouseButtonEventArgs e)
        {
            var content = structContent.SelectedItem;
            if (content != null)
            {
                /// отмечает отдел выбранным
                currentWorkPlace = content as WorkPlace;
                /// выводит список сотрудников если они есть
                if (currentWorkPlace.Workers != null)
                {
                    workersContent.ItemsSource = currentWorkPlace.Workers;
                }
                /// открывает список подотделов
                structContent.ItemsSource = currentWorkPlace.WorkPlaces;
            }
        }

        /// <summary>
        /// вернуть в корень структуры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoCompanyRootBtn(
            object sender, 
            RoutedEventArgs e)
        {
            currentWorkPlace = company;
            structContent.ItemsSource = currentWorkPlace.WorkPlaces;
            workersContent.ItemsSource = currentWorkPlace.Workers;
        }

        #endregion

        #region РАБОТА С КОНТЕНТОМ

        #region Работа с компанией

        Company company;

        bool isCompanyCreated = false;

        WorkPlace currentWorkPlace;


        /// <summary>
        /// создать компанию
        /// </summary>
        void CreateCompany()
        {
            company = new();
            currentWorkPlace = company;
            isCompanyCreated = true;
        }


        /// <summary>
        /// создать компанию и нанять директора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateCompanyBtn(
            object sender, 
            RoutedEventArgs e)
        {
            if (!isCompanyCreated)
            {
                CreateCompany();
                HireCompanyBoss();
                var m = new companyCreated();
                m.ShowDialog();
            }
        }

        /// <summary>
        /// нанять диреткора
        /// </summary>
        void HireCompanyBoss()
        {
            company.HireBoss(new Director(company));
        }

        /// <summary>
        /// открыть департамент в корне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanyDepartmentOpen(
            object sender, 
            RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                currentWorkPlace.OpenDep();
            }
            Refresh();
        }

        /// <summary>
        /// открыть офис в корне
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CompanyOfficeOpen(
            object sender, 
            RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                currentWorkPlace.Open();
            }
            Refresh();
        }

        /// <summary>
        /// срздает тестовую структуру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoFillingCompanyStructBtn(object sender, RoutedEventArgs e)
        {
            CreateCompany();
            HireCompanyBoss();
            currentWorkPlace = company;
            for (int i = 0; i < 5; i++) { currentWorkPlace.Hire(new Worker()); }
            for (int i = 0; i < 10; i++) { currentWorkPlace.OpenDep(); }
            for (int i = 0; i < 5; i++) { currentWorkPlace.Open(); }
            foreach (WorkPlace wp in currentWorkPlace.WorkPlaces)
            {
                if (wp.GetType() == typeof(Department))
                {
                    wp.OpenDep();
                    wp.Open();
                    wp.Open();
                    foreach (WorkPlace wP in wp.WorkPlaces)
                    {
                        for (int i = 0; i < 10; i++) { wP.Hire(new Worker()); }
                        wP.Hire(new Intern());
                        wP.Hire(new Intern());
                        if (wP.GetType() == typeof(Department))
                        { wP.HireBoss(new DepartmentBoss(wP)); }
                        else { wP.HireBoss(new OfficeManager(wP)); }
                    }
                    for (int i = 0; i < 10; i++) { wp.Hire(new Worker()); }
                    wp.HireBoss(new DepartmentBoss(wp));
                }
                else if (wp.GetType() == typeof(Office))
                {
                    wp.Open();
                    wp.Open();
                    wp.HireBoss(new OfficeManager(wp));
                    for (int i = 0; i < 5; i++) { 
                        wp.Hire(new Intern()); 
                    }
                }
            }
            Refresh();
        }

        #endregion

        #region Работа с подструктурами

        public static WorkPlace temporaryWorkPlace;

        /// <summary>
        /// открывает под отделом департамент 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openSubStructDep_Click(
            object sender, 
            RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                if (structContent.SelectedItem != null)
                {
                    (structContent.SelectedItem as WorkPlace).OpenDep();
                }
            }
        }

        /// <summary>
        /// открывает под отделом офис
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openOffice_Click(
            object sender, 
            RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                if (structContent.SelectedItem != null)
                {
                    WorkPlace wp = structContent.SelectedItem as WorkPlace;
                    wp.Open();
                }
            }
        }

        /// <summary>
        /// нанимает босса в подотдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HireBossInDep(
            object sender, 
            RoutedEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                WorkPlace a = structContent.SelectedItem as WorkPlace;
                if (a is Department)
                {
                    ///департамент босса если департамент
                    a.HireBoss(new DepartmentBoss(a));
                }
                else if (a is Office)
                {
                    /// или офис менеджера если офис
                    a.HireBoss(new OfficeManager(a));
                }
            }
            Refresh();
        }

        /// <summary>
        /// нанимает работника в компанию или отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hireWorker_Click(
            object sender, 
            RoutedEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                (structContent.SelectedItem as WorkPlace).Hire(
                    new Worker());
            }
            else
            {
                currentWorkPlace.Hire(new Worker());
            }
        }

        /// <summary>
        /// нанимает интерна в компанию или отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HireIntern_Click(
            object sender, 
            RoutedEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                (structContent.SelectedItem as WorkPlace).Hire(
                    new Intern());
            }
            else
            {
                currentWorkPlace.Hire(new Intern());
            }
        }

        /// <summary>
        /// закрывает подотдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseSubstructBtn(
            object sender, 
            RoutedEventArgs e)
        {
            var content = structContent.SelectedItem;
            if (content != null)
            {
                currentWorkPlace.Close(content as WorkPlace);
            }
        }

        /// <summary>
        /// увольняет сотрудника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SackEmployeBtn(
            object sender, 
            RoutedEventArgs e)
        {
            var content = workersContent.SelectedItem;
            if (content != null)
            {
                currentWorkPlace.Sack(content as Employe);
            }
        }

        #endregion

        #endregion

        #region Вспомогательные методы

        /// <summary>
        /// сохраняет в xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCompanyToXmlBtn(
            object sender, 
            RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                var xmlSaved = new xmlSaved();
                CompanyToXml(company);
                xmlSaved.ShowDialog();
            }
        }

        /// <summary>
        /// сохраняет в json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveCompanyToJsonBtn(
            object sender, 
            RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                var jsonSav = new jsonSaved();
                CompanyToJson(company);
                jsonSav.ShowDialog();
            }
        }

        /// <summary>
        /// обновляет списки департаментов и сотрудников
        /// </summary>
        private void Refresh()
        {
            structContent.ItemsSource = currentWorkPlace.WorkPlaces;
            workersContent.ItemsSource = currentWorkPlace.Workers;
        }

        #endregion

        #region
        #endregion

        /// <summary>
        /// помечает выбранный департамент для дальнейших операция
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void structContent_MouseDown_1(
            object sender, 
            MouseButtonEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                temporaryWorkPlace = structContent.SelectedItem as WorkPlace;
            }
        }

        /// <summary>
        /// присваивает изменения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void structContent_SelectionChanged(
            object sender, 
            SelectionChangedEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                temporaryWorkPlace = structContent.SelectedItem as WorkPlace;
            }
        }

        /// <summary>
        /// показывает форму для изменения названия
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(
            object sender, 
            RoutedEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                var wpr = new WorkPlaceRename();
                wpr.ShowDialog();
                structContent.SelectedItem = temporaryWorkPlace;
                Refresh();
            }
        }
    }
}
