namespace TodoApi.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open TodoApi
open TodoApi.Types
open TodoApi.Workflows
open TodoApi.Repositories
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc
open System.Web.Http
open Newtonsoft.Json

[<CLIMutable>]
type TaskModel = {
    Id : int
    Description : string
}   

[<Route("api/[controller]")>]
[<ApiController>]
type TasksController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let tasks : Task[] = Dependencies.getAllTasks () |> Array.ofList
        ActionResult<_>(tasks) 

    [<HttpGet("{id}")>]
    member this.Get(id:int) =
        let task: Task Option = Dependencies.findTaskById id

        match task with
        | Some t -> this.Ok(t) :> ActionResult
        | None -> this.NotFound() :> ActionResult
        
    [<HttpPost>]
    member this.Post([<FromBody>] newTask:TaskModel) =
        Dependencies.addTaskWorkflow 
            newTask.Id 
            newTask.Description
        this.Ok() :> ActionResult

    [<HttpDelete("{id}")>]
    member this.Delete(id:int) =
        Dependencies.deleteTaskWorkflow id
        this.Ok() :> ActionResult





