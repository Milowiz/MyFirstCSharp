using System.Drawing;
using ScottPlot;

namespace _02_OOP._00_Exercises._05_CombinedCenterOfMass.Shapes
{
    /// <summary>
    /// Interface for shapes
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Base output path for images
        /// </summary>
        public static readonly string BASE_OUTPUT_PATH = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "00_Exercises", "05_CombinedCenterOfMass", "Image");

        /// <summary>
        /// Offset point of the shape for positioning of drawing.
        /// It should be always the bottom left corner of the shapes bounding square
        /// </summary>
        public Point OffsetPoint { get; set; }

        /// <summary>
        /// Calculates the area of the shape
        /// </summary>
        /// <returns>The area as a double</returns>
        public abstract double Area();

        /// <summary>
        /// Calculates the ballance point of the shape
        /// </summary>
        /// <returns>The ballance point as a Point</returns>
        public abstract Point BallancePoint();

        /// <summary>
        /// Claculates the coordinates including offset
        /// </summary>
        /// <returns>Array of coordinates</returns>
        public abstract Coordinates[] CalculateDrawingCoordinates();

        /// <summary>
        /// Draws the shape and its ballance pointon the given plot object
        /// </summary>
        /// <param name="plot">The plot to draw on</param>
        public abstract void Draw(Plot plot);
    }
}