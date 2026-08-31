# 01 — GET: Cat Facts

## Goal

Make your first HTTP `GET` request from C#.

We will use the Cat Fact API:

```text
https://catfact.ninja/fact
```

A `GET` request asks a server to return data.

```text
C# Client
    │
    │ GET
    ▼
Cat Fact API
    │
    │ JSON
    ▼
C# Client
```

---

## Task 1 — Get the raw response

Create an `HttpClient`:

```csharp
using System.Net.Http;

HttpClient client = new HttpClient();
```

Use it to make a `GET` request to:

```text
https://catfact.ninja/fact
```

Print the raw response to the console.

### Expected result

You should get JSON similar to:

```json
{
  "fact": "Cats sleep a lot.",
  "length": 18
}
```

The actual cat fact will vary.

### Hint

Look at:

```csharp
GetStringAsync(...)
```

---

## Task 2 — Turn JSON into a C# object

Instead of treating the response as one large string, deserialize it into a C# object.

Create this model:

```csharp
public class CatFact
{
    public string Fact { get; set; } = "";
    public int Length { get; set; }
}
```

Then use:

```csharp
using System.Net.Http.Json;
```

Your goal is to end up with a `CatFact` object and print only:

```text
Cats sleep a lot.
```

instead of the complete JSON.

### Hint

Look at:

```csharp
GetFromJsonAsync<T>(...)
```

---

## Task 3 — Get multiple facts

Modify your program so it retrieves several cat facts.

Example output:

```text
Cat Fact #1
...

Cat Fact #2
...

Cat Fact #3
...
```

Try at least five requests.

---

## Questions

Be ready to explain:

1. What does `GET` mean?
2. Where is the cat fact generated?
3. What does `await` do here?
4. What is JSON?
5. What is the difference between the raw JSON response and a `CatFact` object?

---

## Optional challenge

Display both the fact and its reported length:

```text
Fact: Cats sleep a lot.
Length: 18
```
