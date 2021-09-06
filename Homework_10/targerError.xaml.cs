using System.Windows;

namespace Homework_10
{
    /// <summary>
    /// Логика взаимодействия для targerError.xaml
    /// </summary>
    public partial class targerError : Window
    {
        public targerError()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
