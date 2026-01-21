using System.Text.Json;
using Json.Schema;

namespace NovelIL;

public class JsonChecker
{
    public static ValidationResult Validate(string jsonText)
    {
        // if (string.IsNullOrEmpty(jsonText))
        //     return new ValidationResult(false, "json is null or empty");

        // schema 読み込み
        string jsonSchemaString = Program.CreateJsonSchema();
        JsonSchema jsonSchema = JsonSchema.FromText(jsonSchemaString);

        using JsonDocument document = JsonDocument.Parse(jsonText);

        // バリデーション実行
        EvaluationResults results = jsonSchema.Evaluate(document.RootElement);

        // 判定
        if (!results.IsValid)
            // ❌ JSON は schema に適合していません
            return new ValidationResult(false, results.ToString());

        // ✅ JSON は schema に適合しています
        return new ValidationResult(true);
    }

    public sealed class ValidationResult(bool isValid, string? errors = null)
    {
        public bool IsValid { get; } = isValid;
        public string? Error { get; } = errors;
    }
}
