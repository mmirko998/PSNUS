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
using Data_concentrator;
using System.Data.Entity;

namespace SCADA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public DC_manager Data_conc { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            if(Data_conc == null)
            {
                Data_conc = new DC_manager();
            }

            Data_conc.Context_load();

            DataSrc_ComboBox.ItemsSource = new List<String>() { "Analog inputs", "Analog outputs", "Digital inputs", "Digital outputs", "Alarms" };
            DataSrc_ComboBox.SelectedItem = "Analog input";
            Data_grid.ItemsSource = Data_conc.io_ct.Analog_Inputs.Local;
        }

        private void DataSrc_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(DataSrc_ComboBox.SelectedItem)
            {
                case "Analog inputs":
                    {
                        Data_grid.ItemsSource = Data_conc.io_ct.Analog_Inputs.Local;
                        break;
                    }
                case "Analog outputs":
                    {
                        Data_grid.ItemsSource = Data_conc.io_ct.Analog_Outputs.Local;
                        break;
                    }
                case "Digital outputs":
                    {
                        Data_grid.ItemsSource = Data_conc.io_ct.Digital_Outputs.Local;
                        break;
                    }
                case "Digital inputs":
                    {
                        Data_grid.ItemsSource = Data_conc.io_ct.Digital_Inputs.Local;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
