using System.Drawing;
using ScottPlot;

namespace _02_OOP._00_Exercises._05_CombinedCenterOfMass.Shapes
{
    /// <summary>
    /// Triangle shape
    /// </summary>
    public class Triangle : Shape
    {
        /// <summary>
        /// First point of the triangle
        /// </summary>
        Point Point1 { get; set; }
        /// <summary>
        /// Second point of the triangle
        /// </summary>
        Point Point2 { get; set; }
        /// <summary>
        /// Third point of the triangle
        /// </summary>
        Point Point3 { get; set; }

        /// <summary>
        /// Constructor for Triangle. Points are interpreted relative to the offset point and must not
        /// be in a specific order.
        /// </summary>
        /// <param name="offsetPoint">Offset point for positioning. It is interpreted as the bottom left corner of the triangle's bounding box</param>
        /// <param name="point1">First point of the triangle</param>
        /// <param name="point2">Second point of the triangle</param>
        /// <param name="point3">Third point of the triangle</param>
        public Triangle( Point offsetPoint, Point point1, Point point2, Point point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;
            OffsetPoint = offsetPoint;
        }

        public override double Area()
        {
            double a = Math.Sqrt(Math.Pow(Point2.X - Point1.X, 2) + Math.Pow(Point2.Y - Point1.Y, 2));
            double b = Math.Sqrt(Math.Pow(Point3.X - Point2.X, 2) + Math.Pow(Point3.Y - Point2.Y, 2));
            double c = Math.Sqrt(Math.Pow(Point1.X - Point3.X, 2) + Math.Pow(Point1.Y - Point3.Y, 2));
            double s = (a + b + c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        public override Point BallancePoint()
        {
            double x_Coord = OffsetPoint.X + 0.333333333333333333333 * (Point1.X + Point2.X + Point3.X);
            double y_Coord = OffsetPoint.Y + 0.333333333333333333333 * (Point1.Y + Point2.Y + Point3.Y);
            return new Point((int)x_Coord, (int)y_Coord);
        }

        public override void Draw(Plot plot)
        {
            Point center = BallancePoint();
            plot.Add.Polygon(CalculateDrawingCoordinates());
            plot.Add.ScatterPoints(new Coordinates[]{new Coordinates(center.X, center.Y)}, ScottPlot.Color.FromColor(System.Drawing.Color.Red));
        }

        public override Coordinates[] CalculateDrawingCoordinates()
        {
            return
            [
                new Coordinates(OffsetPoint.X + Point1.X, OffsetPoint.Y + Point1.Y),
                new Coordinates(OffsetPoint.X + Point2.X, OffsetPoint.Y + Point2.Y),
                new Coordinates(OffsetPoint.X + Point3.X, OffsetPoint.Y + Point3.Y)
            ];
        }
    }
}