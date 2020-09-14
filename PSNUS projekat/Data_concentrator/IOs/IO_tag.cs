using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data_concentrator
{

    public class IO_tag : INotifyPropertyChanged
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

        public IO_tag() 
        {
            Name = "";
            Description = "";
            Adress = 0;
            Current_value = 0;
            Num = 0;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
