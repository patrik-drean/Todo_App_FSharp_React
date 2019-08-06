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



//[<CLIMutable>]
//type MemberModel = {
//    FirstName : string
//    LastName : string
//    Email : string
//    PlanId : string
//}   



//[<Route("api/[controller]")>]
//[<ApiController>]
//type MembersController () =
    //inherit ControllerBase()

    //[<HttpGet>]
    //member this.Get() =
    //    let members : Member[] = Dependencies.getAllMembersWorkflow () |> Array.ofList
    //    ActionResult<Member[]>(members) 

    //[<HttpGet("{id}")>]
    //member this.Get(id:int) : ActionResult =
    //    let memberFound = Dependencies.findMemberById id
       
    //    match memberFound with
    //    | Some m -> this.Ok(m) :> ActionResult
    //    | None -> this.NotFound() :> ActionResult

    //[<HttpGet("email/{email}")>]
    //member this.Get(email:string) : ActionResult =
    //    let memberFound = Dependencies.findMemberByEmail email
       
    //    match memberFound with
    //    | Some m -> this.Ok(m) :> ActionResult
    //    | None -> this.NotFound() :> ActionResult    

    //[<HttpPost>]
    //member this.Post([<FromBody>] memberToSave:MemberModel) =
        //Dependencies.saveMemberWorkflow 
        //    memberToSave.FirstName
        //    memberToSave.LastName
        //    memberToSave.Email
        //    memberToSave.PlanId
        //this.Ok() :> ActionResult


        



