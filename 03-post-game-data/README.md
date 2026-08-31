# 03 — POST: Shared Scoreboard

## Goal

Submit useful game data to a shared online scoreboard.

You will now use the same technique as the previous exercise, but instead of sending test data to Webhook.site, you will send a real score to a shared scoreboard.

---

## Architecture

```text
C# Client
    │
    │ POST
    ▼
Zapier Webhook
    │
    ▼
Google Sheet
```

The automation already exists.

You only need to write the C# client.

---

## Scoreboard POST endpoint

```text
https://hooks.zapier.com/hooks/catch/8338993/ujs9jj9/
```

Method:

```text
POST
```

Expected JSON:

```json
{
  "name": "Daniel",
  "score": 150
}
```

---

## Create the model

Use:

```csharp
public class ScoreEntry
{
    public string Name { get; set; } = "";
    public int Score { get; set; }
}
```

---

## Task 1 — Submit a fixed score

Create a `ScoreEntry`:

```csharp
ScoreEntry entry = new ScoreEntry
{
    Name = "YOUR NAME",
    Score = 100
};
```

Send it to the scoreboard endpoint using `POST`.

### Hint

Use:

```csharp
PostAsJsonAsync(...)
```

---

## Task 2 — Check the response

Store the result as:

```csharp
HttpResponseMessage response
```

Then print:

```csharp
response.StatusCode
```

You can also check:

```csharp
response.IsSuccessStatusCode
```

---

## Task 3 — Ask the user for a score

Change your program so the user can enter a name and score.

Example:

```text
Name: Alex
Score: 4500

Submitting...
Score submitted!
```

---

## Task 4 — Verify the result

After submitting your score, check that it appears on the shared scoreboard.

Remember:

```text
Your C# App
     ↓
   POST
     ↓
Zapier receives the request
     ↓
Google Sheets stores the row
```

---

## Questions

Be ready to explain:

1. What data does the scoreboard expect?
2. Why would changing `name` to `username` potentially break the integration?
3. What does `IsSuccessStatusCode` tell us?
4. Is your C# program writing directly to Google Sheets?
5. What role does Zapier play in this setup?

---

## Optional challenge

Prevent obviously invalid scores from being submitted.

Examples:

```text
Score must not be negative.
Name must not be empty.
```
