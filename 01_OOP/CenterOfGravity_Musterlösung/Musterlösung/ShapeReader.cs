using System.Text.Json;
using System.Xml.Linq;
using _02_OOP._00_Exercises._05_CombinedCenterOfMass.Shapes;

namespace _02_OOP._00_Exercises._05_CombinedCenterOfMass
{
    public static class ShapeReader
    {
        /// <summary>
        /// Reads shapes from a JSON file and returns a list of Shape objects.
        /// </summary>
        /// <param name="filePath">The path to the JSON file containing shape data.</param>
        /// <returns>A list of Shape objects read from the JSON file.</returns>
        public static List<Shape> ReadFromJson(string filePath)
        {
            List<Shape> shapes = new List<Shape>();

            // Read the JSON file content
            string jsonString = File.ReadAllText(filePath);

            // Parse the JSON content into a JsonDocument
            JsonDocument jsonDoc = JsonDocument.Parse(jsonString);
            // Get the root element containing the shapes array
            JsonElement root = jsonDoc.RootElement.GetProperty("shapes");

            if (root.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement element in root.EnumerateArray())
                {
                    string type = element.GetProperty("type").GetString() ?? string.Empty;

                    Shape? shape = type switch
                    {
                        "Circle" => new Circle(
                            new System.Drawing.Point(
                                element.GetProperty("offsetPoint").GetProperty("x").GetInt32(),
                                element.GetProperty("offsetPoint").GetProperty("y").GetInt32()
                            ),
                            element.GetProperty("radius").GetDouble()
                        ),
                        "Rectangle" => new Rectangle(
                            new System.Drawing.Point(
                                element.GetProperty("offsetPoint").GetProperty("x").GetInt32(),
                                element.GetProperty("offsetPoint").GetProperty("y").GetInt32()
                            ),
                            element.GetProperty("width").GetDouble(),
                            element.GetProperty("height").GetDouble()
                        ),
                        "Triangle" => new Triangle(
                            new System.Drawing.Point(
                                element.GetProperty("offsetPoint").GetProperty("x").GetInt32(),
                                element.GetProperty("offsetPoint").GetProperty("y").GetInt32()
                            ),
                            new System.Drawing.Point(
                                element.GetProperty("point1").GetProperty("x").GetInt32(),
                                element.GetProperty("point1").GetProperty("y").GetInt32()
                            ),
                            new System.Drawing.Point(
                                element.GetProperty("point2").GetProperty("x").GetInt32(),
                                element.GetProperty("point2").GetProperty("y").GetInt32()
                            ),
                            new System.Drawing.Point(
                                element.GetProperty("point3").GetProperty("x").GetInt32(),
                                element.GetProperty("point3").GetProperty("y").GetInt32()
                            )
                        ),
                        "CircleSector" => new CircleSector(
                            new System.Drawing.Point(
                                element.GetProperty("offsetPoint").GetProperty("x").GetInt32(),
                                element.GetProperty("offsetPoint").GetProperty("y").GetInt32()
                            ),
                            element.GetProperty("radius").GetDouble(),
                            element.GetProperty("startAngle").GetDouble(),
                            element.GetProperty("sweepAngle").GetDouble()
                        ),
                        "CircleSegment" => new CircleSegment(
                            new System.Drawing.Point(
                                element.GetProperty("offsetPoint").GetProperty("x").GetInt32(),
                                element.GetProperty("offsetPoint").GetProperty("y").GetInt32()
                            ),
                            element.GetProperty("radius").GetDouble(),
                            element.GetProperty("startAngle").GetDouble(),
                            element.GetProperty("sweepAngle").GetDouble()
                        ),
                        _ => null
                    };

                    if (shape != null)
                    {
                        shapes.Add(shape);
                    }
                }
            }

            return shapes;
        }

        /// <summary>
        /// Reads shapes from an XML file and returns a list of Shape objects.
        /// </summary>
        /// <param name="filePath">The path to the XML file containing shape data.</param>
        /// <returns>A list of Shape objects read from the XML file.</returns>
        public static List<Shape> ReadFromXml(string filePath)
        {
            List<Shape> shapes = new List<Shape>();

            // Load the XML document
            XDocument xmlDoc = XDocument.Load(filePath);
            // Get all shape elements in the root element of the XML document
            IEnumerable<XElement>? shapeElements = xmlDoc.Root?.Elements("shape");

            if (shapeElements != null)
            {
                foreach (XElement element in shapeElements)
                {
                    string type = element.Attribute("type")?.Value ?? string.Empty;

                    Shape? shape = type switch
                    {
                        "Circle" => new Circle(
                            new System.Drawing.Point(
                                int.Parse(element.Element("offsetPoint")?.Attribute("x")?.Value ?? "0"),
                                int.Parse(element.Element("offsetPoint")?.Attribute("y")?.Value ?? "0")
                            ),
                            double.Parse(element.Element("radius")?.Value ?? "0")
                        ),
                        "Rectangle" => new Rectangle(
                            new System.Drawing.Point(
                                int.Parse(element.Element("offsetPoint")?.Attribute("x")?.Value ?? "0"),
                                int.Parse(element.Element("offsetPoint")?.Attribute("y")?.Value ?? "0")
                            ),
                            double.Parse(element.Element("width")?.Value ?? "0"),
                            double.Parse(element.Element("height")?.Value ?? "0")
                        ),
                        "Triangle" => new Triangle(
                            new System.Drawing.Point(
                                int.Parse(element.Element("offsetPoint")?.Attribute("x")?.Value ?? "0"),
                                int.Parse(element.Element("offsetPoint")?.Attribute("y")?.Value ?? "0")
                                ),
                            new System.Drawing.Point(
                                int.Parse(element.Element("point1")?.Attribute("x")?.Value ?? "0"),
                                int.Parse(element.Element("point1")?.Attribute("y")?.Value ?? "0")
                            ),
                            new System.Drawing.Point(
                                int.Parse(element.Element("point2")?.Attribute("x")?.Value ?? "0"),
                                int.Parse(element.Element("point2")?.Attribute("y")?.Value ?? "0")
                            ),
                            new System.Drawing.Point(
                                int.Parse(element.Element("point3")?.Attribute("x")?.Value ?? "0"),
                                int.Parse(element.Element("point3")?.Attribute("y")?.Value ?? "0")
                            )
                        ),
                        "CircleSector" => new CircleSector(
                            new System.Drawing.Point(
                                int.Parse(element.Element("offsetPoint")?.Attribute("x")?.Value ?? "0"),
                                int.Parse(element.Element("offsetPoint")?.Attribute("y")?.Value ?? "0")
                            ),
                            double.Parse(element.Element("radius")?.Value ?? "0"),
                            double.Parse(element.Element("startAngle")?.Value ?? "0"),
                            double.Parse(element.Element("sweepAngle")?.Value ?? "0")
                        ),
                        "CircleSegment" => new CircleSegment(
                            new System.Drawing.Point(
                                int.Parse(element.Element("offsetPoint")?.Attribute("x")?.Value ?? "0"),
                                int.Parse(element.Element("offsetPoint")?.Attribute("y")?.Value ?? "0")
                            ),
                            double.Parse(element.Element("radius")?.Value ?? "0"),
                            double.Parse(element.Element("startAngle")?.Value ?? "0"),
                            double.Parse(element.Element("sweepAngle")?.Value ?? "0")
                        ),
                        _ => null
                    };

                    if (shape != null)
                    {
                        shapes.Add(shape);
                    }
                }
            }

            return shapes;
        }
    }
}