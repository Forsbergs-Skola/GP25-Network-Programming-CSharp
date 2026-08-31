# Network Programming in C#

This repo contains a practical introduction to using HTTP APIs from C#.

The focus is on the **client side**: making requests, sending JSON, receiving JSON, and using remote data in a simple game-like feature.

## What you will practice

By the end of the lesson, you should be able to:

- make a `GET` request from C#
- make a `POST` request from C#
- understand the basic request/response model
- send JSON data to a server
- receive JSON data from a server
- deserialize JSON into C# objects
- submit a score to a shared online scoreboard
- retrieve and display the shared scoreboard
- handle basic network errors without crashing

## Lesson flow

```text
1. Cat Fact API
      ↓
   Learn GET

2. Webhook.site
      ↓
   Learn POST

3. Shared Scoreboard
      ↓
   POST game data

4. Shared Scoreboard
      ↓
   GET game data

5. Final Client
      ↓
   Combine GET + POST
```

## The basic model

```text
HTTP Request

CLIENT ───────────────→ SERVER

       URL
       Method
       Headers
       Body (sometimes)


HTTP Response

CLIENT ←─────────────── SERVER

       Status Code
       Body
```

For this lesson, keep these two methods in mind:

```text
GET  = "Give me something"

POST = "Here is something"
```

## Exercises

1. [01 — GET: Cat Facts](./01-get/README.md)
2. [02 — POST: Webhook.site](./02-post/README.md)
3. [03 — POST: Shared Scoreboard](./03-post-game-data/README.md)
4. [04 — GET: Shared Scoreboard](./04-get-game-data/README.md)
5. [05 — Final Exercise: Online Scoreboard Client](./05-scoreboard-client/README.md)

## Reference material

- [HTTP + C# Cheatsheet](./CHEATSHEET.md)
- [Scoreboard API Reference](./SCOREBOARD_API.md)

## Suggested setup

You can use a normal C# Console App.

```bash
dotnet new console
dotnet run
```

The examples use:

```csharp
using System.Net.Http;
using System.Net.Http.Json;
```

## Important

The backend systems in this lesson already exist.

You are **not** expected to build:

- an ASP.NET server
- a database
- Zapier automation
- Google Apps Script
- Google Sheets integration

Your job is to make the **C# client communicate with those systems**.
