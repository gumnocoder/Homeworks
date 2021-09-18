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
                    structContent.ItemsSource = company.WorkPlaces;
                    //a.HireBoss(new DepartmentBoss());
                    //Debug.WriteLine(structContent.SelectedItem.Boss);
                }
                else if(a is Office)
                {
                    a.HireBoss(new OfficeManager(a));
                    foreach (var i in company.WorkPlaces) Debug.WriteLine(i.Boss);
                    structContent.ItemsSource = company.WorkPlaces;
                }
            }
            
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

        private void openSubStructDep_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(isCompanyCreated);
            if (isCompanyCreated)
            {
                if (structContent.SelectedItem != null)
                {
                    WorkPlace wp = structContent.SelectedItem as WorkPlace;
                    wp.OpenDep();
                }
                else
                {
                    company.OpenDep();
                    structContent.ItemsSource = company.WorkPlaces;
                    Debug.WriteLine(allWorkPlaces.Count);
                    foreach (WorkPlace wop in company.WorkPlaces)
                        Debug.WriteLine(wop.Name);
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
                else
                {
                    company.Open();
                    structContent.ItemsSource = company.WorkPlaces;
                    Debug.WriteLine(allWorkPlaces.Count);
                    foreach (WorkPlace wop in company.WorkPlaces)
                        Debug.WriteLine(wop.Name);
                }
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var xmlSaved = new xmlSaved();
            CompanyToXml(company);
            xmlSaved.ShowDialog();
        }
    }
}
