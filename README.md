# Terminal API

## Description

This project is a RESTful API built with .NET Core. It provides endpoints for managing `SystemObject` instances, which can be either `DirectoryObject` or `TextFileObject` instances. It's meant to emulate the backend of Linux terminal.

## Endpoints

- `GET /systemobject`: Returns a list of all `SystemObject` instances.
- `GET /systemobject/{id}`: Returns the `SystemObject` with the given `id`.
- `GET /api/scrape:`: Returns an array with data scraped from my Github profile.
- `POST /systemobject/postdir`: Creates a new `DirectoryObject`.
- `POST /systemobject/posttxt`: Creates a new `TextFileObject`.
- `PUT /systemobject/{id}`: Updates the `DirectoryObject` or `TextFileObject` with the given `id`.
- `DELETE /systemobject/{id}`: Deletes the `SystemObject` with the given `id`.

## Usage

To run the project, use the following command:

```bash
dotnet run
```
