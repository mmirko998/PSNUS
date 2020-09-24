using Data_concentrator;
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

namespace SCADA
{
    /// <summary>
    /// Interaction logic for Add_alarm_window.xaml
    /// </summary>
    public partial class Add_alarm_window : Window
    {
        public Alarm new_alarm;
        public Add_alarm_window()
        {
            InitializeComponent();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (validate_data())
            {
                new_alarm = new Alarm();
                new_alarm.Name = txt_name.Text;
                new_alarm.Message = txt_msg.Text;
                new_alarm.Alarm_value = double.Parse(txt_value.Text);
                if (Radio_high.IsChecked == true)
                { new_alarm.Type = Alarm_type.HIGH; }
                else { new_alarm.Type = Alarm_type.LOW; }

                MainWindow.Data_conc.alarm_ct.Alarms.Add(new_alarm);
                MainWindow.Data_conc.alarm_ct.SaveChanges();

                this.Close();
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool validate_data()
        {
            double n = 0;
            if (txt_name.Text.Length == 0) return false;

            if (txt_msg.Text.Length == 0) return false;

            if (double.TryParse(txt_value.Text, out n) == false)
            {
                return false;
            }

            if ( (Radio_high.IsChecked == false) && (Radio_low.IsChecked == false))
            { return false; }

            return true;
        }
    }
}
