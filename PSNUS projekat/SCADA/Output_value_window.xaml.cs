using Data_concentrator;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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
    /// Interaction logic for Output_value_window.xaml
    /// </summary>
    public partial class Output_value_window : Window
    {
        public Analog_output AO_edit;
        public Digital_output DO_edit;
        public Output_value_window(Analog_output Ao)
        {
            InitializeComponent();

            AO_edit = Ao;
            Output_info.Content = "Analog output: " + AO_edit.ToString();
        }

        public Output_value_window(Digital_output Do)
        {
            InitializeComponent();

            DO_edit = Do;
            Output_info.Content = "Digital output: " + DO_edit.ToString();
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            if(AO_edit != null)
            {   
                if(AO_validate())
                {
                    AO_edit.Current_value = double.Parse(txt_value.Text);
                    MainWindow.Data_conc.io_ct.Analog_Outputs.AddOrUpdate(AO_edit);
                    MainWindow.Data_conc.io_ct.SaveChanges();
                    this.Close();
                }
            }
            else if(DO_edit != null)
            {
                if(DO_validate())
                {
                    DO_edit.Current_value = int.Parse(txt_value.Text);
                    MainWindow.Data_conc.io_ct.Digital_Outputs.AddOrUpdate(DO_edit);
                    MainWindow.Data_conc.io_ct.SaveChanges();
                    this.Close();
                }
            }
        }

        private bool AO_validate()
        {
            double k = 0;
            if (double.TryParse(txt_value.Text, out k))
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        private bool DO_validate()
        {
            int n;
            if (int.TryParse(txt_value.Text, out n))
            {
                if (n > -1 && n < 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
