
using PomiGeometry;

namespace PomiConsole
{
    public class Program
    {
        public delegate int MethodPointer(String s);
        static void Main(string[] args)
        {

            StaticSample s1 = new StaticSample();
            StaticSample s2 = new StaticSample();
            StaticSample.counter++;

            s1.PrintCounter();
            s2.PrintCounter();

            TestGeo();
            TestClass tc = new TestClass();

            MethodPointer mp1 = new MethodPointer(tc.GetLength);
            int len = mp1("òlmòljòljòljk");

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
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
