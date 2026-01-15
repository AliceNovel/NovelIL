# The NIL file format

The official Novel IL format is defined with Json.

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
      "images": {
        "foreground": ["alice-normal.png"],
        "background": ["green-park.png"]
      },
      "text": "Hi, there." // text or message
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
```

## Cell

There are a few basic cell types for encapsulating code and text. All cells have the following basic structure:

```json
{
  "name": "character name",
  "text": "character message", // text or message
  "images": {
    "foreground": ["foreground-image.png"], // e.g. character image
    "background": ["background-image.png"]
  }
}
```

## Metadata

Metadata is a place that you can put arbitrary JSONable information about your NIL, cell, or output.

Metadata fields officially defined for Novel IL are listed here:

| Key | Value | Interpretation |
| -- | -- | -- |
| `title` | `str` | A game title |
| `authors` | `list` of `strings` | A list of authors of the novel game |
