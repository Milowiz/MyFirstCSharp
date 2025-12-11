using _02_OOP._00_Exercises._05_CombinedCenterOfMass.Shapes;
using ScottPlot;

namespace _02_OOP._00_Exercises._05_CombinedCenterOfMass
{
    public static class Run
    {
        public static void Execute()
        {
            string baseInputPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "00_Exercises", "05_CombinedCenterOfMass", "Input");

            Plot plot = new Plot();

            CombinedShape.GetCombinedShape(ShapeReader.ReadFromXml(Path.Combine(baseInputPath, "shapes.xml"))).Draw(plot);
        }
    }
}