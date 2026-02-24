namespace _04_CenterOfGravity
{
    public class CircleSegment : Forms
    {
        private double Radiant { get; set; }


        public CircleSegment(double radiant)
        {
            Radiant = radiant;
        }

        public override double CalculateArea()
        {
            return Radiant * Radiant * Math.PI;
        }
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * Radiant;
        }

    }
}