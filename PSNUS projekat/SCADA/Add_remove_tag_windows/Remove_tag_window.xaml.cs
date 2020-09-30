using Data_concentrator;
using Data_concentrator.Alarms;
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
    /// Interaction logic for Remove_tag_window.xaml
    /// </summary>
    public partial class Remove_tag_window : Window
    {
        Analog_input AI_remove;
        Analog_output AO_remove;
        Digital_input DI_remove;
        Digital_output DO_remove;
        Alarm Alarm_remove;

        public Remove_tag_window()
        {
            InitializeComponent();
        }

        public Remove_tag_window(Analog_input rem_AI)
        {
            InitializeComponent();
            AI_remove = rem_AI;
            this.Title = "Remove analog input";
        }

        public Remove_tag_window(Analog_output rem_AO)
        {
            InitializeComponent();
            AO_remove = rem_AO;
            this.Title = "Remove analog output";
        }

        public Remove_tag_window(Digital_input rem_DI)
        {
            InitializeComponent();
            DI_remove = rem_DI;
            this.Title = "Remove digital input";
        }

        public Remove_tag_window(Digital_output rem_DO)
        {
            InitializeComponent();
            DO_remove = rem_DO;
            this.Title = "Remove digital output";
        }

        public Remove_tag_window(Alarm rem_Al)
        {
            InitializeComponent();
            Alarm_remove = rem_Al;
            this.Title = "Remove alarm";
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            if (AI_remove != null)
            {
                MainWindow.Data_conc.io_ct.Analog_Inputs.Remove(AI_remove);

                MainWindow.Data_conc.AI_threads[AI_remove].Abort();
                MainWindow.Data_conc.AI_threads.Remove(AI_remove);

            }
            else if (AO_remove != null) 
            {
                MainWindow.Data_conc.io_ct.Analog_Outputs.Remove(AO_remove);
            }
            else if (DI_remove != null)
            {
                MainWindow.Data_conc.io_ct.Digital_Inputs.Remove(DI_remove);

                MainWindow.Data_conc.DI_threads[DI_remove].Abort();
                MainWindow.Data_conc.DI_threads.Remove(DI_remove);
            }
            else if (DO_remove != null)
            {
                MainWindow.Data_conc.io_ct.Digital_Outputs.Remove(DO_remove);
            }
            else if (Alarm_remove != null)
            {
                
                foreach(Alarm_link link in MainWindow.Data_conc.alarm_ct.Alarm_Links.ToList())
                {
                    
                    foreach(var ai in MainWindow.Data_conc.io_ct.Analog_Inputs.ToList())
                    {
                        if(ai.Num == link.AI_id && link.Alarm_id == Alarm_remove.Alarm_id)
                        {
                            ai.Alarms.Remove(Alarm_remove);
                            ai.Active_alarms.Remove(Alarm_remove);
                            MainWindow.Data_conc.alarm_ct.Alarm_Links.Remove(link);
                        }
                    }

                }
                MainWindow.Data_conc.alarm_ct.Alarms.Remove(Alarm_remove);
            }
            MainWindow.Data_conc.alarm_ct.SaveChanges();
            MainWindow.Data_conc.io_ct.SaveChanges();
            this.Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
