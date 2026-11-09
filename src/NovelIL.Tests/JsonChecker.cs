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
                    "resources": [
                        {
                            "src": "alice-normal.png",
                            "type": "image",
                            "layer": "foreground"
                        },
                        {
                            "src": "green-park.png",
                            "type": "image",
                            "layer": "background"
                        }
                    ],
                    "text": "Hi, there."
                },
                {
                    "name": "Rabbit",
                    "resources": [
                        {
                            "src": "rabbit-normal.png",
                            "type": "image",
                            "layer": "foreground"
                        },
                        {
                            "src": "green-park.png",
                            "type": "image",
                            "layer": "background"
                        }
                    ],
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
