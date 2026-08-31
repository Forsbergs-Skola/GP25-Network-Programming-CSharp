# 04 — GET: Shared Scoreboard

## Goal

Retrieve the full scoreboard from the internet and turn the JSON response into C# objects.

The scores submitted in the previous exercise can now be retrieved by everyone.

---

## Architecture

```text
Google Sheet
    │
    ▼
Google Apps Script
    │
    │ JSON
    ▼
C# Client
```

---

## Scoreboard GET endpoint

```text
https://script.google.com/macros/s/AKfycbys5aEPMvNCutyhNYYCcQcCjzsi2UtqNspmKyCH-AicJxJbCJMrAoT0LUaYaXhTWA8n/exec
```

Method:

```text
GET
```

Example response:

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

---

## Task 1 — Print the raw response

Start by making a normal `GET` request.

Print the raw JSON to the console.

### Hint

Use:

```csharp
GetStringAsync(...)
```

---

## Important JSON difference

The Cat Fact API returned one object:

```json
{
  "fact": "...",
  "length": 42
}
```

The scoreboard returns an **array of objects**:

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

That means the corresponding C# type is:

```csharp
List<ScoreEntry>
```

rather than:

```csharp
ScoreEntry
```

---

## Task 2 — Deserialize the scoreboard

Use the same model as before:

```csharp
public class ScoreEntry
{
    public string Name { get; set; } = "";
    public int Score { get; set; }
}
```

Deserialize the response into:

```csharp
List<ScoreEntry>
```

### Hint

Use:

```csharp
GetFromJsonAsync<List<ScoreEntry>>(...)
```

---

## Task 3 — Print all scores

Display:

```text
Daniel: 150
Anna: 120
...
```

---

## Task 4 — Sort the scoreboard

The API returns the complete scoreboard.

Sort it in your C# client from highest score to lowest.

### Hint

Look at:

```csharp
OrderByDescending(...)
```

Example:

```text
=== LEADERBOARD ===

1. Alice        8300
2. Dave         7200
3. Charlie      4500
4. Bob          1200
```

---

## Task 5 — Show only the top 10

After sorting, display only the ten highest scores.

### Hint

Look at:

```csharp
Take(10)
```

---

## Questions

Be ready to explain:

1. Why is the scoreboard deserialized into a `List<ScoreEntry>`?
2. Who sorts the scores in this exercise: the server or the client?
3. What would happen if the server returned invalid JSON?
4. Why can a score submitted by one student appear in another student's program?
5. What makes this data "networked" rather than local?

---

## Optional challenge

Find and display your own best score.
