using System;
using System.Collections.Generic;
using System.Text;

namespace Data_concentrator
{
    public class Analog_input : Digital_input
    {
        private List<Alarm> alarms;

        public List<Alarm> Alarms
        {
            get { return alarms; }
            set 
            { 
                alarms = value;
                OnPropertyChanged("AI_Alarms");
            }
        }


        private string units;

        public string Units
        {
            get { return units; }
            set 
            { 
                units = value;
                OnPropertyChanged("AI_Units");
            }
        }

        public Analog_input()
        {
            Name = "";
            Description = "";
            Adress = 0;
            Current_value = 0;
            Scan_time = 1;
            Alarms = new List<Alarm>();
            Units = "";
        }

        public Analog_input(string n, string d, int a, int st, string u)
        {
            Name = n;
            Description = d;
            Adress = a;
            Current_value = 0;
            Scan_time = st;
            Alarms = new List<Alarm>();
            Units = u;
        }

    }
}
