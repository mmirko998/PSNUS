using Data_concentrator.Alarms;
using Data_concentrator.Context;
using PLCSimulator;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Data_concentrator
{
    public class DC_manager
    {
        public IO_Context io_ct { get; set; }
        public Alarm_Context alarm_ct { get; set; }
        public PLCSimulatorManager PLC { get; set; }

        public Dictionary<Digital_input, Thread> DI_threads;
        public Dictionary<Analog_input, Thread> AI_threads;

        public DC_manager()
        {
            if (io_ct == null)
            {
                io_ct = new IO_Context();
            }

            if (alarm_ct == null)
            {
                alarm_ct = new Alarm_Context();
            }

            PLC = new PLCSimulatorManager();

            DI_threads = new Dictionary<Digital_input, Thread>();
            AI_threads = new Dictionary<Analog_input, Thread>();
        }
        

        public void Context_load()
        {
            io_ct.Analog_Inputs.Load();
            io_ct.Analog_Outputs.Load();
            io_ct.Digital_Inputs.Load();
            io_ct.Digital_Outputs.Load();

            alarm_ct.Alarms.Load();
            alarm_ct.Alarm_Links.Load();
            alarm_ct.Histories.Load();
        }

        public void Alarms_load()
        {
            foreach(Analog_input ai in io_ct.Analog_Inputs)
            {
                foreach(Alarm_link link in alarm_ct.Alarm_Links)
                {
                    if (ai.Num == link.AI_id)
                    {
                        Alarm al = alarm_ct.Alarms.Find(link.Alarm_id);
                        ai.Alarms.Add(al);
                    }
                }
            }
        }

        public void Digital_input_work(Digital_input di)
        {   
            while(true)
            {
                di.Current_value = PLC.Get_D_value(di.Adress);
                Thread.Sleep((int)(di.Scan_time * 1000));
            }
        }

        public void Start_DI()
        {
            foreach(Digital_input di in io_ct.Digital_Inputs)
            {
                Thread DI_thread = new Thread( () => Digital_input_work(di) );
                DI_threads.Add(di, DI_thread);
                DI_thread.Start();
            }
        }

        public void Stop_DI()
        {
            foreach (Digital_input di in io_ct.Digital_Inputs)
            {
                DI_threads[di].Abort();
                DI_threads.Remove(di);
            }
        }

        public void Add_DI(Digital_input di)
        {
            Thread DI_thread = new Thread(() => Digital_input_work(di));
            DI_threads.Add(di, DI_thread);
            DI_thread.Start();
        }

        private void Analog_input_work(Analog_input ai)
        {
            while (true)
            {
                ai.Current_value = PLC.Get_A_value(ai.Adress);

                if(ai.Alarms.Count != 0)
                {
                    foreach(Alarm alarm in ai.Alarms)
                    {
                        bool exists = ai.Active_alarms.Contains(alarm);
                        if (alarm.Activate(ai.Current_value) && exists == false)
                        {
                            ai.Active_alarms.Add(alarm);
                            alarm.Time = DateTime.Now;
                            string s = $"{alarm.Name} activated for {ai.Name} at {alarm.Time}";
                            History h = new History(s);
                            alarm_ct.Histories.Add(h);
                            alarm_ct.SaveChanges();
                        }
                        if(alarm.Activate(ai.Current_value) == false && exists == true)
                        {
                            ai.Active_alarms.Remove(alarm);
                        }
                    }
                }

                Thread.Sleep((int)(ai.Scan_time * 1000));
            }
        }

        public void Start_AI()
        {
            foreach(Analog_input ai in io_ct.Analog_Inputs)
            {
                Thread AI_thread = new Thread( () => Analog_input_work(ai) );
                AI_threads.Add(ai, AI_thread);
                AI_thread.Start();
            }
        }

        public void Stop_AI()
        {
            foreach(Analog_input ai in io_ct.Analog_Inputs)
            {
                AI_threads[ai].Abort();
                AI_threads.Remove(ai);
            }
        }

        public void Add_AI(Analog_input ai)
        {
            Thread AI_thread = new Thread(() => Analog_input_work(ai));
            AI_threads.Add(ai, AI_thread);
            AI_thread.Start();
        }
    }
}
