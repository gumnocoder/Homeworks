using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using static System.Windows.SystemParameters;
using Homework_11_ConsUI.structBin;
using Homework_11_ConsUI.employeBin;
using static Homework_11_ConsUI.functions.ExportToXml;
using System.Diagnostics;
using Homework_11_wpfUI.messagesBin;
using static Homework_11_wpfUI.messagesBin.xmlSaved;

namespace Homework_11_wpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<WorkPlace> allWorkPlaces = new();

        bool isCompanyCreated = false;

        Company company;
        public MainWindow()
        {
            InitializeComponent();
            
            //structContent.ItemsSource = company.WorkPlaces;
        }

        private  void OnKeyDown(object sender, KeyEventArgs e)
        {
            var key = e.KeyboardDevice.Modifiers;
            var ctrl = ModifierKeys.Control;
            var shift = ModifierKeys.Shift;


            if (key == ctrl && e.Key == Key.Q)
            { MenuItem_Click(sender, e); }
            else if (key == ctrl && e.Key == Key.W)
            { CompanyDepartmentOpen(sender, e); }
            else if (key == ctrl && e.Key == Key.E)
            { CompanyOfficeOpen(sender, e); }
            else if (key == ctrl && e.Key == Key.X)
            { exitBtn_Click(sender, e); }
            else if (key == shift && e.Key == Key.A)
            { MenuItem_Click_2(sender, e); }
        }

        private void OnListKeyDown(object sender, KeyEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                //var key = e.KeyboardDevice.Modifiers;
                //var ctrl = ModifierKeys.Control;
                //var shift = ModifierKeys.Shift;

                switch (e.KeyboardDevice.Modifiers)
                {
                    case (ModifierKeys.Control):
                        switch (e.Key)
                        {
                            case (Key.H):
                                hireWorker_Click(sender, e);
                                break;
                            case (Key.O):
                                openSubStructDep_Click(sender, e);
                                break;
                        }
                        break;

                    case (ModifierKeys.Shift):
                        switch (e.Key)
                        {
                            case (Key.H):
                                HireIntern_Click(sender, e);
                                break;
                            case (Key.O):
                                openOffice_Click(sender, e);
                                break;
                        }
                        break;

                }

                //WorkPlace a = structContent.SelectedItem as WorkPlace;
                //if (key == ctrl && e.Key == Key.H)
                //{ hireWorker_Click(sender, e); }

                //else if (key == shift && e.Key == Key.H)
                //{ HireIntern_Click(sender, e); }

                //else if (key == ctrl && e.Key == Key.O)
                //{ openSubStructDep_Click(sender, e); }

                //else if (key == shift && e.Key == Key.O)
                //{ openOffice_Click(sender, e); }
            }
        }

        private void exitBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        bool flag = false;

        private void HireBossInDep(object sender, RoutedEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                WorkPlace a = structContent.SelectedItem as WorkPlace;
                if (a is Department)
                {
                    a.HireBoss(new DepartmentBoss(a));
                    foreach (var i in company.WorkPlaces) Debug.WriteLine(i.Boss);
                    //a.HireBoss(new DepartmentBoss());
                    //Debug.WriteLine(structContent.SelectedItem.Boss);
                }
                else if(a is Office)
                {
                    a.HireBoss(new OfficeManager(a));
                    foreach (var i in company.WorkPlaces) Debug.WriteLine(i.Boss);
                }
            }
            Refresh();
        }


        private void maximizeBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (flag == false)
            {
                flag = true;
                this.Top = 0;
                this.Left = 0;
                this.Width = PrimaryScreenWidth;
                this.Height = PrimaryScreenHeight;
            }
            else
            {
                flag = false;
                this.Width = 800;
                this.Height = 450;
            }
        }

        private void minimizeBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
        }

        private void TaskbarIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            Show();
        }

        void CreateCompany()
        {
            company = new();
            isCompanyCreated = true;
        }

        void HireCompanyBoss()
        {
            company.HireBoss(new Director(company));
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (!isCompanyCreated)
            {
                CreateCompany();
                Debug.WriteLine(company);
                HireCompanyBoss();
                Debug.WriteLine(company.Boss);
                var m = new companyCreated();
                m.ShowDialog();
                //FillCompanySubstructs();
            }
        }

        private void FillCompanySubstructs()
        {
            //if (isCompanyCreated)
            //{
            //    foreach (var e in company.WorkPlaces)
            //    {
            //        allWorkPlaces.Add(e);
            //    }
            //}
        }

        private void CompanyDepartmentOpen(object sender, RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                company.OpenDep();
                structContent.ItemsSource = company.WorkPlaces;
                Debug.WriteLine(allWorkPlaces.Count);
                foreach (WorkPlace wop in company.WorkPlaces)
                { Debug.WriteLine(wop.Name); }
            }
        }

        private void openSubStructDep_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(isCompanyCreated);
            if (isCompanyCreated)
            {
                if (structContent.SelectedItem != null)
                {
                    (structContent.SelectedItem as WorkPlace).OpenDep();
                }
            }
        }

        private void hireWorker_Click(object sender, RoutedEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                (structContent.SelectedItem as WorkPlace).Hire(new Worker());
            }
        }

        private void HireIntern_Click(object sender, RoutedEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                (structContent.SelectedItem as WorkPlace).Hire(new Intern());
            }
        }

        private void CompanyOfficeOpen(object sender, RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                company.Open();
                structContent.ItemsSource = company.WorkPlaces;
                Debug.WriteLine(allWorkPlaces.Count);
                foreach (WorkPlace wop in company.WorkPlaces)
                    Debug.WriteLine(wop.Name);
            }
        }
        private void openOffice_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(isCompanyCreated);
            if (isCompanyCreated)
            {
                if (structContent.SelectedItem != null)
                {
                    WorkPlace wp = structContent.SelectedItem as WorkPlace;
                    wp.AutoOpen();
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            if (isCompanyCreated)
            {
                var xmlSaved = new xmlSaved();
                CompanyToXml(company);
                xmlSaved.ShowDialog();
            }
        }
        private void Refresh()
        {
            structContent.ItemsSource = company.WorkPlaces;
        }
        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("started");
            CreateCompany();
            for (int i = 0; i < 10; i++) { company.OpenDep(); }
            for (int i = 0; i < 5; i++) { company.Open(); }
            foreach (WorkPlace wp in company.WorkPlaces)
            {
                if (wp.GetType() == typeof(Department))
                {
                    wp.OpenDep();
                    wp.Open(new Office());
                    wp.Open(new Office());
                    foreach (WorkPlace wP in wp.WorkPlaces)
                    {
                        for (int i = 0; i < 10; i++) { wP.Hire(new Worker()); }
                        wP.Hire(new Intern());
                        wP.Hire(new Intern());
                        //if (wP.GetType() == typeof(Department))
                        //{ wP.HireBoss(new DepartmentBoss(wP)); }
                        //else { wP.HireBoss(new OfficeManager(wP)); }
                    }
                    for (int i = 0; i < 10; i++) { wp.Hire(new Worker()); }
                    wp.HireBoss(new DepartmentBoss(wp));
                }
                else if(wp.GetType() == typeof(Office))
                {
                    wp.Open();
                    wp.Open();
                    wp.HireBoss(new OfficeManager(wp));
                    for (int i = 0; i < 5; i++) { wp.Hire(new Intern()); }
                }
            }
            Refresh();
        }
    }

}
