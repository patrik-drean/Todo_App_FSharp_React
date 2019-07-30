﻿namespace TodoApi.Controllers

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
type MemberModel = {
    FirstName : string
    LastName : string
    Email : string
    PlanId : string
}  

[<Route("api/[controller]")>]
[<ApiController>]
type TasksController () =
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

    [<HttpPost>]
    member this.Post([<FromBody>] memberToSave:MemberModel) =
        Dependencies.saveMemberWorkflow 
            memberToSave.FirstName
            memberToSave.LastName
            memberToSave.Email
            memberToSave.PlanId
        this.Ok() :> ActionResult




