namespace PomiGeometry
{
    public class Cerchio : FiguraGeometrica
    {
        private double _raggio;
        public Cerchio(double raggio)
        {
            _raggio = raggio;
        }
        public override double GetArea()
        {
            return _raggio * _raggio * Math.PI;
        }
        public override double GetPerimetro()
        {
            return 2 * _raggio * Math.PI;
        }
    }
}
