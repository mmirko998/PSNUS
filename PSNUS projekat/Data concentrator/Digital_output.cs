using System;
using System.Collections.Generic;
using System.Text;

namespace Data_concentrator
{
    class Digital_output : Digital_IO
    {
        private int initial_value;

        public int Initial_value
        {
            get { return initial_value; }
            set { initial_value = value; }
        }

        Digital_output()
        {
            Name = "";
            Description = "";
            Adress = 0;
            initial_value = 0;
        }

        Digital_output(string n, string d, int a, int iv)
        {
            Name = n;
            Description = d;
            Adress = a;
            initial_value = iv;
        }

    }
}
