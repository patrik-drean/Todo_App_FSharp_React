namespace todo_api.Workflows

open System
open todo_api.Types

module MemberWorkflows =

    let getAll 
        ( getAllMembers : unit -> Member list )
        =
            getAllMembers

    let findById
        (findById : int -> Member option)
        (id : int)
        =
            findById id  

    let findByEmail 
        (findByEmail : string -> Member option)
        (email : string)
        =
            findByEmail email

    let save
        (save : Member -> unit)
        (firstName : string)
        (lastName : string)
        (email : string)
        (planId : string)
        =
            let memberToSave = { Id = Random().Next(); FirstName = firstName; LastName = lastName; Email = email; PlanId = planId}
            save memberToSave    
