namespace todo_api.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open todo_api
open todo_api.Types
open todo_api.Workflows
open todo_api.Repositories
open Microsoft.AspNetCore.Http
open Microsoft.AspNetCore.Mvc
open System.Web.Http
open Newtonsoft.Json

[<CLIMutable>]
type MemberModel = {
    FirstName : string
    LastName : string
    Email : string
    PlanId : string
}   

[<Route("api/[controller]")>]
[<ApiController>]
type MembersController () =
    inherit ControllerBase()

    [<HttpGet>]
    member this.Get() =
        let members : Member[] = Dependencies.getAllMembersWorkflow () |> Array.ofList
        ActionResult<Member[]>(members) 

    [<HttpGet("{id}")>]
    member this.Get(id:int) : ActionResult =
        let memberFound = Dependencies.findMemberById id
       
        match memberFound with
        | Some m -> this.Ok(m) :> ActionResult
        | None -> this.NotFound() :> ActionResult

    [<HttpGet("email/{email}")>]
    member this.Get(email:string) : ActionResult =
        let memberFound = Dependencies.findMemberByEmail email
       
        match memberFound with
        | Some m -> this.Ok(m) :> ActionResult
        | None -> this.NotFound() :> ActionResult    

    [<HttpPost>]
    member this.Post([<FromBody>] memberToSave:MemberModel) =
        Dependencies.saveMemberWorkflow 
            memberToSave.FirstName
            memberToSave.LastName
            memberToSave.Email
            memberToSave.PlanId
        this.Ok() :> ActionResult




