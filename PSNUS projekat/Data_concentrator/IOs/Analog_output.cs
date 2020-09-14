using System;
using System.Collections.Generic;
using System.Text;

namespace Data_concentrator
{
    public class Analog_output : Digital_output
    {
        private string units;

        public string Units
        {
            get { return units; }
            set 
            { 
                units = value;
                OnPropertyChanged("Units");
            }
        }

        public Analog_output()
        {
            Name = "";
            Description = "";
            Adress = 0;
            Current_value = 0;
            Initial_value = 0;
            Units = "";
        }

        public Analog_output(string n, string d, int a, double cv, int iv, string u)
        {
            Name = n;
            Description = d;
            Adress = a;
            Current_value = cv;
            Initial_value = iv;
            Units = u;
        }

    }
}
