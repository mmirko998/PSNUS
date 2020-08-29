using System;
using System.Collections.Generic;
using System.Text;

namespace Data_concentrator
{
    public class Analog_input : Digital_input
    {
        //polje za alarme dodati

        private string units;

        public string Units
        {
            get { return units; }
            set { units = value; }
        }

        public Analog_input()
        {
            Name = "";
            Description = "";
            Adress = 0;
            Scan_time = 1;
            //alarm init
            Units = "";
        }

        public Analog_input(string n, string d, int a, int st, string u)
        {
            Name = n;
            Description = d;
            Adress = a;
            Scan_time = st;
            //alarm = al;
            Units = u;
        }

    }
}
