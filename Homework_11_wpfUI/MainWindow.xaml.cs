using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Homework_11_ConsUI.employeBin;
using Homework_11_ConsUI.structBin;
using Homework_11_wpfUI.messagesBin;
using Homework_11_wpfUI.userInterference;
using static System.Windows.SystemParameters;
using static Homework_11_ConsUI.functions.ExportToJson;
using static Homework_11_ConsUI.functions.ExportToXml;
using static Homework_11_ConsUI.structBin.OrgStructure;

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
            if (CheckS(sender, e))
            {
                /// отмечает отдел выбранным
                currentWorkPlace = structContent.SelectedItem as WorkPlace;
                /// выводит список сотрудников если они есть
                if (currentWorkPlace.Workers != null)
                {
                    workersContent.ItemsSource = currentWorkPlace.Workers;
                }
                /// открывает список подотделов
                structContent.ItemsSource = currentWorkPlace.WorkPlaces;
                structInfo.Text = currentWorkPlace.ToString();
                pathStructOrEmploye.Text = currentWorkPlace.Name;
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
            structInfo.Text = currentWorkPlace.ToString();
            temporaryWorkPlace = company;
            pathStructOrEmploye.Text = temporaryWorkPlace.Name;
        }

        /// <summary>
        /// назначает выбранного работника при клике в листь вью 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workersContent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CheckW(sender, e))
            {
                temporaryEmploye = workersContent.SelectedItem as Employe;
                RefreshWorkersInfo();
            }
        }

        /// <summary>
        /// назначает выбранную структуру при клике по ней в лист вью 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void structContent_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            if (CheckS(sender, e))
            {
                temporaryWorkPlace = structContent.SelectedItem as WorkPlace;
                RefreshStructInfo();
            }
        }

        /// <summary>
        /// проверяет выбрана ли структура в лист вью 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool CheckS(object sender, RoutedEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                pathStructOrEmploye.Text = (structContent.SelectedItem as WorkPlace).Name;
                return true;
            }
            else return false;
        }

        /// <summary>
        /// проверяет выбран ли работник в лист вью 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool CheckW(object sender, RoutedEventArgs e)
        {
            if (workersContent.SelectedItem != null)
            { return true; }
            else return false;
        }

        #endregion

        #region РАБОТА С КОНТЕНТОМ

        #region Работа с компанией

        /// <summary>
        /// компания
        /// </summary>
        Company company;

        /// <summary>
        /// создана ли компания
        /// </summary>
        bool isCompanyCreated = false;

        /// <summary>
        /// текущее рабочее место
        /// </summary>
        WorkPlace currentWorkPlace;


        /// <summary>
        /// создать компанию
        /// </summary>
        void CreateCompany()
        {
            company = new();
            HireCompanyBoss();
            currentWorkPlace = company;
            temporaryWorkPlace = company;
            isCompanyCreated = true;
            structInfo.Text = currentWorkPlace.ToString();
            pathStructOrEmploye.Text = temporaryWorkPlace.Name;
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
                RefreshStructInfo();
                Refresh();
            }
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
                RefreshStructInfo();
                Refresh();
            }
        }

        /// <summary>
        /// нанимает работника непосредственно в компанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hireCompanyWorker_Click(object sender, RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                company.Hire(new Worker());
                RefreshStructInfo();
            }
        }

        /// <summary>
        /// нанимает интерна непосредственно в компанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hireCompanyIntern_Click(object sender, RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                company.Hire(new Intern());
                RefreshStructInfo();
            }
        }

        /// <summary>
        /// Переименовывает директора
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void directorRename_Click(object sender, RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                temporaryWorkPlace = company;
                RenameBoss_Click(sender, e);
            }
        }

        /// <summary>
        /// переименовывает компанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renameCompany_Click(object sender, RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                temporaryWorkPlace = company;
                RenameStruct(sender, e);
                pathStructOrEmploye.Text = company.Name;
            }
        }

        /// <summary>
        /// срздает тестовую структуру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutoFillingCompanyStructBtn(object sender, RoutedEventArgs e)
        {
            CreateCompany();
            temporaryWorkPlace = company;
            currentWorkPlace = company;
            pathStructOrEmploye.Text = temporaryWorkPlace.Name;
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
            RefreshStructInfo();
            Refresh();
        }

        #endregion

        #region Работа с подструктурами

        public static WorkPlace temporaryWorkPlace;
        public static Employe temporaryEmploye;
        public static int thisEmployeSalary;
        public static string temporaryBossName;
        public static string temporaryStructName;

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
                if (CheckS(sender, e))
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
            if (CheckS(sender, e))
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
                RefreshBossesSalary();
                RefreshStructInfo();
                Refresh();
            }
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
            if (CheckS(sender, e))
            {
                (structContent.SelectedItem as WorkPlace).Hire(
                    new Worker());
                RefreshStructInfo();
            }
            else
            {
                currentWorkPlace.Hire(new Worker());
                RefreshStructInfo();
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
            if (CheckS(sender, e))
            {
                (structContent.SelectedItem as WorkPlace).Hire(
                    new Intern());
                RefreshStructInfo();
            }
            else
            {
                currentWorkPlace.Hire(new Intern());
                RefreshStructInfo();
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
            if (CheckS(sender, e))
            {
                currentWorkPlace.Close(structContent.SelectedItem as WorkPlace);
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


        /// <summary>
        /// Переименовывает структуру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameStruct(
            object sender,
            RoutedEventArgs e)
        {
            if (temporaryWorkPlace != null)
            {
                var wpr = new SubstructureRename();
                wpr.ShowDialog();
                temporaryWorkPlace.Name = temporaryStructName;
                RefreshStructInfo();
                Refresh();
                pathStructOrEmploye.Text = temporaryStructName;
            }
        }

        /// <summary>
        /// переименовывает работника
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renameEmploye_Click(object sender, RoutedEventArgs e)
        {
            if (CheckW(sender, e))
            {
                var emplRen = new EmployeRename();
                emplRen.ShowDialog();
                workersContent.SelectedItem = temporaryEmploye;
                RefreshWorkersInfo();
                Refresh();
            }
        }

        /// <summary>
        /// назначает зп работнику
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetSalary_Click(object sender, RoutedEventArgs e)
        {
            if (CheckW(sender, e))
            {
                var emplSet = new EmployeSetSalary();
                emplSet.ShowDialog();
                (workersContent.SelectedItem as Employe).Salary = thisEmployeSalary;
                RefreshWorkersInfo();
                Refresh();
            }
        }

        /// <summary>
        /// увольняет управляющего
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SackBoss_Click(object sender, RoutedEventArgs e)
        {
            if (CheckS(sender, e))
            {
                (structContent.SelectedItem as WorkPlace).SackBoss();
                RefreshStructInfo();
            }
        }

        /// <summary>
        /// переименовывает управляющего
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RenameBoss_Click(object sender, RoutedEventArgs e)
        {
            if (temporaryWorkPlace.Boss != null)
            {
                var w = new ManagerRename();
                w.ShowDialog();
                temporaryWorkPlace.RenameBoss(temporaryBossName);
                pathStructOrEmploye.Text = temporaryWorkPlace.Boss;
                RefreshStructInfo();
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

        /// <summary>
        /// обновляет инфо о структуре в текст блоке 1
        /// </summary>
        void RefreshStructInfo()
        {
            structInfo.Text = temporaryWorkPlace.ToString();
        }

        /// <summary>
        /// обновляет информацию о работнике в текст блоке 2
        /// </summary>
        void RefreshWorkersInfo()
        {
            workersInfo.Text = temporaryEmploye.ToString();
        }

        #endregion

        #region СОРТИРОВКА

        /// <summary>
        /// проверка условий для сортировки
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private bool checkForSorting(int code = 1)
        {

            if (isCompanyCreated)
            {
                switch (code)
                {
                    case 1:
                        if (structContent.ItemsSource != null) 
                            return true;
                        break;
                    case 0:
                        if (workersContent.ItemsSource != null) 
                            return true;
                        break;
                }
            }
            return false;
        }

        /// <summary>
        /// коллекция которую будем сортировать
        /// </summary>
        private CollectionView view;

        /// <summary>
        /// меняем источник для сортировки
        /// </summary>
        /// <param name="code"></param>
        private void SetList(int code = 1)
        {
            if (code == 0)
                view = (CollectionView)CollectionViewSource.GetDefaultView(workersContent.ItemsSource);
            else
                view = (CollectionView)CollectionViewSource.GetDefaultView(structContent.ItemsSource);
        }

        /// <summary>
        /// сортировка отделов по количеству подотделов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void structsSubstructs_MouseDown(object sender, MouseButtonEventArgs e)
        { if (checkForSorting()) { SetList(); SortListView(sender, e, "WorkPlaces.Count"); } }

        /// <summary>
        /// сортировка по количеству работников
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void structsWorkers_MouseDown(object sender, MouseButtonEventArgs e)
        { if (checkForSorting()) { SetList(); SortListView(sender, e, "Workers.Count"); } }

        /// <summary>
        /// сортировка по зп босса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void structsBossSalary_MouseDown(object sender, MouseButtonEventArgs e)
        { if (checkForSorting()) { SetList(); SortListView(sender, e, "BossSalary"); } }

        /// <summary>
        /// сортировка по названию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void structsName_MouseDown(object sender, MouseButtonEventArgs e)
        { if (checkForSorting()) { SetList(); SortListView(sender, e, "Name"); } }

        /// <summary>
        /// сортировка по имени босса
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stuctsBoss_MouseDown(object sender, MouseButtonEventArgs e)
        { if (checkForSorting()) { SetList(); SortListView(sender, e, "Boss"); } }

        /// <summary>
        /// задаёт направление сортировки
        /// </summary>
        private bool directionChanged = false;

        /// <summary>
        /// непосредственно сортировка listView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="field"></param>
        private void SortListView(object sender, MouseButtonEventArgs e, string field)
        {
            if (!directionChanged)
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(field, ListSortDirection.Ascending));
                directionChanged = true;
            }
            else
            {
                view.SortDescriptions.Clear();
                view.SortDescriptions.Add(new SortDescription(field, ListSortDirection.Descending));
                directionChanged = false;
            }
        }

        /// <summary>
        /// сортировка рабочих по имени
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workersName_MouseDown(object sender, MouseButtonEventArgs e)
        { if (checkForSorting(0)) { SetList(0); SortListView(sender, e, "Name"); } }

        /// <summary>
        /// сортировка по зп
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workersSalary_MouseDown(object sender, MouseButtonEventArgs e)
        { if (checkForSorting(0)) { SetList(0); SortListView(sender, e, "Salary"); } }

        /// <summary>
        /// сортировка по типу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workersType_MouseDown(object sender, MouseButtonEventArgs e)
        { if (checkForSorting(0)) { SetList(0); SortListView(sender, e, "Type"); } }

        /// <summary>
        /// сортировка по возрасту
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void workersAge_MouseDown(object sender, MouseButtonEventArgs e)
        { if (checkForSorting(0)) { SetList(0); SortListView(sender, e, "Age"); } }

        #endregion
    }
}