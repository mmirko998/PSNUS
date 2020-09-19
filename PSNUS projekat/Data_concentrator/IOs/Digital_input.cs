using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data_concentrator
{
    public class Digital_input : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("Description");
            }
        }

        private int adress;

        public int Adress
        {
            get { return adress; }
            set
            {
                adress = value;
                OnPropertyChanged("Adress");
            }
        }

        private double current_value;

        public double Current_value
        {
            get { return current_value; }
            set
            {
                current_value = value;
                OnPropertyChanged("Current_value");
            }
        }

        private int num;
        [Key]
        public int Num
        {
            get { return num; }
            set
            {
                num = value;
                OnPropertyChanged("Num");
            }
        }


        private int scan_time;

        public int Scan_time
        {
            get { return scan_time; }
            set 
            { 
                scan_time = value;
                OnPropertyChanged("Scan_time");
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


        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
