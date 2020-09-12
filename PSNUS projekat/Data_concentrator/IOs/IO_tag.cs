using System;

namespace Data_concentrator
{

    public class IO_tag
    {
        private string name; //ID

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int adress;

        public int Adress
        {
            get { return adress; }
            set { adress = value; }
        }

        private double current_value;

        public double Current_value
        {
            get { return current_value; }
            set { current_value = value; }
        }



        public IO_tag() 
        {
            Name = "";
            Description = "";
            Adress = 0;
            Current_value = 0;
        }
    }
}
