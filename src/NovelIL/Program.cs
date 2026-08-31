using System.Text.Json;
using System.Text.Json.Schema;
using System.Text.Json.Serialization.Metadata;

namespace NovelIL;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(CreateJsonSchema());
    }

    public static string CreateJsonSchema()
    {
        // Person record から JSON Schema を生成する
        var jsonSchema = JsonSchemaExporter.GetJsonSchemaAsNode(
            options: new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                TypeInfoResolver = new DefaultJsonTypeInfoResolver(),
            },
            typeof(NovelILDocument),
            exporterOptions: new()
            {
                TreatNullObliviousAsNonNullable = true,
            });

        // JSON Schema を JSON 文字列に変換して表示する
        return jsonSchema.ToJsonString(options: new() { WriteIndented = true });
    }
}
