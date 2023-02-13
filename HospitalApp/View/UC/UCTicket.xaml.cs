using HospitalApp.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HospitalApp.View.UC
{
    /// <summary>
    /// Логика взаимодействия для UCPageTicket.xaml
    /// </summary>
    public partial class UCPageTicket : UserControl
    {
        public UCPageTicket()
        {
            InitializeComponent();
        }
        public UCPageTicket(Appointment appointment)
        {
            InitializeComponent();
            _appointment = appointment;
            DataContext = _appointment;
            tblDate.Text = appointment.DoctorSchedule.Date.ToString("d MMMM yyyy");
            tblStart.Text = appointment.StartTime.ToString(@"hh\:mm");
            TbEnd.Text = appointment.EndTime.ToString(@"hh\:mm");
        }
        private static Appointment _appointment = new Appointment();

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.PageRangeSelection = PageRangeSelection.UserPages;
            printDialog.PrintVisual(spTicket, "");
        }
    }
}
