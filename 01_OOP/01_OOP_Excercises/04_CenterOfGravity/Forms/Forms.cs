using System.Drawing;
using System.Net;
using ScottPlot;

namespace _04_CenterOfGravity
{
    public abstract class Forms
    {
        public static readonly string BASE_OUTPUT_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "01_OOP", "01_OOP_Excercises", "04_CenterOfGravity", "Image");

        public Point OffsetPoint { get; set; }
        public abstract double CalculateArea();
        public abstract Point BalancePoint();

        public abstract Coordinates[] CalculateDrawingCoordinates();

        public abstract void Draw(Plot plot);
        public abstract double CalculatePerimeter();
    }

}