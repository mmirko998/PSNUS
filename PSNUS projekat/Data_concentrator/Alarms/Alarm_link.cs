using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_concentrator.Alarms
{
    public class Alarm_link
    {
        private int ai_id;
        
        public int AI_id
        {
            get { return ai_id; }
            set { ai_id = value; }
        }


        private int al_id;

        public int Alarm_id
        {
            get { return al_id; }
            set { al_id = value; }
        }

        private int id;
        [Key]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }




        public Alarm_link()
        {
            AI_id = 0;
            Alarm_id = 0;
        }

        public Alarm_link(int ai_id, int al_id)
        {
            AI_id = ai_id;
            Alarm_id = al_id;
        }

    }
}
