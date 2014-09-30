using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleApp
{
    class Vehicle
    {
        public string Name { set; private get; }
        public string RegNo { set; private get; }

        public double MinSpeed { private set; get; }
        public double MaxSpeed { private set; get; }
        public double AvgSpeed { private set; get; }
        private int count=0;
        private double x=0;

        public Vehicle(string name, string regNo):this()
        {
            Name = name;
            RegNo = regNo;
        }

        public Vehicle()
        {
            MaxSpeed = 0;
            MinSpeed = 0;
            AvgSpeed = 0;
        }

        public void SetSpeed(double currentSpeed)
        {
            count++;
            if (AvgSpeed != 0)
            {
                if (x==0)
                {
                    x = AvgSpeed;
                }
                x =x + currentSpeed;
                AvgSpeed = x/count;
                
            }
            else
            {
                AvgSpeed = currentSpeed;
            }
            

            if (currentSpeed > MaxSpeed)
            {
                MaxSpeed = currentSpeed;
            }

            if (currentSpeed < MinSpeed || MinSpeed == 0)
            {
                MinSpeed = currentSpeed;
            }
        }
    }
}
