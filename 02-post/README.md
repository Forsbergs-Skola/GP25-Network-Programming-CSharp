# 02 — POST: Webhook.site

## Goal

Send data from your C# program to a server using HTTP `POST`.

A `POST` request is commonly used when the client wants to send data to another system.

```text
C# Client
    │
    │ POST + JSON
    ▼
Webhook.site
```

Webhook.site is useful because it lets you **see the incoming request**.

---

## Step 1 — Create your webhook

Open:

```text
https://webhook.site/
```

You will receive a unique URL.

Keep Webhook.site open while you work.

---

## Task 1 — Send JSON

Create an object like this:

```csharp
var data = new
{
    name = "Your Name",
    message = "Hello from C#!"
};
```

Then send it to your Webhook.site URL.

You will need:

```csharp
using System.Net.Http.Json;
```

### Hint

Look at:

```csharp
PostAsJsonAsync(...)
```

---

## Expected result

Your request should appear in Webhook.site.

The body should look similar to:

```json
{
  "name": "Your Name",
  "message": "Hello from C#!"
}
```

---

## What just happened?

Your C# object:

```text
name = Your Name
message = Hello from C#
```

was serialized into JSON:

```json
{
  "name": "Your Name",
  "message": "Hello from C#!"
}
```

and sent over HTTP.

```text
C# Object
    ↓
Serialization
    ↓
JSON
    ↓
HTTP POST
    ↓
Webhook.site
```

---

## Task 2 — Send player data

Create and send this data:

```json
{
  "player": "Your Name",
  "health": 75,
  "level": 4,
  "alive": true
}
```

Choose suitable C# types for each value.

Verify in Webhook.site that all four values arrive correctly.

---

## Task 3 — Experiment

Try changing:

- property names
- values
- numeric values
- boolean values

Observe what changes in Webhook.site.

---

## Questions

Be ready to explain:

1. What is the difference between `GET` and `POST`?
2. Where can you see the body of the request?
3. What format are we using to send the data?
4. What does serialization mean?
5. Why do the client and server need to agree on the names and types of fields?
