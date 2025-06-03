namespace MOSU1
{
    public class DiffBlock : BaseBlock
    {
        private double prev = 0;
        private double dt;

        public DiffBlock(double dt)
        {
            this.dt = dt;
        }

        public override double Calc(double x)
        {
            double derivative = (x - prev) / dt;
            prev = x;
            return derivative;
        }
    }
}