using System;
using System.Collections.Generic;
using System.Text;

namespace Data_concentrator
{
    public class Alarm
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Alarm_type type;

        public Alarm_type Type
        {
            get { return type; }
            set { type = value; }
        }

        private double alarm_value;

        public double Alarm_value
        {
            get { return alarm_value; }
            set { alarm_value = value; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }



        public Alarm()
        {
            Name = "";
            Type = Alarm_type.LOW;
        }

        public Alarm(string n, Alarm_type at)
        {
            Name = n;
            Type = at;
        }

        public bool Activate_alarm(double Tag_value)
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
