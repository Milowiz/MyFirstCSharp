using System.Drawing;
using ScottPlot;

namespace _02_OOP._00_Exercises._05_CombinedCenterOfMass.Shapes
{
    /// <summary>
    /// Rectangle shape implementation
    /// </summary>
    public class Rectangle : Shape
    {

        /// <summary>
        /// Width of the rectangle
        /// </summary>
        public double Width { get; protected set; }
        /// <summary>
        /// Height of the rectangle
        /// </summary>
        public double Height { get; protected set; }

        /// <summary>
        /// Constructor for Rectangle
        /// </summary>
        /// <param name="offsetPoint">Offset point for positioning. It should be always the bottom left corner of the shapes bounding square</param>
        /// <param name="width">Width of the rectangle</param>
        /// <param name="height">Height of the rectangle</param>
        public Rectangle(Point offsetPoint, double width, double height)
        {
            OffsetPoint = offsetPoint;
            Width = width;
            Height = height;
        }

        public override double Area()
        {
            return Width * Height;
        }

        public override Point BallancePoint()
        {
            return new Point(OffsetPoint.X + (int)(Width / 2), OffsetPoint.Y + (int)(Height / 2));
        }

        public override Coordinates[] CalculateDrawingCoordinates()
        {
            return
            [
                new Coordinates(OffsetPoint.X, OffsetPoint.Y),
                new Coordinates(OffsetPoint.X + Width, OffsetPoint.Y),
                new Coordinates(OffsetPoint.X + Width, OffsetPoint.Y + Height),
                new Coordinates(OffsetPoint.X, OffsetPoint.Y + Height)
            ];
        }

        public override void Draw(Plot plot)
        {
            Point center = BallancePoint();
            plot.Add.Polygon(CalculateDrawingCoordinates());
            plot.Add.ScatterPoints(new Coordinates[]{new Coordinates(center.X, center.Y)}, ScottPlot.Color.FromColor(System.Drawing.Color.Red));
        }

        public override string ToString()
        {
            return $"Rectangle (Offset: {OffsetPoint}, Width: {Width}, Height: {Height}, Area: {Area()})";
        }
    }
}