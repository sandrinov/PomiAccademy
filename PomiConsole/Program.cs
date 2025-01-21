
using PomiGeometry;

namespace PomiConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            TestGeo();
        }

        private static void TestGeo()
        {
            Quadrato q1 = new Quadrato(10.76);
            Quadrato q2 = new Quadrato(7.9);
            Cerchio c1 = new Cerchio(9.23);
            PrintF(q1);
            PrintF(q2);
            PrintF(c1);
        }

        private static void PrintF(FiguraGeometrica f)
        {
            f.PrintFigura();
        }

        private static void PrintQ(Quadrato quadrato)
        {
            quadrato.PrintFigura();
        }
        private static void PrintC(Cerchio cerchio)
        {
            cerchio.PrintFigura();
        }
    }
}
