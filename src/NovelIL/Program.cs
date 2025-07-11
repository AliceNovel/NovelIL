using System.Text.Json;
using System.Text.Json.Schema;
using System.Text.Json.Serialization;
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
            typeof(NILJsonSchema),
            exporterOptions: new()
            {
                TreatNullObliviousAsNonNullable = true,
            });

        // JSON Schema を JSON 文字列に変換して表示する
        return jsonSchema.ToJsonString(options: new() { WriteIndented = true });
    }

    /// <summary>
    /// NIL Json Schema
    /// </summary>
    class NILJsonSchema
    {
        public Cell[]? Cells { get; set; }
        public Meta? Metadata { get; set; }

        public class Cell
        {
            public string? Name { get; set; } // Character Name
            public string? Text { get; set; } // Message
            public Assets? Images { get; set; }
            public Assets? Audio { get; set; } // (Music, Sound Effects, etc.)
            public Assets? Movies { get; set; }
            public Plugin? Plugins { get; set; } // For future extensibility
            public Dictionary<string, string>? Selectors { get; set; } // For future extensibility
            public Dictionary<string, string>? IfAnd { get; set; } // For future extensibility
            public Dictionary<string, string>? IfOr { get; set; } // For future extensibility

            public class Assets
            {
                public string? Foreground { get; set; }
                public string? Background { get; set; }
            }
            public class Plugin
            {
                public required string Name { get; set; }
                public string? Version { get; set; }
                // TBD: Add more properties as needed
            }
        }

        public class Meta
        {
            public GameInformation? GameInfo { get; set; }
            public EngineCompatibility[]? GameEngineCompatibility { get; set; }
            public GameEngineStyle? GameEngineStyles { get; set; }

            public class GameInformation
            {
                public string? Title { get; set; }
                public string[]? Authors { get; set; }
                public string? Description { get; set; }
                public string? Version { get; set; }
                public string? License { get; set; }
                public string[]? LanguageInfo { get; set; }
            }
            public class EngineCompatibility
            {
                public required string Name { get; set; }
                public required string Version { get; set; }
                public required State State { get; set; } = State.Unknown;
            }
            public class GameEngineStyle
            {
                public required Color Primary { get; set; }
                public Color? Secondary { get; set; }

                public class Color
                {
                    public string? Light { get; set; }
                    public string? Main { get; set; }
                    public string? Dark { get; set; }
                    public string? ContrastText { get; set; }
                }
            }
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum State
        {
            Unknown,
            Compatible,
            PartiallyCompatible,
            Incompatible,
            Deprecated
        }
    };
}
