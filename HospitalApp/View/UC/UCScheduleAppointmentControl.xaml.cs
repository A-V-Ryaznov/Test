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
    /// Логика взаимодействия для UCScheduleAppointmentControl.xaml
    /// </summary>
    public partial class UCScheduleAppointmentControl : UserControl
    {
        public UCScheduleAppointmentControl()
        {
            InitializeComponent();
        }

        private void UserControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue is Entities.ScheduleAppointment currentAppointment)
            {
                btnAppointment.Content = $"{currentAppointment.StartTime.ToString(@"hh\:mm")} " + $"- {currentAppointment.EndTime.ToString(@"hh\:mm")}";

                switch (currentAppointment.AppointmentType)
                {
                    case Entities.AppointmentType.Free:
                        {
                            btnAppointment.IsEnabled = true;
                            btnAppointment.Foreground = new SolidColorBrush(Colors.White);
                            btnAppointment.Visibility = Visibility.Visible;
                        }
                        break;

                    case Entities.AppointmentType.Busy:
                        {
                            btnAppointment.IsEnabled = false;
                            btnAppointment.Foreground = new SolidColorBrush(Colors.Gray);
                            btnAppointment.Visibility = Visibility.Visible;
                        }
                        break;

                    case Entities.AppointmentType.DayOff:
                        {
                            btnAppointment.Visibility = Visibility.Hidden;
                        }
                        break;
                }
            }
        }
    }
}
