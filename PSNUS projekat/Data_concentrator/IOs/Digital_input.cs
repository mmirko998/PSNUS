using System;
using System.Collections.Generic;
using System.Text;

namespace Data_concentrator
{
    public class Digital_input : IO_tag
    {
        private int scan_time;

        public int Scan_time
        {
            get { return scan_time; }
            set 
            { 
                scan_time = value;
                OnPropertyChanged("DI_Scan_time");
            }
        }

        public Digital_input()
        {
            Name = "";
            Description = "";
            Adress = 0;
            Current_value = 0;
            Scan_time = 1;
        }

        public Digital_input(string n, string d, int a, int st)
        {
            Name = n;
            Description = d;
            Adress = a;
            Current_value = 0;
            Scan_time = st;
        }
    }
}
