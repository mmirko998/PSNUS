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
    /// Interaction logic for Add_AO_window.xaml
    /// </summary>
    public partial class Add_AO_window : Window
    {
        public Analog_output new_AO;
        private List<int> address_map;
        public Add_AO_window()
        {
            InitializeComponent();
            address_map = new List<int>();

            foreach (Analog_output ao in MainWindow.Data_conc.io_ct.Analog_Outputs.ToList())
            {
                address_map.Add(ao.Adress);
            }
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if(validate_data())
            {
                new_AO = new Analog_output(txt_name.Text, txt_description.Text, int.Parse(txt_adress.Text), double.Parse(txt_init_value.Text), txt_units.Text);
                MainWindow.Data_conc.io_ct.Analog_Outputs.Add(new_AO);
                MainWindow.Data_conc.io_ct.SaveChanges();

                MainWindow.Data_conc.PLC.Set_value(new_AO.Adress, new_AO.Initial_value);
                this.Close();
            }
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool validate_data()
        {
            int n = 0;
            double k = 0;
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

            if (txt_adress.Text.Length == 0)
            {
                MessageBox.Show("Address field can't be empty");
                return false;
            }

            if (int.TryParse(txt_adress.Text, out n) == false)
            {
                MessageBox.Show("Adress value must be number");
                return false;
            }
            else
            {
                if (n < 10 || n > 13)
                {
                    MessageBox.Show("Address not in address range(10-13)");
                    return false;
                }
                else
                {
                    if (address_map.Contains(n))
                    {
                        MessageBox.Show("Address already in use");
                        return false;
                    }
                }
            }

            if (double.TryParse(txt_init_value.Text, out k) == false)
            {
                MessageBox.Show("Initial value field empty or not a number");
                return false;
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
