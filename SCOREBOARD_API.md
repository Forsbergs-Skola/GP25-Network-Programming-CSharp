# Scoreboard API Reference

The scoreboard uses two separate endpoints:

- `POST` to submit a new score
- `GET` to retrieve the complete scoreboard

The backend implementation is already provided.

---

# POST — Submit Score

## Endpoint

```text
https://hooks.zapier.com/hooks/catch/8338993/ujs9jj9/
```

## Method

```text
POST
```

## Request body

Send JSON containing:

```json
{
  "name": "Daniel",
  "score": 150
}
```

## Fields

| Field | Type | Description |
|---|---|---|
| `name` | string | Player name |
| `score` | number | Player score |

## C# model

```csharp
public class ScoreEntry
{
    public string Name { get; set; } = "";
    public int Score { get; set; }
}
```

## C# example

```csharp
using System.Net.Http.Json;

HttpClient client = new HttpClient();

ScoreEntry entry = new ScoreEntry
{
    Name = "Daniel",
    Score = 150
};

HttpResponseMessage response =
    await client.PostAsJsonAsync(
        "https://hooks.zapier.com/hooks/catch/8338993/ujs9jj9/",
        entry
    );

Console.WriteLine(response.StatusCode);
```

---

# GET — Fetch Scoreboard

## Endpoint

```text
https://script.google.com/macros/s/AKfycbys5aEPMvNCutyhNYYCcQcCjzsi2UtqNspmKyCH-AicJxJbCJMrAoT0LUaYaXhTWA8n/exec
```

## Method

```text
GET
```

## Example response

```json
[
  {
    "name": "Daniel",
    "score": 150
  },
  {
    "name": "Anna",
    "score": 120
  }
]
```

## C# example

```csharp
using System.Net.Http.Json;

HttpClient client = new HttpClient();

List<ScoreEntry>? scores =
    await client.GetFromJsonAsync<List<ScoreEntry>>(
        "https://script.google.com/macros/s/AKfycbys5aEPMvNCutyhNYYCcQcCjzsi2UtqNspmKyCH-AicJxJbCJMrAoT0LUaYaXhTWA8n/exec"
    );

foreach (ScoreEntry score in scores!)
{
    Console.WriteLine(
        $"{score.Name}: {score.Score}"
    );
}
```

---

# Architecture

```text
                 POST
C# Client ───────────────→ Zapier
                              │
                              ▼
                         Google Sheet
                              │
                              │
C# Client ←───────────────────┘
                 GET
          Google Apps Script
```

The C# client does not connect directly to Google Sheets.
