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
    /// Interaction logic for Remove_tag_window.xaml
    /// </summary>
    public partial class Remove_tag_window : Window
    {
        Analog_input AI_remove;
        Analog_output AO_remove;
        Digital_input DI_remove;
        Digital_output DO_remove;

        public Remove_tag_window()
        {
            InitializeComponent();
        }

        public Remove_tag_window(Analog_input rem_AI)
        {
            InitializeComponent();
            AI_remove = rem_AI;
        }

        public Remove_tag_window(Analog_output rem_AO)
        {
            InitializeComponent();
            AO_remove = rem_AO;
        }

        public Remove_tag_window(Digital_input rem_DI)
        {
            InitializeComponent();
            DI_remove = rem_DI;
        }

        public Remove_tag_window(Digital_output rem_DO)
        {
            InitializeComponent();
            DO_remove = rem_DO;
        }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            if (AI_remove != null)
            {
                MainWindow.Data_conc.io_ct.Analog_Inputs.Remove(AI_remove);
            }
            else if (AO_remove != null) 
            {
                MainWindow.Data_conc.io_ct.Analog_Outputs.Remove(AO_remove);
            }
            else if (DI_remove != null)
            {
                MainWindow.Data_conc.io_ct.Digital_Inputs.Remove(DI_remove);
            }
            else if (DO_remove != null)
            {
                MainWindow.Data_conc.io_ct.Digital_Outputs.Remove(DO_remove);
            }
            MainWindow.Data_conc.io_ct.SaveChanges();
            this.Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
