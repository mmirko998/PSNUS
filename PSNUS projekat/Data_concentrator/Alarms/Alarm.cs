using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data_concentrator
{
    public class Alarm : INotifyPropertyChanged
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

        private Alarm_type type;

        public Alarm_type Type
        {
            get { return type; }
            set 
            { 
                type = value;
                OnPropertyChanged("Alarm_type");
            }
        }

        private double alarm_value;

        public double Alarm_value
        {
            get { return alarm_value; }
            set 
            { 
                alarm_value = value;
                OnPropertyChanged("Alarm_value");
            }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set 
            { 
                message = value;
                OnPropertyChanged("Message");
            }
        }

        private int alarm_id;

        

        [Key]
        public int Alarm_id
        {
            get { return alarm_id; }
            set 
            { 
                alarm_id = value;
                OnPropertyChanged("Num");
            }
        }



        public Alarm()
        {
            Name = "";
            Message = "";
            Alarm_value = 0;
            Type = Alarm_type.LOW;
            Alarm_id = 0;
        }

        public Alarm(string n, string m, double val, Alarm_type at)
        {
            Name = n;
            Message = m;
            Alarm_value = val;
            Type = at;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public bool Activate(double Tag_value)
        {
            switch (Type)
            {
                case Alarm_type.HIGH:
                    {
                        if (Tag_value > Alarm_value)
                        { return true; }
                        else
                        { return false; }
                    }
                case Alarm_type.LOW:
                    {
                        if (Tag_value < Alarm_value)
                        { return true; }
                        else
                        { return false; }
                    }
                default:
                    return false;
            }

        }
    }
}
