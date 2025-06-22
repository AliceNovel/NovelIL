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
    "language_info": "English",
    "version": "1.0.0"
  },
  "cells": [
    {
      "character": "Alice", // name or character
      "images": {
        "frontground": ["alice-normal.png"],
        "background": ["green-park.png"]
      },
      "text": "Hi, there." // text or message
    },
    {
      "character": "Rabbit", 
      "images": {
        "frontground": ["rabbit-normal.png"],
        "background": ["green-park.png"]
      },
      // or
      // "images": [
      //   "green-park.png", // primary image
      //   "rabbit-normal.png" // secondary image
      // ],
      "text": "Hi, Alice!"
    }
  ]
}
```

## Cell

There are a few basic cell types for encapsulating code and text. All cells have the following basic structure:

```json
{
  "character": "character name",
  "message": "character message",
  "images": [
    "background-image.png",
    "frontground-image.png" // e.g. character image
  ]
}
```

## Metadata

Metadata is a place that you can put arbitrary JSONable information about your NIL, cell, or output.

Metadata firlds officially defined for Novel IL are listed here:

| Key | Value | Interpretation |
| -- | -- | -- |
| title | str | A game title |
| authors | list of dicts | A list of authors of the novel game |
