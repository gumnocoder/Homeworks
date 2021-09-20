using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;
using Homework_11_ConsUI.structBin;
using static Homework_11_ConsUI.structBin.OrgStructure;
using static Homework_11_wpfUI.MainWindow;

namespace Homework_11_wpfUI.userInterference
{
    /// <summary>
    /// Логика взаимодействия для SubstructureRename.xaml
    /// </summary>
    public partial class SubstructureRename : Window
    {
        public SubstructureRename()
        {
            InitializeComponent();
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ApplyBtn(object sender, RoutedEventArgs e)
        {
            if (newSubstructureName.Text != null)
            {
                temporaryWorkPlace.Rename(newSubstructureName.Text);
            }
            Close();
        }
    }
}
