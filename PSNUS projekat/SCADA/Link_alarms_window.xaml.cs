using Data_concentrator;
using Data_concentrator.Alarms;
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
    /// Interaction logic for Link_alarms_window.xaml
    /// </summary>
    public partial class Link_alarms_window : Window
    {
        Analog_input Selected_AI;

        public List<Alarm> avalible_alarms { get; set; }
        public List<Alarm> linked_alarms { get; set; }
        public Link_alarms_window(Analog_input ai)
        {
            InitializeComponent();

            avalible_alarms = new List<Alarm>();
            linked_alarms = new List<Alarm>();

            Selected_AI = ai;


            generate_lists();
            

            Data_grid_all.ItemsSource = avalible_alarms;
            Data_grid_linked.ItemsSource = linked_alarms;
        }



        

        private void Link_alarm_Click(object sender, RoutedEventArgs e)
        {
            if (Data_grid_all.SelectedItem != null)
            {
                Alarm alarm_l = Data_grid_all.SelectedItem as Alarm;

                Selected_AI.Alarms.Add(alarm_l);
                Alarm_link new_link = new Alarm_link(Selected_AI.Num, alarm_l.Alarm_id);

                MainWindow.Data_conc.alarm_ct.Alarm_Links.Add(new_link);
                MainWindow.Data_conc.alarm_ct.SaveChanges();

                avalible_alarms.Remove(alarm_l);
                linked_alarms.Add(alarm_l);

                MainWindow.Data_conc.io_ct.Analog_Inputs.AddOrUpdate(Selected_AI);
                MainWindow.Data_conc.io_ct.SaveChanges();
            }

            generate_lists();

            Data_grid_all.ItemsSource = null;
            Data_grid_linked.ItemsSource = null;

            Data_grid_all.ItemsSource = avalible_alarms;
            Data_grid_linked.ItemsSource = linked_alarms;

            Data_grid_all.SelectedItem = null;
        }

        private void Unlink_alarm_Click(object sender, RoutedEventArgs e)
        {
            if (Data_grid_linked.SelectedItem != null)
            {
                Alarm alarm_l = Data_grid_linked.SelectedItem as Alarm;

                foreach(Alarm_link link in MainWindow.Data_conc.alarm_ct.Alarm_Links.ToList())
                {
                    if (Selected_AI.Num == link.AI_id && alarm_l.Alarm_id == link.Alarm_id)
                    {
                        MainWindow.Data_conc.alarm_ct.Alarm_Links.Remove(link);
                        MainWindow.Data_conc.alarm_ct.SaveChanges();
                        break;
                    }
                    else continue;
                }

                Selected_AI.Alarms.Remove(alarm_l);
                Selected_AI.Active_alarms.Remove(alarm_l);

                MainWindow.Data_conc.io_ct.Analog_Inputs.AddOrUpdate(Selected_AI);
                MainWindow.Data_conc.io_ct.SaveChanges();

                avalible_alarms.Add(alarm_l);
                linked_alarms.Remove(alarm_l);
            }

            generate_lists();

            Data_grid_all.ItemsSource = null;
            Data_grid_linked.ItemsSource = null;

            Data_grid_all.ItemsSource = avalible_alarms;
            Data_grid_linked.ItemsSource = linked_alarms;

            Data_grid_all.SelectedItem = null;

        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void generate_lists()
        {
            avalible_alarms.Clear();
            linked_alarms.Clear();

            foreach(Alarm_link link in MainWindow.Data_conc.alarm_ct.Alarm_Links.ToList())
            {
                if(link.AI_id == Selected_AI.Num)
                {
                    foreach(Alarm al in MainWindow.Data_conc.alarm_ct.Alarms.ToList())
                    {
                        if(al.Alarm_id == link.Alarm_id)
                        {
                            linked_alarms.Add(al);
                        }
                    }
                }
            }

            if (linked_alarms.Count == 0)
            {
                avalible_alarms = MainWindow.Data_conc.alarm_ct.Alarms.ToList();
            }
            else
            {
                foreach (Alarm al in MainWindow.Data_conc.alarm_ct.Alarms)
                {
                    foreach (Alarm al_l in linked_alarms)
                    {
                        if (al.Alarm_id == al_l.Alarm_id)
                        {
                            continue;
                        }
                        else
                        {
                            avalible_alarms.Add(al);
                        }
                    }
                }
            }
        }
    }
}
