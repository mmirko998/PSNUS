﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Data_concentrator
{
    public class Digital_output : IO_tag
    {
        private int initial_value;

        public int Initial_value
        {
            get { return initial_value; }
            set { initial_value = value; }
        }

        public Digital_output()
        {
            Name = "";
            Description = "";
            Adress = 0;
            Current_value = 0;
            Initial_value = 0;
        }

        public Digital_output(string n, string d, int a, double cv, int iv)
        {
            Name = n;
            Description = d;
            Adress = a;
            Current_value = cv;
            Initial_value = iv;
        }

    }
}