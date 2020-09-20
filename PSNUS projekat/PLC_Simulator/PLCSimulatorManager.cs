﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PLCSimulator
{
    /// <summary>
    /// PLC Simulator
    /// 
    /// 4 x ANALOG INPUT : 0-3
    /// 4 x ANALOG OUTPUT: 10-13
    /// 1 x DIGITAL INPUT: 100
    /// 1 x DIGITAL OUTPUT: 110
    /// </summary>
    public class PLCSimulatorManager
    {
        private Dictionary<int, double> addressValues;
        private object locker = new object();

        Thread t1;
        Thread t2;

        public PLCSimulatorManager()
        {
            addressValues = new Dictionary<int, double>();

            addressValues.Add(0, 0); 
            addressValues.Add(1, 0);
            addressValues.Add(2, 0);
            addressValues.Add(3, 0);
            addressValues.Add(10, 0);
            addressValues.Add(11, 0);
            addressValues.Add(12, 0);
            addressValues.Add(13, 0);
            addressValues.Add(100, 0);
            addressValues.Add(110, 0);
        }

        public void PLC_start()
        {
            t1 = new Thread(GeneratingAnalogInputs);
            t1.Start();

            t2 = new Thread(GeneratingDigitalInputs);
            t2.Start();
        }

        public void PLC_stop()
        {
            t1.Abort();
            t2.Abort();
        }

        private void GeneratingAnalogInputs()
        {
            while (true)
            {
                Thread.Sleep(100);

                lock (locker)
                {
                    addressValues[0] = 100 * Math.Sin((double)DateTime.Now.Second / 60 * Math.PI); //SINE
                    addressValues[1] = 100 * DateTime.Now.Second / 60; //RAMP
                }

                //... 
            }
        }

        private void GeneratingDigitalInputs()
        {
            while (true)
            {
                Thread.Sleep(1000);

                lock (locker)
                {
                    if (addressValues[100] == 0)
                    {
                        addressValues[100] = 1;
                    }
                    else
                    {
                        addressValues[100] = 0;
                    }
                }

                //... 
            }
        }

        public int Get_D_value(int address) 
        {
            return (int)addressValues[address];
        }

        public double Get_A_value(int address)
        {
            return addressValues[address];
        }
    }
}
