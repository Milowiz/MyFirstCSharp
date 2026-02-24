namespace _04_CenterOfGravity
{
public class Rectangle : Forms
{
    private double Length {get;set;}
    private double Height {get;set;}
    

    public Rectangle(double length, double height)
        {
            Length = length;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Length * Height;
        }
        public override double CalculatePerimeter()
        {
            return 2*Length+2*Height;
        }
 
}
}