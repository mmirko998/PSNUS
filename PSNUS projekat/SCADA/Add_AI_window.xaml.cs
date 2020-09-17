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
            new_AI = new Analog_input(txt_name.Text, txt_description.Text, Int32.Parse(txt_adress.Text), Int32.Parse(txt_scan_time.Text), txt_units.Text );
            
            MainWindow.Data_conc.io_ct.Analog_Inputs.Add(new_AI);

            this.Close();
        }
    }
}
