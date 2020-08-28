using System;
using System.Collections.Generic;
using System.Text;

namespace Data_concentrator
{
    class Digital_input : Digital_IO
    {
        private int scan_time;

        public int Scan_time
        {
            get { return scan_time; }
            set { scan_time = value; }
        }

        Digital_input()
        {
            Name = "";
            Description = "";
            Adress = 0;
            Scan_time = 1;
        }

        Digital_input(string n, string d, int a, int st)
        {
            Name = n;
            Description = d;
            Adress = a;
            Scan_time = st;
        }
    }
}
