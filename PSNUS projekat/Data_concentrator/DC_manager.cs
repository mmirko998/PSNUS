using Data_concentrator.Context;
using PLCSimulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_concentrator
{
    public class DC_manager
    {
        public static IO_Context io_ct{ get; set; }
        public PLCSimulatorManager PLC { get; set; }

        public DC_manager()
        {
            io_ct = new IO_Context();
            PLC = new PLCSimulatorManager();
        }
    }
}
