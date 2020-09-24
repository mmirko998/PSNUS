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

            if (Data_conc == null)
            {
                Data_conc = new DC_manager();
            }

            Data_conc.Context_load();
            Data_conc.PLC.PLC_start();

            Data_conc.Start_AI();
            Data_conc.Start_DI();

            
            Data_grid.ItemsSource = Data_conc.io_ct.Analog_Inputs.Local;

            DataSrc_ComboBox.ItemsSource = new List<String>() { "Analog inputs", "Analog outputs", "Digital inputs", "Digital outputs", "Alarms" };
            DataSrc_ComboBox.SelectedItem = "Analog inputs";

        }

        private void DataSrc_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Data_grid.IsReadOnly = true;

            switch (DataSrc_ComboBox.SelectedItem)
            {
                case "Analog inputs":
                    {
                        Add_btn.Content = "Add analog input";
                        Remove_btn.Content = "Remove analog input";

                        Data_grid.ItemsSource = Data_conc.io_ct.Analog_Inputs.Local;
                        Data_grid.Columns.Clear();
                        generate_cols(0);
                        break;
                    }
                case "Analog outputs":
                    {
                        Add_btn.Content = "Add analog output";
                        Remove_btn.Content = "Remove analog output";

                        Data_grid.ItemsSource = Data_conc.io_ct.Analog_Outputs.Local;
                        Data_grid.Columns.Clear();
                        generate_cols(1);
                        break;
                    }
                case "Digital outputs":
                    {
                        Add_btn.Content = "Add digital output";
                        Remove_btn.Content = "Remove digital output";

                        Data_grid.ItemsSource = Data_conc.io_ct.Digital_Outputs.Local;
                        Data_grid.Columns.Clear();
                        generate_cols(2);
                        break;
                    }
                case "Digital inputs":
                    {
                        Add_btn.Content = "Add digital input";
                        Remove_btn.Content = "Remove digital input";

                        Data_grid.ItemsSource = Data_conc.io_ct.Digital_Inputs.Local;
                        Data_grid.Columns.Clear();
                        generate_cols(3);
                        break;
                    }
                case "Alarms":
                    {
                        Add_btn.Content = "Add alarm";
                        Remove_btn.Content = "Remove alarm";

                        Data_grid.ItemsSource = Data_conc.alarm_ct.Alarms.Local;
                        Data_grid.Columns.Clear();
                        generate_alarm_cols();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void generate_cols(int io)
        {
            DataGridTextColumn colN = new DataGridTextColumn();
            DataGridTextColumn colD = new DataGridTextColumn();
            DataGridTextColumn colA = new DataGridTextColumn();
            DataGridTextColumn colCV = new DataGridTextColumn();

            
            colN.Header = "Name";
            colN.Binding = new Binding("Name");
            Data_grid.Columns.Add(colN);
            colD.Header = "Description";
            colD.Binding = new Binding("Description");
            Data_grid.Columns.Add(colD);
            colA.Header = "Address";
            colA.Binding = new Binding("Adress");
            Data_grid.Columns.Add(colA);
            colCV.Header = "Current value";
            colCV.Binding = new Binding("Current_value");
            Data_grid.Columns.Add(colCV);


            switch (io)
            {
                case 0:
                    {
                        DataGridTemplateColumn colAl = new DataGridTemplateColumn();
                        DataGridTextColumn colU = new DataGridTextColumn();
                        DataGridTextColumn colST = new DataGridTextColumn();

                        colU.Header = "Units";
                        colU.Binding = new Binding("Units");
                        Data_grid.Columns.Add(colU);
                        colST.Header = "Scan time";
                        colST.Binding = new Binding("Scan_time");
                        Data_grid.Columns.Add(colST);

                        colAl.Header = "Alarms";
                        Data_grid.Columns.Add(colAl);

                        break;
                    }
                case 1:
                    {
                        DataGridTextColumn colU = new DataGridTextColumn();
                        colU.Header = "Units";
                        colU.Binding = new Binding("Units");
                        Data_grid.Columns.Add(colU);

                        Data_grid.IsReadOnly = false;

                        break;
                    }
                case 2:
                    {
                        Data_grid.IsReadOnly = false;
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

        private void generate_alarm_cols()
        {
            DataGridTextColumn colN = new DataGridTextColumn();
            DataGridTextColumn colT = new DataGridTextColumn();
            DataGridTextColumn colV = new DataGridTextColumn();
            DataGridTextColumn colM = new DataGridTextColumn();

            colN.Header = "Name";
            colN.Binding = new Binding("Name");
            Data_grid.Columns.Add(colN);
            colT.Header = "Alarm type";
            colT.Binding = new Binding("Alarm_type");
            Data_grid.Columns.Add(colT);
            colV.Header = "Value";
            colV.Binding = new Binding("Alarm_value");
            Data_grid.Columns.Add(colV);
            colM.Header = "Message";
            colM.Binding = new Binding("Message");
            Data_grid.Columns.Add(colM);
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
                        Add_AO_window add_AO = new Add_AO_window();
                        add_AO.ShowDialog();
                        break;
                    }
                case "Digital outputs":
                    {
                        Add_DO_window add_DO = new Add_DO_window();
                        add_DO.ShowDialog();
                        break;
                    }
                case "Digital inputs":
                    {
                        Add_DI_window add_DI = new Add_DI_window();
                        add_DI.ShowDialog();
                        break;
                    }
                case "Alarms":
                    {
                        Add_alarm_window Add_alarm = new Add_alarm_window();
                        Add_alarm.ShowDialog();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void Remove_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Data_grid.SelectedItem != null)
            {
                Analog_input AI_remove;
                Analog_output AO_remove;
                Digital_input DI_remove;
                Digital_output DO_remove;
                Alarm Alarm_remove;

                switch (DataSrc_ComboBox.SelectedItem)
                {
                    case "Analog inputs":
                        {
                            AI_remove = Data_grid.SelectedItem as Analog_input;
                            Remove_tag_window Remove_tag = new Remove_tag_window(AI_remove);

                            Remove_tag.ShowDialog();

                            Data_grid.ItemsSource = Data_conc.io_ct.Analog_Inputs.Local;
                            break;
                        }
                    case "Analog outputs":
                        {
                            AO_remove = Data_grid.SelectedItem as Analog_output;
                            Remove_tag_window Remove_tag = new Remove_tag_window(AO_remove);

                            Remove_tag.ShowDialog();

                            Data_grid.ItemsSource = Data_conc.io_ct.Analog_Outputs.Local;
                            break;
                        }
                    case "Digital inputs":
                        {
                            DI_remove = Data_grid.SelectedItem as Digital_input;
                            Remove_tag_window Remove_tag = new Remove_tag_window(DI_remove);

                            Remove_tag.ShowDialog();

                            Data_grid.ItemsSource = Data_conc.io_ct.Digital_Inputs.Local;
                            break;
                        }
                    case "Digital outputs":
                        {
                            DO_remove = Data_grid.SelectedItem as Digital_output;
                            Remove_tag_window Remove_tag = new Remove_tag_window(DO_remove);

                            Remove_tag.ShowDialog();

                            Data_grid.ItemsSource = Data_conc.io_ct.Digital_Outputs.Local;
                            break;
                        }
                    case "Alarms":
                        {
                            Alarm_remove = Data_grid.SelectedItem as Alarm;
                            Remove_tag_window Remove_tag = new Remove_tag_window(Alarm_remove);

                            Remove_tag.ShowDialog();

                            Data_grid.ItemsSource = Data_conc.alarm_ct.Alarms.Local;
                            break;
                        }
                }
                Data_grid.SelectedItem = null;
            }
        }
    }
}
