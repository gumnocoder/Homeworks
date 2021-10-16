using System.Windows;

namespace Homework_13_bank_system
{
    public static class WindowCloser
    {
        public static readonly DependencyProperty dependencyProperty =
            DependencyProperty.RegisterAttached("DialogResult", typeof(bool), typeof(WindowCloser),
                new PropertyMetadata(DialogResultChanged));
        private static void DialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Window w = d as Window;
            if (w != null)
            {
                w.DialogResult = e.NewValue as bool?;
                if (w.DialogResult != null) w.Close();
            }
        }

        public static void DialogResult(Window w, bool? value)
        {
            w.SetValue(dependencyProperty, value);
        }
    }
}
