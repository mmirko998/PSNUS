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
    }
}
