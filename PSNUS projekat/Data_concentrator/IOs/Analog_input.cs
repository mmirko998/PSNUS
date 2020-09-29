using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data_concentrator
{
    public class Analog_input : INotifyPropertyChanged
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

      

        
        [NotMapped]
        public List<Alarm> Alarms { get; set; }
        [NotMapped]
        public List<Alarm> Active_alarms { get; set; }
        private double scan_time;

        public double Scan_time
        {
            get { return scan_time; }
            set
            {
                scan_time = value;
                OnPropertyChanged("Scan_time");
            }
        }

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

        public Analog_input()
        {
            Name = "";
            Description = "";
            Adress = 0;
            Current_value = 0;
            Scan_time = 1;
            Alarms = new List<Alarm>();
            Active_alarms = new List<Alarm>();
            Units = "";
        }

        public Analog_input(string n, string d, int a, double st, string u)
        {
            Name = n;
            Description = d;
            Adress = a;
            Current_value = 0;
            Scan_time = st;
            Alarms = new List<Alarm>();
            Active_alarms = new List<Alarm>();
            Units = u;
        }


        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
