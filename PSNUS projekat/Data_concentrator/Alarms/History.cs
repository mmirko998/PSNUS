using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_concentrator.Alarms
{
    public class History : INotifyPropertyChanged
    {
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


        private int id;
        [Key]
        public int Id 
        {
            get { return id; }
            set 
            {
                id = value;
                OnPropertyChanged("ID");
            } 
        }
        public History()
        {
            Message = "";
            id = 0;
        }

        public History(string m)
        {
            Message = m;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
