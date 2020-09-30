using Data_concentrator;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
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
    /// Interaction logic for Add_AI_window.xaml
    /// </summary>
    public partial class Add_AI_window : Window
    {
        public Analog_input new_AI;
        public Add_AI_window()
        {
            InitializeComponent();
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if(validate_data())
            {
                new_AI = new Analog_input(txt_name.Text, txt_description.Text, int.Parse(txt_adress.Text), double.Parse(txt_scan_time.Text), txt_units.Text );
                MainWindow.Data_conc.io_ct.Analog_Inputs.Add(new_AI);
                MainWindow.Data_conc.Add_AI(new_AI);
                MainWindow.Data_conc.io_ct.SaveChanges();
                this.Close();
            }
            
        }

        private bool validate_data()
        {
            int n = 0;
            double k = 0;

            txt_name.Text.Trim();
            txt_description.Text.Trim();
            txt_scan_time.Text.Trim();
            txt_adress.Text.Trim();
            txt_units.Text.Trim();

            if (txt_name.Text.Length == 0)
            {
                MessageBox.Show("Name field can't be empty");
                return false;
            }

            if (txt_description.Text.Length == 0)
            {
                MessageBox.Show("Description field can't be empty");
                return false;
            }

            if (txt_scan_time.Text.Length == 0)
            {
                MessageBox.Show("Scan time field can't be empty");
                return false;
            }

            if (double.TryParse(txt_scan_time.Text, out k))
            {
                if (k <= 0)
                {
                    MessageBox.Show("Scan time must be positive number");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Scan time you entered is not a number");
                return false;
            }

            if (txt_adress.Text.Length == 0)
            {
                MessageBox.Show("Address field can't be empty");
                return false;
            }

            if (int.TryParse(txt_adress.Text,out n) == false)
            {
                MessageBox.Show("Adress value must be number");
                return false;
            }
            else
            {
                if(n<0 && n>3)
                {
                    MessageBox.Show("Address not in addres range(0-3)");
                    return false;
                }
            }

            if (txt_units.Text.Length == 0)
            {
                MessageBox.Show("Units field can't be empty");
                return false;
            }

            return true;
        }
    }
}
