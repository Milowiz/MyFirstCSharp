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

            if(shapes.ValueKind == JsonValueKind.Array)
            {
                foreach(JsonElement element in shapes.EnumerateArray())
                {
                    string type = element.GetProperty("type").GetString() ?? string.Empty;
                }
            }
        }
    }
}