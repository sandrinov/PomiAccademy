using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeSystem
{
    public class Dashboard
    {
        List<Sensor> sensors;
        public Dashboard()
        {
            sensors = new List<Sensor>();
        }
        public void AddSensor(Sensor sensor)
        {
            sensor.SmokeDetected += Sensor_SmokeDetected;
            sensors.Add(sensor);
        }

        private void Sensor_SmokeDetected(Sensor sender, SmokeEventArgs e)
        {
            Console.WriteLine( "Smoke detected by sensor: " + sender.SensorName);
        }
    }
}
