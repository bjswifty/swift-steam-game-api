# swift-steam-game-api
RESTful API to manage a personal Steam game library.

## Running the API

```powershell
dotnet run --project SwiftSteamGameApi.csproj
```

Base URL:

```text
http://localhost:5117
```

Swagger UI is available in Development at:

```text
http://localhost:5117/swagger
```

## Health Check

```http
GET http://localhost:5117/health
```

Example response:

```text
Healthy
```

## Game Records API

All game record endpoints are available under:

```text
/api/gamerecords
```

### Get Game Record List

Returns all game records with their related details, tracking fields, review, tags, screenshots, achievements, and categories.

```http
GET http://localhost:5117/api/gamerecords
Accept: application/json
```

Example response:

```json
[
  {
    "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "details": {
      "id": "6b60f8cd-5a35-4cc6-b4dd-f36f0fd3f9ec",
      "gameRecordId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "title": "Hades",
      "developer": "Supergiant Games",
      "publisher": "Supergiant Games",
      "yearOfRelease": 2020,
      "genres": [
        {
          "id": "aef1b0dc-1fcb-4334-8b9c-73e19d8ee7d7",
          "gameRecordId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "gameDetailsId": "6b60f8cd-5a35-4cc6-b4dd-f36f0fd3f9ec",
          "name": "Roguelike"
        },
        {
          "id": "6ebd6d51-b14d-47ab-a8e8-cb4d4e099056",
          "gameRecordId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
          "gameDetailsId": "6b60f8cd-5a35-4cc6-b4dd-f36f0fd3f9ec",
          "name": "Action"
        }
      ],
      "platform": "Steam",
      "description": "Battle out of the Underworld in this rogue-like dungeon crawler.",
      "externalId": "1145360"
    },
    "tracking": {
      "id": "16f7fc3e-8e41-49d0-9cd9-921d0fb4a2fd",
      "gameRecordId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "isOwned": true,
      "hasPlayed": true,
      "isCompleted": true,
      "isInBacklog": false,
      "wantsReplay": true,
      "dateStarted": "2024-01-15",
      "dateCompleted": "2024-02-20",
      "hoursPlayed": 87.5
    },
    "review": {
      "id": "6230d9e5-7f78-4416-bf66-b7d61f857a9e",
      "gameRecordId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      "personalRating": 9.5,
      "reviewTitle": "Outstanding roguelike",
      "reviewBody": "Tight combat, great story, and incredible replay value.",
      "pros": "Combat, narrative, art direction",
      "cons": "Can be punishing early on",
      "favoriteMoment": "Final escape attempt",
      "difficultyRating": 7,
      "replayValue": 10,
      "reviewedAt": "2024-02-20T12:00:00Z"
    },
    "tags": [
      {
        "id": "a40af09c-dc07-4bb6-8834-53c95259b1c5",
        "gameRecordId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "name": "indie"
      },
      {
        "id": "70bd208c-e360-48e4-8583-05cdeab6acb5",
        "gameRecordId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        "name": "favorite"
      }
    ],
    "status": "Completed",
    "priority": "Low",
    "createdAt": "2024-02-20T12:00:00Z",
    "updatedAt": "2024-02-20T12:00:00Z",
    "screenshots": [],
    "achievements": [],
    "categories": []
  }
]
```

### Get Game Record By ID

Returns a single game record by its `Guid`.

```http
GET http://localhost:5117/api/gamerecords/3fa85f64-5717-4562-b3fc-2c963f66afa6
Accept: application/json
```

Example response:

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "details": {
    "title": "Hades",
    "developer": "Supergiant Games",
    "publisher": "Supergiant Games",
    "yearOfRelease": 2020,
    "genres": [
      {
        "name": "Roguelike"
      },
      {
        "name": "Action"
      }
    ],
    "platform": "Steam",
    "description": "Battle out of the Underworld in this rogue-like dungeon crawler.",
    "externalId": "1145360"
  },
  "tracking": {
    "isOwned": true,
    "hasPlayed": true,
    "isCompleted": true,
    "isInBacklog": false,
    "wantsReplay": true,
    "dateStarted": "2024-01-15",
    "dateCompleted": "2024-02-20",
    "hoursPlayed": 87.5
  },
  "review": {
    "personalRating": 9.5,
    "reviewTitle": "Outstanding roguelike",
    "reviewBody": "Tight combat, great story, and incredible replay value.",
    "pros": "Combat, narrative, art direction",
    "cons": "Can be punishing early on",
    "favoriteMoment": "Final escape attempt",
    "difficultyRating": 7,
    "replayValue": 10
  },
  "tags": [
    {
      "name": "indie"
    },
    {
      "name": "favorite"
    }
  ],
  "status": "Completed",
  "priority": "Low",
  "screenshots": [],
  "achievements": [],
  "categories": []
}
```

Possible responses:

- `200 OK` when the record exists.
- `404 Not Found` when no record exists for the requested ID.

### Create Game Record

Creates a new game record and inserts the related child records into SQLite.

```http
POST http://localhost:5117/api/gamerecords
Content-Type: application/json
```

Example request body:

```json
{
  "details": {
    "title": "Hades",
    "developer": "Supergiant Games",
    "publisher": "Supergiant Games",
    "yearOfRelease": 2020,
    "genres": [
      {
        "name": "Roguelike"
      },
      {
        "name": "Action"
      }
    ],
    "platform": "Steam",
    "description": "Battle out of the Underworld in this rogue-like dungeon crawler.",
    "externalId": "1145360"
  },
  "tracking": {
    "isOwned": true,
    "hasPlayed": true,
    "isCompleted": true,
    "isInBacklog": false,
    "wantsReplay": true,
    "dateStarted": "2024-01-15",
    "dateCompleted": "2024-02-20",
    "hoursPlayed": 87.5
  },
  "review": {
    "personalRating": 9.5,
    "reviewTitle": "Outstanding roguelike",
    "reviewBody": "Tight combat, great story, and incredible replay value.",
    "pros": "Combat, narrative, art direction",
    "cons": "Can be punishing early on",
    "favoriteMoment": "Final escape attempt",
    "difficultyRating": 7,
    "replayValue": 10
  },
  "tags": [
    {
      "name": "indie"
    },
    {
      "name": "favorite"
    }
  ],
  "status": "Completed",
  "priority": "Low",
  "screenshots": [
    {
      "url": "https://example.com/hades-screenshot.jpg",
      "caption": "Boss fight",
      "capturedAt": "2024-02-01T18:30:00Z"
    }
  ],
  "achievements": [
    {
      "name": "Blood Bound",
      "description": "Complete the main escape quest.",
      "isUnlocked": true,
      "unlockedAt": "2024-02-20T12:00:00Z",
      "externalId": "ACH_BLOOD_BOUND"
    }
  ],
  "categories": [
    {
      "name": "All-Time Greats"
    }
  ]
}
```

Example response:

```json
{
  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "details": {
    "title": "Hades",
    "developer": "Supergiant Games",
    "publisher": "Supergiant Games",
    "yearOfRelease": 2020,
    "genres": [
      {
        "name": "Roguelike"
      },
      {
        "name": "Action"
      }
    ],
    "platform": "Steam",
    "description": "Battle out of the Underworld in this rogue-like dungeon crawler.",
    "externalId": "1145360"
  },
  "tracking": {
    "isOwned": true,
    "hasPlayed": true,
    "isCompleted": true,
    "isInBacklog": false,
    "wantsReplay": true,
    "dateStarted": "2024-01-15",
    "dateCompleted": "2024-02-20",
    "hoursPlayed": 87.5
  },
  "review": {
    "personalRating": 9.5,
    "reviewTitle": "Outstanding roguelike",
    "reviewBody": "Tight combat, great story, and incredible replay value.",
    "pros": "Combat, narrative, art direction",
    "cons": "Can be punishing early on",
    "favoriteMoment": "Final escape attempt",
    "difficultyRating": 7,
    "replayValue": 10
  },
  "tags": [
    {
      "name": "indie"
    },
    {
      "name": "favorite"
    }
  ],
  "status": "Completed",
  "priority": "Low",
  "screenshots": [
    {
      "url": "https://example.com/hades-screenshot.jpg",
      "caption": "Boss fight",
      "capturedAt": "2024-02-01T18:30:00Z"
    }
  ],
  "achievements": [
    {
      "name": "Blood Bound",
      "description": "Complete the main escape quest.",
      "isUnlocked": true,
      "unlockedAt": "2024-02-20T12:00:00Z",
      "externalId": "ACH_BLOOD_BOUND"
    }
  ],
  "categories": [
    {
      "name": "All-Time Greats"
    }
  ]
}
```

Possible responses:

- `201 Created` when the record is inserted successfully.
- `400 Bad Request` when validation fails.

Notes:

- ID fields can be omitted in the POST body. The API generates them.
- `review`, `screenshots`, `achievements`, and `categories` are optional.
- Enum values can be sent as strings, such as `"Steam"`, `"Completed"`, and `"Low"`.
