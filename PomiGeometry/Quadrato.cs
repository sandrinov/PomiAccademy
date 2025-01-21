using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PomiGeometry
{
    /// <summary>
    /// 
    /// </summary>
    public class Quadrato : FiguraGeometrica
    {
        private double _lato;
        public Quadrato(double lato)
        {
            _lato = lato;
        }
        public override double GetArea()
        {
            return _lato * _lato;
        }
        public override double GetPerimetro()
        {
            return 4 * _lato;
        }
    }
}
