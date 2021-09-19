﻿using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Homework_11_ConsUI.employeBin;
using Homework_11_ConsUI.structBin;
using Homework_11_wpfUI.messagesBin;
using static System.Windows.SystemParameters;
using static Homework_11_ConsUI.functions.ExportToXml;

namespace Homework_11_wpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<WorkPlace> allWorkPlaces = new();

        WorkPlace currentWorkPlace;

        bool isCompanyCreated = false;

        Company company;
        public MainWindow()
        {
            InitializeComponent();
        }

        private  void OnKeyDown(object sender, KeyEventArgs e)
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

        private void OnListKeyDown(object sender, KeyEventArgs e)
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
                Top = 0;
                Left = 0;
                Width = PrimaryScreenWidth;
                Height = PrimaryScreenHeight;
            }
            else
            {
                flag = false;
                Width = 800;
                Height = 450;
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
        private void CreateCompanyBtn(object sender, RoutedEventArgs e)
        {
            if (!isCompanyCreated)
            {
                CreateCompany();
                Debug.WriteLine(company);
                HireCompanyBoss();
                Debug.WriteLine(company.Boss);
                var m = new companyCreated();
                m.ShowDialog();
            }
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
            else
            {
                currentWorkPlace.Hire(new Worker());
            }
        }

        private void HireIntern_Click(object sender, RoutedEventArgs e)
        {
            if (structContent.SelectedItem != null)
            {
                (structContent.SelectedItem as WorkPlace).Hire(new Intern());
            }
            else
            {
                currentWorkPlace.Hire(new Intern());
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

        private void SaveCompanyToXmlBtn(object sender, RoutedEventArgs e)
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
            structContent.ItemsSource = currentWorkPlace.WorkPlaces;
        }
        private void AutoFillingCompanyStructBtn(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("started");
            CreateCompany();
            HireCompanyBoss();
            currentWorkPlace = company;
            for (int i = 0; i < 10; i++) { currentWorkPlace.OpenDep(); }
            for (int i = 0; i < 5; i++) { currentWorkPlace.Open(); }
            foreach (WorkPlace wp in currentWorkPlace.WorkPlaces)
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
                        if (wP.GetType() == typeof(Department))
                        { wP.HireBoss(new DepartmentBoss(wP)); }
                        else { wP.HireBoss(new OfficeManager(wP)); }
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

        private void structContent_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var content = structContent.SelectedItem;
            if (content != null)
            {
                currentWorkPlace = content as WorkPlace;
                if (currentWorkPlace.Workers != null)
                {
                    workersContent.ItemsSource = currentWorkPlace.Workers;
                }
                structContent.ItemsSource = currentWorkPlace.WorkPlaces;
            }
        }

        private void GoCompanyRootBtn(object sender, RoutedEventArgs e)
        {
            currentWorkPlace = company;
            structContent.ItemsSource = currentWorkPlace.WorkPlaces;
            workersContent.ItemsSource = currentWorkPlace.Workers;
        }

        private void CloseSubstructBtn(object sender, RoutedEventArgs e)
        {
            var content = structContent.SelectedItem;
            if (content != null)
            {
                currentWorkPlace.Close(content as WorkPlace);
            }
        }
    }
}