namespace _04_CenterOfGravity
{
    public class Triangle : Forms
    {
        private double SideA { get; set; }
        private double SideB { get; set; }
        private double SideC { get; set; }



        public Triangle(double sideA, double sideB, double sideC)
        {
         SideA = sideA;
         SideB = sideB;
         SideC = sideC;   
        }

        public override double CalculateArea()
        {
            return (SideA * SideB)/2;
        }
        public override double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

    }
}