


# taskTracker
## Welcome to the taskTracker API 
This API, built with ASP.Net CORE 1.0 allows users to do the following:
1. Create a new task.
1. Update a task's Name, Description and Status.
1. Request a list of tasks by status.

## System requirements 

* .NET Core [installed](https://www.microsoft.com/net/core#macos).
* [Visual Studio Community Edition](https://www.visualstudio.com/vs/community/) installed for existing Windows users.

Next: Fork or clone this repository. Open code in Visual Studio; then, open the `Package Manager` console and run the following command sequence:
`Add-Migration Name`
`Update-Database`
### How to use the TaskTracker API 

### Get all Tasks 
GET ```http://localhost:5000/api/values/```

### Get Task by its ID 
GET ```http://localhost:5000/api/values/id```

### Edit a single task 
PUT ```http://localhost:5000/api/values/5```

#### Create a new task 
POST ```http://localhost:5000/api/values/```

Sample JSON format for Postman returned from Get All Tasks 
```[
  {
    "id": 4,
    "name": "Chores",
    "description": "Things to do today",
    "status": 0,
    "completedOn": "0001-01-01T00:00:00"
  },
  {
    "id": 5,
    "name": "Chore Turn",
    "description": "And end of relationship alternative",
    "status": 1,
    "completedOn": "0001-01-01T00:00:00"
  },
  {
    "id": 7,
    "name": "Moar Chores",
    "description": "Things to do this week, applying for jobs",
    "status": 0,
    "completedOn": "0001-01-01T00:00:00"
  },
  {
    "id": 8,
    "name": "Testing Statuses",
    "description": "This is how i'm trying to test a status",
    "status": 0,
    "completedOn": "0001-01-01T00:00:00"
  }
]```
