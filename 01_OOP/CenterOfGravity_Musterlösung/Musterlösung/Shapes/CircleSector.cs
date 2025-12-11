using System.Drawing;
using ScottPlot;

namespace _02_OOP._00_Exercises._05_CombinedCenterOfMass.Shapes
{
    /// <summary>
    /// Circle sector shape
    /// </summary>
    public class CircleSector : Shape
    {
        /// <summary>
        /// Radius of the circle sector
        /// </summary>
        private double Radius { get; set; }
        /// <summary>
        /// Start angle in degrees (0 degrees is along the positive X axis).
        /// Negative values go clockwise, positive values go counter-clockwise.
        /// </summary>
        private double StartAngleInDegrees { get; set; }
        /// <summary>
        /// Angle in degrees of the sector. Should be a positive value.
        /// </summary>
        private double AngleInDegrees { get; set; }

        /// <summary>
        /// Constructor for CircleSector
        /// </summary>
        /// <param name="offsetPoint">Offset point for positioning. It is interpreted as the center of the circle sector's bounding circle</param>
        /// <param name="radius">Radius of the circle sector</param>
        /// <param name="startAngleInDegrees">Start angle in degrees (0 degrees is along the positive X axis). Negative values go clockwise, positive values go counter-clockwise.</param>
        /// <param name="angleInDegrees">Angle in degrees of the sector. Should be a positive value.</param>
        public CircleSector(Point offsetPoint, double radius, double startAngleInDegrees, double angleInDegrees)
        {
            Radius = radius;
            StartAngleInDegrees = startAngleInDegrees;
            AngleInDegrees = (angleInDegrees < 0) ? angleInDegrees * -1 : angleInDegrees;
            OffsetPoint = offsetPoint;
        }

        public override double Area()
        {
            return Math.PI * Math.Pow(Radius, 2) * (AngleInDegrees / 360.0);
        }

        public override Point BallancePoint()
        {
            double angleInRadians = AngleInDegrees * (Math.PI / 180);
            double halfAngleInRadians = angleInRadians / 2;

            // Distance from center to balance point: d = (2/3) * r * sin(θ/2) / (θ/2)
            double distance = 2.0 / 3.0 * Radius * Math.Sin(halfAngleInRadians) / halfAngleInRadians;

            // Midpoint angle of the sector in radians
            double midAngleInRadians = (StartAngleInDegrees + AngleInDegrees / 2) * (Math.PI / 180);

            // Calculate coordinates
            double xCoord = OffsetPoint.X + distance * Math.Cos(midAngleInRadians);
            double yCoord = OffsetPoint.Y + distance * Math.Sin(midAngleInRadians);

            return new Point((int)xCoord, (int)yCoord);
        }

        public override Coordinates[] CalculateDrawingCoordinates()
        {
            int points = Convert.ToInt32(1000 / (Math.PI * 2) * AngleInDegrees);
            Coordinates[] coords = new Coordinates[points];
            double angle = StartAngleInDegrees;

            coords[0] = new Coordinates(OffsetPoint.X, OffsetPoint.Y);

            for (int i = 1; i < points; i++)
            {
                double radian = angle * (Math.PI / 180);
                double x = OffsetPoint.X + Radius * Math.Cos(radian);
                double y = OffsetPoint.Y + Radius * Math.Sin(radian);
                coords[i] = new Coordinates(x, y);
                angle += AngleInDegrees / points;
            }
            return coords;
        }

        public override void Draw(Plot plot)
        {
            plot.Add.Polygon(CalculateDrawingCoordinates());
            plot.Add.ScatterPoints(new Coordinates[] { new Coordinates(BallancePoint().X, BallancePoint().Y) }, ScottPlot.Color.FromColor(System.Drawing.Color.Red));
        }
    }
}