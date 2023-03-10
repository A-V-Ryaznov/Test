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
    /// Логика взаимодействия для WinSaveTickets.xaml
    /// </summary>
    public partial class WinSaveTickets : Window
    {
        public WinSaveTickets()
        {
            InitializeComponent();
            List();
            tbxSearch.TextChanged += tbxSearch_TextChanged;
        }
        private string _currentInput = "";
        private string _currentSearch = "";
        private string _currentText = "";

        private int _selectionStart;
        private int _selectionLenght;
        private static readonly string[] SearchValues = { "Гурьба", "Шурова", "Степченко", "Сафонова", "Медведева", "Романов", "Каур" };

        public void List()
        {
            Entities.HospitalBaseEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

            var data = Entities.HospitalBaseEntities.GetContext();
            List<View.UC.PageTicket> items = new List<View.UC.PageTicket>();

            foreach (var appointment in data.Appointments.ToList())
            {
                lvTickets.Items.Add(new View.UC.PageTicket(appointment));
            }
        }
        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var input = tbxSearch.Text;
            if (input.Length > _currentInput.Length && input != _currentSearch)
            {
                _currentSearch = SearchValues.FirstOrDefault(p => p.Contains(input));
                if (_currentSearch != null)
                {
                    _currentText = _currentSearch;
                    _selectionStart = input.Length;
                    _selectionLenght = _currentSearch.Length - input.Length;

                    tbxSearch.Text = _currentText;
                    tbxSearch.Select(_selectionStart, _selectionLenght);
                }
            }
            _currentInput = input;
            Searching(input);
        }
        private void Searching(string Doctor)
        {
            var data = Entities.HospitalBaseEntities.GetContext();
            var search = from doctor in data.Appointments
                         where doctor.DoctorSchedule.Doctor.LastName.ToUpper().Contains(Doctor)
                         orderby doctor.DoctorSchedule.Doctor.LastName
                         select doctor;
            lvTickets.Items.Clear();
            foreach (Entities.Appointment doc in search)
            {
                lvTickets.Items.Add(new View.UC.PageTicket(doc));
            }

        }
        private void rbtnAsc_Click(object sender, RoutedEventArgs e)
        {
            var data = Entities.HospitalBaseEntities.GetContext();
            var search = from doctor in data.Appointments

                         orderby doctor.Id ascending
                         select doctor;
            lvTickets.Items.Clear();
            foreach (Entities.Appointment doc in search)
            {
                lvTickets.Items.Add(new View.UC.PageTicket(doc));
            }
        }

        private void rbtnDesc_Click(object sender, RoutedEventArgs e)
        {
            var data = Entities.HospitalBaseEntities.GetContext();
            var search = from doctor in data.Appointments

                         orderby doctor.Id descending
                         select doctor;
            lvTickets.Items.Clear();
            foreach (Entities.Appointment doc in search)
            {
                lvTickets.Items.Add(new View.UC.PageTicket(doc));
            }
        }
    }
}
