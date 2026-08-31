# HTTP + C# Cheatsheet

## Create an HttpClient

```csharp
using System.Net.Http;

HttpClient client = new HttpClient();
```

---

# GET

Use `GET` when you want to retrieve data.

## Get raw text

```csharp
string response =
    await client.GetStringAsync(url);

Console.WriteLine(response);
```

---

## Get JSON as a C# object

```csharp
using System.Net.Http.Json;

Player? player =
    await client.GetFromJsonAsync<Player>(url);
```

---

## Get JSON as a list

If the JSON looks like:

```json
[
  {
    "name": "Alice",
    "score": 100
  },
  {
    "name": "Bob",
    "score": 90
  }
]
```

use:

```csharp
List<ScoreEntry>? scores =
    await client.GetFromJsonAsync<List<ScoreEntry>>(url);
```

---

# POST

Use `POST` when you want to send data.

```csharp
using System.Net.Http.Json;

ScoreEntry score = new ScoreEntry
{
    Name = "Alice",
    Score = 100
};

HttpResponseMessage response =
    await client.PostAsJsonAsync(
        url,
        score
    );
```

---

## Check if the request worked

```csharp
if (response.IsSuccessStatusCode)
{
    Console.WriteLine("Success!");
}
else
{
    Console.WriteLine(
        $"Request failed: {response.StatusCode}"
    );
}
```

---

# JSON and C# objects

JSON:

```json
{
  "name": "Alice",
  "score": 100
}
```

C#:

```csharp
public class ScoreEntry
{
    public string Name { get; set; } = "";
    public int Score { get; set; }
}
```

---

# Serialization

```text
C# Object
    ↓
JSON
```

This happens when sending an object with:

```csharp
PostAsJsonAsync(...)
```

---

# Deserialization

```text
JSON
    ↓
C# Object
```

This happens when using:

```csharp
GetFromJsonAsync<T>(...)
```

---

# Sort scores

```csharp
var sorted = scores
    .OrderByDescending(score => score.Score)
    .ToList();
```

---

# Take the top 10

```csharp
var topTen = scores
    .OrderByDescending(score => score.Score)
    .Take(10)
    .ToList();
```

---

# Basic error handling

```csharp
try
{
    string response =
        await client.GetStringAsync(url);

    Console.WriteLine(response);
}
catch (HttpRequestException)
{
    Console.WriteLine(
        "Could not connect to the server."
    );
}
```

---

# Useful HTTP status codes

| Code | Meaning |
|---|---|
| `200` | OK |
| `201` | Created |
| `400` | Bad Request |
| `401` | Unauthorized |
| `403` | Forbidden |
| `404` | Not Found |
| `500` | Internal Server Error |

You do not need to memorize every HTTP status code.

---

# Useful terms

| Term | Meaning |
|---|---|
| Client | The program making the request |
| Server | The system receiving the request |
| Endpoint | A URL exposed by an API |
| Request | A message sent from client to server |
| Response | A message sent back by the server |
| JSON | A common text format for structured data |
| Serialization | C# object → JSON |
| Deserialization | JSON → C# object |
| GET | Retrieve data |
| POST | Send/create data |
