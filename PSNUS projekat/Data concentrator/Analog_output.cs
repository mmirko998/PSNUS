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
            set { units = value; }
        }

        public Analog_output()
        {
            Name = "";
            Description = "";
            Adress = 0;
            Initial_value = 0;
            Units = "";
        }

        public Analog_output(string n, string d, int a, int iv, string u)
        {
            Name = n;
            Description = d;
            Adress = a;
            Initial_value = iv;
            Units = u;
        }

    }
}
