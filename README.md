### Method: GetAll

**Definition:**

```csharp
public static List<SystemObject> GetAll()
```

**Description:**

The GetAll method is a static method in the SystemObjectService class. It returns a list of all SystemObject instances stored in the SystemObjects list.

**Returns:**

A List<SystemObject> containing all SystemObject instances. If no SystemObject instances are present, it returns an empty list.

**Usage:**

```csharp
List<SystemObject> allSystemObjects = SystemObjectService.GetAll();
```

### Query: GetAll

```csharp
[HttpGet]
public ActionResult<List<SystemObject>> GetAll() => SystemObjectService.GetAll();
```

**Description:**

The GetAll method is an HTTP GET method in the FileObjectController class. It calls the GetAll method from the SystemObjectService class to retrieve a list of all SystemObject instances.

**Returns:**

An ActionResult<List<SystemObject>> that contains a list of SystemObject instances. If no SystemObject instances are present, it returns an empty list.

**Usage:**

This method is intended to be used as an endpoint in an API. It can be called by making a GET request to the / path of the API.

**Example:**

```
GET /systemobject

RESPONSE:
[
  {
    "Id": 1,
    "Name": "home",
    "Date": 10101000000,
    "Type": "dir",
    "ParentId": 0
  },
  {
    "Id": 2,
    "Name": "bin",
    "Date": 10101000000,
    "Type": "dir",
    "ParentId": 0
  }
]
```

## Method: Get

**Definition:**

```csharp
public static SystemObject? Get(int id)
```

**Description:**

The Get method is a static method in the SystemObjectService class. It retrieves a SystemObject instance from the SystemObjects list based on the provided id.

**Parameters:**

- id (int): The identifier of the SystemObject to retrieve.

**Returns:**

A SystemObject instance if an object with the provided id exists in the SystemObjects list. If no such object exists, it returns null.

**Usage:**

```csharp
SystemObject myObject = SystemObjectService.Get(1);
```

### Query: Get

**Definition:**

```csharp
[HttpGet("{id}")]
public ActionResult<SystemObject> Get(int id)
```

**Description:**

The Get method is an HTTP GET method in the FileObjectController class. It retrieves a SystemObject instance from the SystemObjects list based on the provided id. If the SystemObject with the given id does not exist, it returns a NotFound result.

**Parameters:**

- id (int): The identifier of the SystemObject to retrieve.

**Returns:**

An ActionResult<SystemObject> that contains the SystemObject instance if it exists. If no such object exists, it returns a NotFound result.

**Usage:**

This method is intended to be used as an endpoint in an API. It can be called by making a GET request to the /{id} path of the API, where {id} is the identifier of the SystemObject to retrieve.

**Example:**

```
GET /systemobject/1

RESPONSE:
{
    "Id": 1,
    "Name": "home",
    "Date": 10101000000,
    "Type": "dir",
    "ParentId": 0
}
```

### Method: AddDirectory

**Definition:**

```csharp
public static void AddDirectory(DirectoryObject file)
```

**Description:**

The AddDirectory method is a static method in the SystemObjectService class. It adds a new DirectoryObject to the SystemObjects list, assigns it a unique Id, serializes the updated SystemObjects list to JSON, and writes it to a file.

**Parameters:**

- file (DirectoryObject): The DirectoryObject to add to the SystemObjects list.

**Returns:**

This method does not return a value.

**Side Effects:**

Modifies the SystemObjects list by adding a new DirectoryObject.
Writes the updated SystemObjects list to a file in JSON format.
Outputs a message to the console indicating that a new directory has been added.

**Usage:**

```csharp
DirectoryObject newDirectory = new DirectoryObject { /* initialization */ };
SystemObjectService.AddDirectory(newDirectory);
```

### Method: CreateDirectory

**Definition:**

```csharp
[HttpPost("postdir")]
public IActionResult CreateDirectory(DirectoryObject file)
```

**Description:**

The CreateDirectory method is an HTTP POST method in the FileObjectController class. It creates a new DirectoryObject in the SystemObjects list using the provided file parameter.

**Parameters:**

- file (DirectoryObject): The DirectoryObject to add to the SystemObjects list.

**Returns:**

An IActionResult that represents the result of the POST operation. If the operation is successful, it returns a CreatedAtAction result that includes the route values for the new DirectoryObject.

**Usage:**

This method is intended to be used as an endpoint in an API. It can be called by making a POST request to the /postdir path of the API, with a DirectoryObject in the request body.

**Example:**

```
POST /systemobject/postdir
Content-Type: application/json

{
  "name": "New Directory",
  "type": "dir",
  "parentId": 0
}
```

### Method: AddTextFile

**Definition:**

```csharp
public static void AddTextFile(TextFileObject file)
```

**Description:**

The AddTextFile method is a static method in the SystemObjectService class. It adds a new TextFileObject to the SystemObjects list, assigns it a unique Id, serializes the updated SystemObjects list to JSON, and writes it to a file.

**Parameters:**

- file (TextFileObject): The TextFileObject to add to the SystemObjects list.

**Returns:**

This method does not return a value.

**Side Effects:**

Modifies the SystemObjects list by adding a new TextFileObject.
Writes the updated SystemObjects list to a file in JSON format.
Outputs a message to the console indicating that a new text file has been added.

**Usage:**

```csharp
TextFileObject newTextFile = new TextFileObject { /* initialization */ };
SystemObjectService.AddTextFile(newTextFile);
```

### Query: CreateText

**Definition:**

```csharp
[HttpPost("posttxt")]
public IActionResult CreateText(TextFileObject file)
```

**Description:**

The CreateText method is an HTTP POST method in the FileObjectController class. It creates a new TextFileObject in the SystemObjects list using the provided file parameter.

**Parameters:**

- file (TextFileObject): The TextFileObject to add to the SystemObjects list.

**Returns:**

An IActionResult that represents the result of the POST operation. If the operation is successful, it returns a CreatedAtAction result that includes the route values for the new TextFileObject.

**Usage:**

This method is intended to be used as an endpoint in an API. It can be called by making a POST request to the /posttxt path of the API, with a TextFileObject in the request body.

**Example:**

```
POST /systemobject/posttxt
Content-Type: application/json

{
  "name": "New Text File",
  "type": "txt",
  "content": "This is the content of the text file.",
  "parentId": 0
}
```

### Method: UpdateDIR

**Definition:**

```csharp
public static void UpdateDIR(int id, DirectoryObject updatedDirectory)
```

**Description:**

The UpdateDIR method is a static method in the SystemObjectService class. It updates an existing DirectoryObject in the SystemObjects list with new data from updatedDirectory, based on the provided id.

**Parameters:**

- id (int): The identifier of the DirectoryObject to update.
- updatedDirectory (DirectoryObject): The DirectoryObject containing the new data.

**Returns:**

This method does not return a value.

**Side Effects:**

Modifies the SystemObjects list by updating an existing DirectoryObject.
Writes the updated SystemObjects list to a file in JSON format.
Outputs a message to the console indicating that a directory has been updated.

**Usage:**

```csharp
DirectoryObject updatedDirectory = new DirectoryObject { /* initialization */ };
SystemObjectService.UpdateDIR(1, updatedDirectory);
```

### Query: UpdateDIR

**Definition:**

```csharp
[HttpPut("{id}")]
public IActionResult UpdateDIR(int id, DirectoryObject updatedDirectory)
```

**Description:**

The UpdateDIR method is an HTTP PUT method in the FileObjectController class. It updates an existing DirectoryObject in the SystemObjects list with new data from updatedDirectory, based on the provided id.

**Parameters:**

- id (int): The identifier of the DirectoryObject to update.
- updatedDirectory (DirectoryObject): The DirectoryObject containing the new data.

**Returns:**

An IActionResult that represents the result of the PUT operation. If the operation is successful, it returns a NoContent result. If no DirectoryObject with the given id exists, it returns a NotFound result.

**Usage:**

This method is intended to be used as an endpoint in an API. It can be called by making a PUT request to the /{id} path of the API, with a DirectoryObject in the request body.

**Example:**

```
PUT /systemobject/putdir/1
Content-Type: application/json

{
  "name": "Updated Directory",
  "parentId": 0,
  "id": 1
}
```

### Method: UpdateTXT

**Definition:**

```csharp
public static void UpdateTXT(int id, TextFileObject updatedTextFile)
```

**Description:**

The UpdateTXT method is a static method in the SystemObjectService class. It updates an existing TextFileObject in the SystemObjects list with new data from updatedTextFile, based on the provided id.

**Parameters:**

- id (int): The identifier of the TextFileObject to update.
- updatedTextFile (TextFileObject): The TextFileObject containing the new data.

**Returns:**

This method does not return a value.

**Side Effects:**

Modifies the SystemObjects list by updating an existing TextFileObject.
Writes the updated SystemObjects list to a file in JSON format.
Outputs a message to the console indicating that a text file has been updated.

**Usage:**

```csharp
TextFileObject updatedTextFile = new TextFileObject { /* initialization */ };
SystemObjectService.UpdateTXT(1, updatedTextFile);
```

### Query: UpdateTXT

**Definition:**

```csharp
[HttpPut("{id}")]
public IActionResult UpdateTXT(int id, TextFileObject updatedTextFile)
```

**Description:**

The UpdateTXT method is an HTTP PUT method in the FileObjectController class. It updates an existing TextFileObject in the SystemObjects list with new data from updatedTextFile, based on the provided id.

**Parameters:**

- id (int): The identifier of the TextFileObject to update.
- updatedTextFile (TextFileObject): The TextFileObject containing the new data.

**Returns:**

An IActionResult that represents the result of the PUT operation. If the operation is successful, it returns a NoContent result. If no TextFileObject with the given id exists, it returns a NotFound result.

**Usage:**

This method is intended to be used as an endpoint in an API. It can be called by making a PUT request to the /{id} path of the API, with a TextFileObject in the request body.

**Example:**

```
PUT /systemobject/puttxt/1
Content-Type: application/json

{
  "name": "Updated Text File",
  "parentId": 0,
  "content": "This is the updated content of the text file.",
  "id": 1
}
```

### Method: Delete

**Definition:**

```csharp
public static void Delete(int id)
```

**Description:**

The Delete method is a static method in the SystemObjectService class. It removes a SystemObject from the SystemObjects list based on the provided id.

**Parameters:**

- id (int): The identifier of the SystemObject to remove.

**Returns:**

This method does not return a value.

**Side Effects:**

Modifies the SystemObjects list by removing a SystemObject.
Writes the updated SystemObjects list to a file in JSON format.
Outputs a message to the console indicating that a SystemObject has been removed.

**Usage:**

```csharp
SystemObjectService.Delete(1);
```

### Query: Delete

**Definition:**

```csharp
[HttpDelete("{id}")]
public IActionResult Delete(int id)
```

**Description:**

The Delete method is an HTTP DELETE method in the FileObjectController class. It removes a SystemObject from the SystemObjects list based on the provided id. If the SystemObject with the given id does not exist, it returns a NotFound result.

**Parameters:**

- id (int): The identifier of the SystemObject to remove.

**Returns:**

An IActionResult that represents the result of the DELETE operation. If the operation is successful, it returns a NoContent result. If no SystemObject with the given id exists, it returns a NotFound result.

**Usage:**

This method is intended to be used as an endpoint in an API. It can be called by making a DELETE request to the /{id} path of the API, where {id} is the identifier of the SystemObject to remove.

**Example:**

```
DELETE /systemobject/1
```

### Method: ScrapeGit

**Definition:**

```csharp
public Task<List<RepositoryModel>> ScrapeGit()
```

**Description:**

The ScrapeGit method is an asynchronous method in the ScrapeGit class. It scrapes GitHub repositories and returns a list of RepositoryModel objects. Each RepositoryModel object contains the name, URL, and description of a GitHub repository.

**Returns:**

A Task<List<RepositoryModel>> that represents the asynchronous operation. The task result contains a list of RepositoryModel objects. If no repositories are found, it returns an empty list.

**Usage:**

```csharp
List<RepositoryModel> repositories = await ScrapeGit();
```

### Method: Scrape

**Definition:**

```csharp
[HttpGet("scrape")]
public async Task<IActionResult> Scrape()
```

**Description:**

The Scrape method is an asynchronous HTTP GET method in the APIController class. It calls the Scrape method from the ScrapeGit class to retrieve a list of RepositoryModel objects. If the result is null, it initializes an empty list and logs a message to the console.

**Returns:**

An IActionResult that contains a list of RepositoryModel objects. If no repositories are found, it returns an empty list.

**Usage:**

This method is intended to be used as an endpoint in an API. It can be called by making a GET request to the /scrape path of the API.

**Example:**

```
GET /api/scrape

RESPONSE:
[
  {
    "name": "repository1",
    "url": "https://github.com/user/repository1",
    "description": "Sample description of scraped repository1"
  },
  {
    "name": "repository2",
    "url": "https://github.com/user/repository2",
    "description": "Sample description of scraped repository2"
  }
]
```
