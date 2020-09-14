using Data_concentrator.Context;
using PLCSimulator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_concentrator
{
    public class DC_manager
    {
        public IO_Context io_ct{ get; set; }
        public PLCSimulatorManager PLC { get; set; }

        public DC_manager()
        {
            if (io_ct == null)
            {
                io_ct = new IO_Context();
            }
            PLC = new PLCSimulatorManager();
        }

        public void Context_load()
        {
            io_ct.Analog_Inputs.Load();
            io_ct.Analog_Outputs.Load();
            io_ct.Digital_Inputs.Load();
            io_ct.Digital_Outputs.Load();
        }

    }
}
