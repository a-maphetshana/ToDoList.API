# todo-list-api
-  CRUD API for TODO lists, crafted with .Net Core 5
-  Uses in-memory SQL storage for demo/easy testing, with easy setup to switch.
-  Well-configured to cater for raw sql query excecution with dapper.
-  Supports api versioning
-  Uses xUnit framework for unit tests

## TODO List
A TODO list is a collection of tasks which can be in the state of completed or not completed.

### REST Interface

Get all available tasks 
```http
GET /{version}/todolist
```

Get specific task by id
```http
GET /{version}/todolist/{id}
```

Create a new task 
```http
POST /{version}/todolist
{
  "name": "Get milk for coffee",
  "date": "2021-09-01T16:54:27.712Z"
}
```

Update existing task
```http
PUT /{version}/todolist/{id}
{
  "name": "Get milk for coffee from the canteen",
  "date": "2021-09-01T16:54:27.712Z",
  "isCompleted": false
}
```

Archive existing task
```http
DELETE /{version}/todolist/archive/{id}
```

Restore archived task
```http
DELETE /{version}/todolist/restore/{id}
```

Permanently delete task
```http
DELETE /{version}/todolist/remove/{id}
```

### Data Structures

**ToDoListItem**
```json
{
  "toDoListItemID": 0,
  "name": "Test task 1",
  "date": "2021-09-01T14:54:27.712Z",
  "isCompleted": true,
  "isDeleted": false,
  "createdBy": "anele",
  "createdDate": "2021-09-01T14:54:27.712Z",
  "lastModifiedBy": "anele",
  "lastModifiedDate": "2021-09-01T14:54:27.712Z"
}
```
