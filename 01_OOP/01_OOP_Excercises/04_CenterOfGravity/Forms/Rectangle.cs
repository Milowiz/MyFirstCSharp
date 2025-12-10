using System.Net.Http.Headers;

namespace _02_Geometry
{
public class Rectangle : IForms
{
    private double Length {get;set;}
    private double Height {get;set;}
    

    public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }

        public double CalculateArea()
        {
            return Length * Height;
        }
        public double CalculatePerimeter()
        {
            return 2*Length+2*Height;
        }
 
}
}