using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data_concentrator
{
    public class Analog_output : INotifyPropertyChanged
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

        private double initial_value;

        public double Initial_value
        {
            get { return initial_value; }
            set
            {
                initial_value = value;
                OnPropertyChanged("Initial_value");
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

        public Analog_output()
        {
            Name = "";
            Description = "";
            Adress = 0;
            Current_value = 0;
            Initial_value = 0;
            Units = "";
        }

        public Analog_output(string n, string d, int a, double iv, string u)
        {
            Name = n;
            Description = d;
            Adress = a;
            Current_value = iv;
            Initial_value = iv;
            Units = u;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return $"{Name}, {Description}\nAddress: {Adress}, Units: [{Units}]";
        }

    }
}
