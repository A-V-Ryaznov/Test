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
    /// Логика взаимодействия для WinFreeTime.xaml
    /// </summary>
    public partial class WinFreeTime : Window
    {
        public WinFreeTime(Entities.Doctor selectedDoctor)
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
