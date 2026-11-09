# NIL ファイルフォーマット

公式 Novel IL フォーマットは [Json スキーマ](https://github.com/AliceNovel/NovelIL/blob/5c7a2f6b65a073cd5d5f97f2e0cea785731f50f6/docs/json-schema/latest.json)によって定義され、Novel IL ツールでコードの検証をする際に利用されます。

このページは Novel IL フォーマットを人間が可読できるような説明を記載しています。

## 最上位構造

Novel IL の最上位構造として、辞書型として以下が定義されています:

- metadata (dict)
- cells (list)

```json
{
  "metadata": {
    "title": "アリスの不思議な森",
    "authors": [
      "Alice Project"
    ],
    "languageInfo": [
      "日本語"
    ],
    "version": "1.0.0"
  },
  "cells": [
    {
      "name": "アリス", // name or character
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
      "text": "こんにちは。" // text or message
    },
    {
      "name": "うさぎ",
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
      "text": "こんにちは、アリス!"
    }
  ]
}
```

## Cell

ここでは、基本的なコードやテキストを含んだ cell タイプを表示します。すべての cell は以下のような基本構造を取ります:

```json
{
  "name": "キャラクター名",
  "text": "キャラクターメッセージ", // text or message
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

Novel IL の Cell 領域では、公式に以下のものが定義されています:

| キー | 値 | 説明 |
| -- | -- | -- |
| `name` | `str` | キャラクター名 |
| `text` | `str` | メッセージボックス内に表示するテキスト |
| `resources` | `list` of resource[^res] | 画像、音声、動画など | 

[^res]: \[src (`str`), type (`enum`: image, audio, video, unknown), layer (`enum`: foreground (1), background (-1), int 整数)\] のクラス

## Metadata

Metadata は、NIL、cell、または出力に関する任意の JSON 形式の情報を入れることができる場所です。

Novel IL の Metadata 領域では、公式に以下のものが定義されています:

| キー | 値 | 説明 |
| -- | -- | -- |
| `title` | `str` | ゲームタイトル |
| `authors` | `list` of `strings` | ノベルゲームの作者一覧 |
| `description` | `str` | ゲームに関する説明 |
| `version` | `str` | ノベルゲームのバージョン |
| `license` | `str` | ゲームのライセンス |
| `languageInfo` | `list` of `strings` | サポートする言語一覧 |
