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

namespace DatePicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        DateTime date = DateTime.Now;
        public MainWindow()
        {
            InitializeComponent();
            timeo.Text = date.ToString("hh:mm tt");
            timeo.IsInactiveSelectionHighlightEnabled = true;
        }
        private void upClick(object sender, RoutedEventArgs e)
        {
            if (timeo.SelectionLength == 2 && timeo.SelectionStart < 2)
            {
                timeo.Text = date.AddMinutes(60).ToString("hh:mm tt");
                date = date.AddMinutes(60);
                timeo.CaretIndex = 0;
                timeo.SelectionLength = 2;
            }
            if (timeo.SelectionLength == 2 && (timeo.SelectionStart > 2 && timeo.SelectionStart < 4))
            {
                timeo.Text = date.AddMinutes(1).ToString("hh:mm tt");
                date = date.AddMinutes(1);
                timeo.CaretIndex = 3;
                timeo.SelectionLength = 2;
            }
            if (timeo.SelectedText == "AM" || timeo.SelectedText == "PM")
            {
                
                timeo.Text = date.AddHours(12.0).ToString("hh:mm tt");
                date = date.AddHours(12.0);
                timeo.CaretIndex = 6;
                timeo.SelectionLength = 2;
            }
        }

        private void downClick(object sender, RoutedEventArgs e)
        {
            if (timeo.SelectionLength == 2 && timeo.SelectionStart < 2)
            {
                timeo.Text = date.AddMinutes(-60).ToString("hh:mm tt");
                date = date.AddMinutes(-60);
                timeo.CaretIndex = 0;
                timeo.SelectionLength = 2;
            }
            if (timeo.SelectionLength == 2 && (timeo.SelectionStart > 2 && timeo.SelectionStart < 4)) {
                timeo.Text = date.AddMinutes(-1).ToString("hh:mm tt");
                date = date.AddMinutes(-1);
                timeo.CaretIndex = 3;
                timeo.SelectionLength = 2;
            }
            if (timeo.SelectedText == "AM" || timeo.SelectedText == "PM")
            {
                timeo.Text = date.AddHours(12.0).ToString("hh:mm tt");
                date = date.AddHours(12.0);
                timeo.CaretIndex = 6;
                timeo.SelectionLength = 2;
            }
        }

        private void select(object sender, RoutedEventArgs e)
        {
            if (cal.SelectedDate.HasValue)
            {
                appt.Text = "Your Appointment is on " + cal.SelectedDate.Value.ToLongDateString() + " at " + timeo.Text + " " + Math.Round((cal.SelectedDate.Value - date).TotalDays) + " days from today.";
            }
        }
    }
}
