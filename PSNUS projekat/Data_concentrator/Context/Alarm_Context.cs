using Data_concentrator.Alarms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_concentrator.Context
{
    public class Alarm_Context : DbContext
    {
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<Alarm_link> Alarm_Links { get; set; }

        public DbSet<History> Histories { get; set; }
    }
}
