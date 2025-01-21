using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeSystem
{
    public class SmokeEventArgs
    {
        public bool IsPresent { get; set; }
    }

    public delegate void SmokeEventHandler(Sensor sender, SmokeEventArgs e);
    
    public class Sensor
    {
        public event SmokeEventHandler SmokeDetected;
        public String SensorName { get; set; }

        public Sensor(string name)
        {
            SensorName = name;    
        }
        public void SimulateSmokeDected()
        {
            SmokeEventArgs smokeEventArgs = new SmokeEventArgs() { IsPresent = true };

            if (SimulateSmokeDected != null)
            {
                SmokeDetected(this, smokeEventArgs);
            }
        }

    }
}
