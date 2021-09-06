using System.Windows;

namespace Homework_10
{
    /// <summary>
    /// Логика взаимодействия для messageContentError.xaml
    /// </summary>
    public partial class messageContentError : Window
    {
        public messageContentError()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
