using System.Drawing;
using ScottPlot;

namespace _02_OOP._00_Exercises._05_CombinedCenterOfMass.Shapes
{
    /// <summary>
    /// Circle shape
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// Radius of the circle
        /// </summary>
        private double Radius { get; set; }

        /// <summary>
        /// Offset point of the shape for positioning of drawing.
        /// It should be always the bottom left corner of the shapes bounding square
        /// </summary>
        public new Point OffsetPoint { get; set; }

        /// <summary>
        /// Constructor for Circle
        /// </summary>
        /// <param name="radius">Radius of the circle</param>
        /// <param name="offsetPoint">Offset point for positioning. It should be always the bottom left corner of the shapes bounding square</param>
        public Circle(Point offsetPoint,double radius)
        {
            Radius = radius;
            OffsetPoint = offsetPoint;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override Point BallancePoint()
        {
            return new Point((int)(OffsetPoint.X + Radius), (int)(OffsetPoint.Y + Radius));
        }

        public override void Draw(Plot plot)
        {
            plot.Add.Circle(new Coordinates(OffsetPoint.X + Radius, OffsetPoint.Y + Radius), Radius);
            Point center = BallancePoint();
            plot.Add.ScatterPoints(new Coordinates[] { new Coordinates(center.X, center.Y) }, ScottPlot.Color.FromColor(System.Drawing.Color.Red));
        }

        public override Coordinates[] CalculateDrawingCoordinates()
        {
            Coordinates[] coords = new Coordinates[1000];
            double angle = 0;
            Point center = BallancePoint();
            for (int i = 0; i < 1000; i++)
            {
                coords[i] = new Coordinates(
                    center.X + Radius * Math.Cos(angle),
                    center.Y + Radius * Math.Sin(angle)
                );
                angle += 0.00628318530718;
            }

            return coords;
        }
    }
}