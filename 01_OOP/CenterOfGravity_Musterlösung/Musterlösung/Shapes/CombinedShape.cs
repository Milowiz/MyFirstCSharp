using System.Drawing;
using ScottPlot;

namespace _02_OOP._00_Exercises._05_CombinedCenterOfMass.Shapes
{
    /// <summary>
    /// Represents a combined shape made up of multiple individual shapes.
    /// This class uses the Singleton pattern to ensure only one instance exists.
    /// </summary>
    public class CombinedShape : Shape
    {
        /// <summary>
        /// The list of individual shapes that make up the combined shape.
        /// </summary>
        private List<Shape> Shapes { get; set; }
        /// <summary>
        /// The single instance of the CombinedShape class.
        /// </summary>
        private static CombinedShape? combinedShape { get; set; }
        /// <summary>
        /// Private constructor to prevent direct instantiation. Use GetCombinedShape method instead.
        /// This is how the Singleton pattern is implemented.
        /// </summary>
        /// <param name="shapes">List of shapes to combine.</param>
        private CombinedShape(List<Shape> shapes)
        {
            Shapes = shapes;
        }

        /// <summary>
        /// Gets the single instance of the CombinedShape class.
        /// If the instance does not exist, it creates a new one.
        /// </summary>
        /// <param name="shapes">List of shapes to combine.</param>
        /// <returns>The single instance of CombinedShape.</returns>
        public static CombinedShape GetCombinedShape(List<Shape> shapes)
        {
            if (combinedShape == null)
            {
                combinedShape = new CombinedShape(shapes);
            }
            return combinedShape;
        }

        public override double Area()
        {
            double result = 0;
            foreach (Shape shape in Shapes)
            {
                result += shape.Area();
            }

            return result;
        }

        public override Point BallancePoint()
        {
            double combinedArea = Area();
            double x_s = 0;
            double y_s = 0;
            foreach (Shape shape in Shapes)
            {
                double xcoord = shape.BallancePoint().X;
                double ycoord = shape.BallancePoint().Y;
                x_s += xcoord * shape.Area();
                y_s += ycoord * shape.Area();
            }
            return new Point((int)(x_s / combinedArea), (int)(y_s / combinedArea));
        }

        public override Coordinates[] CalculateDrawingCoordinates()
        {
            throw new NotImplementedException();
        }

        public override void Draw(Plot plot)
        {
            if (!Directory.Exists(BASE_OUTPUT_PATH))
            {
                Directory.CreateDirectory(BASE_OUTPUT_PATH);
            }

            Point ballancePoint = BallancePoint();
            Console.WriteLine($"X:{ballancePoint.X} Y:{ballancePoint.Y}");

            foreach(Shape shape in Shapes)
            {
                shape.Draw(plot);
            }

            plot.Add.ScatterPoints(
                new Coordinates[] {
                    new Coordinates(ballancePoint.X, ballancePoint.Y)
                    },
                ScottPlot.Color.FromColor(System.Drawing.Color.Magenta)
            );

            plot.SavePng(BASE_OUTPUT_PATH + "/combined.png", 550, 650);
        }
    }
}