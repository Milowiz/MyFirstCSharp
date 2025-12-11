using System.Reflection.Metadata;
using System.Text.Json;
using System.Xml.Linq;

namespace _04_CenterOfGravity
{
    public static class ReadInputFile
    {
        public static List<IForms> ReadFromJson(string filePath)
        {
            List<IForms> forms = new List<IForms>();

            string jsonString = File.ReadAllText(filePath);

            JsonDocument jsonDoc = JsonDocument.Parse(jsonString);
            JsonElement shapes = jsonDoc.RootElement.GetProperty("shapes");

            if (shapes.ValueKind == JsonValueKind.Array)
            {
                foreach (JsonElement element in shapes.EnumerateArray())
                {
                    string type = element.GetProperty("type").GetString() ?? string.Empty;
                    IForms? form = type switch
                    {
                        "Circle" => new Circle(
                            new System.Drawing.Point(
                            element.GetProperty("offsetPoint").GetProperty("x").GetInt32(),
                            element.GetProperty("offsetPoint").GetProperty("y").GetInt32()
                            ),
                        element.GetProperty("raddius").GetDouble()
                            ),
                        "Rectangle" => new Rectangle(new System.Drawing.Point(
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
                        "CircleSector" => new CircleSelector(
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
                    if (form != null)
                    {
                        forms.Add(form);
                    }
                }
            }
            return forms;
        }

        public static List<IForms> ReadFromXml(string filePath)
        {
            List<IForms> forms = new List<IForms>();

            XDocument xmlDoc = XDocument.Load(filePath);

            IEnumerable<XElement>? shapeElements = xmlDoc.Root?.Elements("shape");

            if (shapeElements != null)
            {
                foreach (XElement element in shapeElements)
                {
                    string type = element.Attribute("type")?.Value ?? string.Empty;
                    IForms? form = type switch
                    {
                        "Circle" => new Circle(
                            new System.Drawing.Point(
                                int.Parse(element.Element("offsetPoint")?.Attribute("x")?.Value ?? "0"),
                                int.Parse(element.Element("offsetPoint")?.Attribute("y")?.Value ?? "0")
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
                                 int.Parse(element.Element("point1")?.Value ?? "0"),
                                  int.Parse(element.Element("point1")?.Value ?? "0")
                            ),
                            new System.Drawing.Point(
                                 int.Parse(element.Element("point2")?.Value ?? "0"),
                                  int.Parse(element.Element("point2")?.Value ?? "0")
                            ),
                            new System.Drawing.Point(
                                 int.Parse(element.Element("point3")?.Value ?? "0"),
                                  int.Parse(element.Element("point3")?.Value ?? "0")
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
                    if (forms != null)
                    {
                        forms.Add(form);
                    }
                }
            }
            return forms;
        }
    }
}
