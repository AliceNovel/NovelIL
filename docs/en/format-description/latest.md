# The NIL file format

The official Novel IL format is defined with [this JSON schema](https://github.com/AliceNovel/NovelIL/blob/ebea219ecca73f4c85d7628dd3320abed01c2aef/docs/json-schema/latest.json), which is used by Novel IL tools to validate codes.

This page contains a human-readable description of the Novel IL format.

## Top-level structure

At the highest level, a Novel IL is a dictionary with a few keys:

- metadata (dict)
- cells (list)

```json
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
      "name": "Alice", // name or character
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
      "text": "Hi, there." // text or message
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
```

## Cell

There are a few basic cell types for encapsulating code and text. All cells have the following basic structure:

```json
{
  "name": "character name",
  "text": "character message", // text or message
  "resources": [
    {
      "src": "foreground-image.png", // e.g. character image
      "type": "image",
      "layer": "foreground"
    },
    {
      "src": "background-image.png",
      "type": "image",
      "layer": "background"
    }
  ]
}
```

Cell fields officially defined for Novel IL are listed here:

| Key | Value | Interpretation |
| -- | -- | -- |
| `name` | `str` | The character name |
| `text` | `str` | The message box text |
| `resources` | `list` of resource[^res] | Image, Audio, Video etc. | 

[^res]: Class of \[src (`str`), type (`enum`: image, audio, video, unknown), layer (`enum`: foreground (1), background (-1), any int number)\]

## Metadata

Metadata is a place that you can put arbitrary JSONable information about your NIL, cell, or output.

Metadata fields officially defined for Novel IL are listed here:

| Key | Value | Interpretation |
| -- | -- | -- |
| `title` | `str` | A game title |
| `authors` | `list` of `strings` | A list of authors of the novel game |
| `description` | `str` | A description of the game |
| `version` | `str` | The version of the novel game file |
| `license` | `str` | The license of the game |
| `languageInfo` | `list` of `strings` | The languages the game supports |
