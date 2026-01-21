namespace NovelIL.Tests;

public class UnitTest1
{
    [Fact]
    static public void JsonCheckerTest()
    {
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

        var result = JsonChecker.Validate(jsonText);

        if (!result.IsValid && result.Error is not null)
            Console.WriteLine(result.Error);
    }
}
