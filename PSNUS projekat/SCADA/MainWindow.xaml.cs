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
using System.Runtime.Remoting.Messaging;

namespace SCADA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public static DC_manager Data_conc { get; set; }
        public MainWindow()
        {
            InitializeComponent();

            DataSrc_ComboBox.ItemsSource = new List<String>() { "Analog inputs", "Analog outputs", "Digital inputs", "Digital outputs", "Alarms" };
            DataSrc_ComboBox.SelectedItem = "Analog input";

            if (Data_conc == null)
            {
                Data_conc = new DC_manager();
            }

            Data_conc.Context_load();

            
            Data_grid.ItemsSource = Data_conc.io_ct.Analog_Inputs.Local;
        }

        private void DataSrc_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(DataSrc_ComboBox.SelectedItem)
            {
                case "Analog inputs":
                    {
                        Add_btn.Content = "Add analog input";
                        Data_grid.ItemsSource = Data_conc.io_ct.Analog_Inputs.Local;
                        Data_grid.Columns.Clear();
                        generate_cols(0);
                        break;
                    }
                case "Analog outputs":
                    {
                        Add_btn.Content = "Add analog output";
                        Data_grid.ItemsSource = Data_conc.io_ct.Analog_Outputs.Local;
                        Data_grid.Columns.Clear();
                        generate_cols(1);
                        break;
                    }
                case "Digital outputs":
                    {
                        Add_btn.Content = "Add digital output";
                        Data_grid.ItemsSource = Data_conc.io_ct.Digital_Outputs.Local;
                        Data_grid.Columns.Clear();
                        generate_cols(2);
                        break;
                    }
                case "Digital inputs":
                    {
                        Add_btn.Content = "Add digital input";
                        Data_grid.ItemsSource = Data_conc.io_ct.Digital_Inputs.Local;
                        Data_grid.Columns.Clear();
                        generate_cols(3);
                        break;
                    }
                case "Alarms":
                    {
                        Add_btn.Content = "Add alarm";
                        Data_grid.Columns.Clear();
                        break;
                    }
                default:
                    {
                        Data_grid.ItemsSource = Data_conc.io_ct.Analog_Inputs.Local;
                        Data_grid.Columns.Clear();
                        generate_cols(0);
                        break;
                    }
            }
        }

        private void generate_cols(int io)
        {
            DataGridTextColumn colNum = new DataGridTextColumn();
            DataGridTextColumn colN = new DataGridTextColumn();
            DataGridTextColumn colD = new DataGridTextColumn();
            DataGridTextColumn colA = new DataGridTextColumn();
            DataGridTextColumn colCV = new DataGridTextColumn();

            colNum.Header = "#";
            colNum.Binding = new Binding("Num");
            Data_grid.Columns.Add(colNum);
            colN.Header = "Name";
            colN.Binding = new Binding("Name");
            Data_grid.Columns.Add(colN);
            colD.Header = "Description";
            colD.Binding = new Binding("Description");
            Data_grid.Columns.Add(colD);
            colA.Header = "Adress";
            colA.Binding = new Binding("Adress");
            Data_grid.Columns.Add(colA);
            colCV.Header = "Current value";
            colCV.Binding = new Binding("Current_value");
            Data_grid.Columns.Add(colCV);
            switch(io)
            {
                case 0:
                    {
                        DataGridTemplateColumn colAl = new DataGridTemplateColumn();
                        DataGridTextColumn colU = new DataGridTextColumn();
                        DataGridTextColumn colST = new DataGridTextColumn();
                        colAl.Header = "Alarms";
                        Data_grid.Columns.Add(colAl);
                        colU.Header = "Units";
                        colU.Binding = new Binding("AI_Units");
                        Data_grid.Columns.Add(colU);
                        
                        colST.Header = "Scan time";
                        colST.Binding = new Binding("AI_Scan_time");
                        Data_grid.Columns.Add(colST);
                        break;
                    }
                case 1:
                    {
                        DataGridTextColumn colU = new DataGridTextColumn();
                        colU.Header = "Units";
                        colU.Binding = new Binding("Units");
                        Data_grid.Columns.Add(colU);
                        break;
                    }
                case 2:
                    {
                        
                        break;
                    }
                case 3: 
                    {
                        DataGridTextColumn colST = new DataGridTextColumn();
                        colST.Header = "Scan time";
                        colST.Binding = new Binding("Scan_time");
                        Data_grid.Columns.Add(colST);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void Add_btn_Click(object sender, RoutedEventArgs e)
        {
            switch (DataSrc_ComboBox.SelectedItem)
            {
                case "Analog inputs":
                    {
                        Add_AI_window Add_AI = new Add_AI_window();
                        Add_AI.ShowDialog();
                        break;
                    }
                case "Analog outputs":
                    { 
                        break;
                    }
                case "Digital outputs":
                    {  
                        break;
                    }
                case "Digital inputs":
                    {
                        break;
                    }
                case "Alarms":
                    {
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
