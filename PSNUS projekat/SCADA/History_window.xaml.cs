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
    /// Interaction logic for History_window.xaml
    /// </summary>
    public partial class History_window : Window
    {
        public History_window(List<History> histories)
        {
            InitializeComponent();
            History_grid.ItemsSource = histories;
        }
    }
}
