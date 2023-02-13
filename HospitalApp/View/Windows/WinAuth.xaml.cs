using System;
using System.Collections.Generic;
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

namespace HospitalApp.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для WinAuth.xaml
    /// </summary>
    public partial class WinAuth : Window
    {
        public WinAuth()
        {
            InitializeComponent();
        }

        private void VisiblePass_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            tbxPassword.Text = pbPassword.Password;
            pbPassword.Visibility = Visibility.Collapsed;
            tbxPassword.Visibility = Visibility.Visible;
        }

        private void VisiblePass_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            tbxPassword.Visibility = Visibility.Collapsed;
            pbPassword.Visibility = Visibility.Visible;
        }

        private void btnSign_Click(object sender, RoutedEventArgs e)
        {
            if (Entities.ClassAuthorization.SignIn(tbxLogin.Text, pbPassword.Password))
            {
                Close();
            }
            else
            {
                pbPassword.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
