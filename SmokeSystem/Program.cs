namespace SmokeSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dashboard d = new Dashboard();
            Sensor[] arrayOfSensor = new Sensor[10];

            for (int i = 0; i < 10; i++) 
            {
                Sensor s_i = new Sensor("Sensor_" + (i + 1));
                d.AddSensor(s_i);

                arrayOfSensor[i] = s_i;
            }

            arrayOfSensor[3].SimulateSmokeDected();
            arrayOfSensor[5].SimulateSmokeDected();
            arrayOfSensor[9].SimulateSmokeDected();
        }
    }
}
