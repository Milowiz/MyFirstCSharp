using System.Net.Http.Headers;

namespace _02_Geometry
{
    public class Triangle : IForms
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

        public double CalculateArea()
        {
            return (SideA * SideB)/2;
        }
        public double CalculatePerimeter()
        {
            return SideA + SideB + SideC;
        }

    }
}