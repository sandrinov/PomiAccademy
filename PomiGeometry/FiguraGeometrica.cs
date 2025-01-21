using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiGeometry
{
    public abstract class FiguraGeometrica
    {
        public abstract double GetArea();
        public abstract double GetPerimetro();
        public void PrintFigura()
        {
            double area = GetArea();
            double perimetro = GetPerimetro();
            Console.WriteLine("Figura Geometrica con Area " + area + " e perimetro " + perimetro);
        }

    }
}
