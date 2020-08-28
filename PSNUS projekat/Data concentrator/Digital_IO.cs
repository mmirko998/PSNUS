using System;

namespace Data_concentrator
{

    public class Digital_IO
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

        public Digital_IO() 
        {
            Name = "";
            Description = "";
            Adress = 0;
        }
    }
}
