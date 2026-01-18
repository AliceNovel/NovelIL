using System.Text.Json;
using Json.Schema;
using NovelIL;

namespace NovelIL.Tests;

public class UnitTest1
{
    [Fact]
    static public void JsonChecker()
    {
        // schema 読み込み
        string jsonSchemaString = Program.CreateJsonSchema();
        JsonSchema jsonSchema = JsonSchema.FromText(jsonSchemaString);

        // JSON 読み込み
        string jsonText = """
        {
            "metadata": {
                "title": "Alice's Wonder Forest",
                "authors": [
                    "Alice Project"
                ],
                "languageInfo": [
                    "English"
                ],
                "version": "1.0.0"
            },
            "cells": [
                {
                    "name": "Alice",
                    "images": {
                        "foreground": ["alice-normal.png"],
                        "background": ["green-park.png"]
                    },
                    "text": "Hi, there."
                },
                {
                    "name": "Rabbit", 
                    "images": {
                        "foreground": ["rabbit-normal.png"],
                        "background": ["green-park.png"]
                    },
                    "text": "Hi, Alice!"
                }
            ]
        }
        """;
        using JsonDocument document = JsonDocument.Parse(jsonText);

        // バリデーション実行
        EvaluationResults results = jsonSchema.Evaluate(document.RootElement);

        // 判定
        if (results.IsValid)
            Console.WriteLine("✅ JSON は schema に適合しています");
        else
        {
            Console.WriteLine("❌ JSON は schema に適合していません");
            Console.Error.WriteLine(results);
        }
    }
}
