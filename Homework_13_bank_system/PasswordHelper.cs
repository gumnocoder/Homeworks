using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Homework_13_bank_system
{
    class PasswordHelper
    {
        public static readonly
    DependencyProperty PasswordProperty =
    DependencyProperty.RegisterAttached("Password",
        typeof(string),
        typeof(PasswordHelper),
        new FrameworkPropertyMetadata(string.Empty, OnPasswordPropertyChanged));

        public static readonly
            DependencyProperty IsUpdatingProperty =
            DependencyProperty.RegisterAttached("IsUpdating",
                typeof(bool),
                typeof(PasswordHelper));

        public static readonly
            DependencyProperty AttachProperty =
            DependencyProperty.RegisterAttached("Attach",
                typeof(bool),
                typeof(PasswordHelper),
                new PropertyMetadata(false, Attach));

        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passFieldValue = d as PasswordBox;
            passFieldValue.PasswordChanged -= PasswordChanged;
            if (!(bool)GetIsUpdating(passFieldValue))
            {
                passFieldValue.Password = (e.NewValue).ToString();
            }
            passFieldValue.PasswordChanged += PasswordChanged;
        }

        public static bool GetIsUpdating(DependencyObject d)
        {
            return (bool)d.GetValue(IsUpdatingProperty);
        }

        public static void PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passFieldValue = sender as PasswordBox;
            SetIsUpdating(passFieldValue, true);
            SetPassword(passFieldValue, passFieldValue.Password);
            SetIsUpdating(passFieldValue, false);
        }

        public static void SetPassword(PasswordBox passwordBox, string password)
        {
            passwordBox.SetValue(PasswordProperty, password);
        }

        public static void SetIsUpdating(PasswordBox passwordBox, bool v)
        {
            passwordBox.SetValue(IsUpdatingProperty, v);
        }

        public static void Attach(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passFieldValue = d as PasswordBox;

            if (passFieldValue == null)
                return;

            if ((bool)e.OldValue)
            {
                passFieldValue.PasswordChanged -= PasswordChanged;
            }

            if ((bool)e.NewValue)
            {
                passFieldValue.PasswordChanged += PasswordChanged;
            }
        }

        public static void SetAttach(DependencyObject d, bool v)
        {
            d.SetValue(AttachProperty, v);
        }

        public static void GetAttach(DependencyObject d)
        {
            d.GetValue(AttachProperty);
        }
    }
}
