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
    /// Interaction logic for Add_DO_window.xaml
    /// </summary>
    public partial class Add_DO_window : Window
    {
        Digital_output new_DO;
        public Add_DO_window()
        {
            InitializeComponent();
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            if(validate_data())
            {
                new_DO = new Digital_output(txt_name.Text, txt_description.Text, int.Parse(txt_init_value.Text), int.Parse(txt_adress.Text));
                MainWindow.Data_conc.io_ct.Digital_Outputs.Add(new_DO);
                MainWindow.Data_conc.io_ct.SaveChanges();
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
            if (txt_name.Text.Length == 0) return false;

            if (txt_description.Text.Length == 0) return false;

            if (int.TryParse(txt_adress.Text, out n) == false)
            {
                return false;
            }

            if (int.TryParse(txt_init_value.Text, out n) == false)
            {
                return false;
            }
            else
            {
                if (n < 0 || n > 1) return false;
            }

            return true;
        }

    }
}
