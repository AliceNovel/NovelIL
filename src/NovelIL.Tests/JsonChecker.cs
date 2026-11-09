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
                            "path": "alice-normal.png",
                            "resourcetype": "image",
                            "layer": "foreground"
                        },
                        {
                            "path": "green-park.png",
                            "resourcetype": "image",
                            "layer": "background"
                        }
                    ],
                    "text": "Hi, there."
                },
                {
                    "name": "Rabbit",
                    "resources": [
                        {
                            "path": "rabbit-normal.png",
                            "resourcetype": "image",
                            "layer": "foreground"
                        },
                        {
                            "path": "green-park.png",
                            "resourcetype": "image",
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
