using System.Windows;

namespace Homework_10
{
    /// <summary>
    /// Логика взаимодействия для fileNotChosenError.xaml
    /// </summary>
    public partial class fileNotChosenError : Window
    {
        public fileNotChosenError()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
