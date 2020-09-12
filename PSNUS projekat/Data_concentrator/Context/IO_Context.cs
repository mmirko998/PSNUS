using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Data_concentrator.Context
{
    public class IO_Context : DbContext
    {
        public DbSet<Analog_input> Analog_Inputs { get; set; }
        public DbSet<Analog_output> Analog_Outputs { get; set; }
        public DbSet<Digital_input> Digital_Inputs { get; set; }
        public DbSet<Digital_output> Digital_Outputs { get; set; }
    }
}
