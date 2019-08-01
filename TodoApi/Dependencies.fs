namespace TodoApi

open TodoApi.Repositories
open TodoApi.Workflows
open TodoApi.Types
open System.Collections.Generic

module Dependencies =
    let [<Literal>] connectionString = @"Data Source=" + __SOURCE_DIRECTORY__ + @"/Repositories/Scripts/todo.db;Version=3"

    let reader: string -> obj -> IEnumerable<_> =  Database.readData connectionString

    let writer: string -> obj -> unit = Database.writeData connectionString


    let getAllTasks _ = TaskRepository.getAll reader
    let findTaskById = TaskRepository.findById reader
    let addTask = TaskRepository.add writer

    let getAllTasksWorkflow = TaskWorkflows.getAll getAllTasks
    let findTaskByIdWorkflow = TaskWorkflows.findById findTaskById
    let addTaskWorkflow = TaskWorkflows.add addTask

   
