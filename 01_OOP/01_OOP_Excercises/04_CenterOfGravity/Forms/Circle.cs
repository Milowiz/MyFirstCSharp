namespace _04_CenterOfGravity
{
    public class Circle : IForms
    {
        private double Radiant { get; set; }


        public Circle(double radiant)
        {
            Radiant = radiant;
        }

        public double CalculateArea()
        {
            return Radiant * Radiant * Math.PI;
        }
        public double CalculatePerimeter()
        {
            return 2 * Math.PI * Radiant;
        }

    }
}