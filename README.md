# The ***Task Board*** System 📌
## RestSharp API Tests 🧪 ✔️
#### ☑️ ***Task Board*** is a simple information system for managing tasks in a task board. Each task consists of title + description. 
#### ☑️ Tasks are organized in boards, which are displayed as columns (sections): Open, In Progress, Done. 
#### ☑️ Users can view the task board with the tasks, search for tasks by keyword, view task details, create new tasks and edit existing tasks (and move existing tasks from one board to another).
#### ☑️ The app does not have a persistent database storage, so you can reset it by a simple restart 

#### 🔻 The following endpoints are supported:
#### ➡️	GET /api – list all API endpoints
#### ➡️	GET /api/tasks – list all tasks (returns JSON array of tasks)
#### ➡️	GET /api/tasks/id – returns a task by given id
#### ➡️	GET /api/tasks/search/keyword – list all tasks matching given keyword
#### ➡️	GET /api/tasks/board/boardName – list tasks by board name
#### ➡️	POST /api/tasks – create a new task (post a JSON object in the request body, e.g. {"title":"Add Tests", "description":"API + UI tests", "board":"Open"})
#### ➡️	PATCH /api/tasks/id – edit task by id (send a JSON object in the request body, holding the fields to modify, e.g. {"title":"changed title", "board":"Done"})
#### ➡️	DELETE /api/tasks/id – delete task by id
#### ➡️	GET /api/boards – list all boards


==============================================================


![restSharpTestResults](https://user-images.githubusercontent.com/90700181/220651580-08fe1bec-fac0-4920-b860-e5dca18f231a.png)
