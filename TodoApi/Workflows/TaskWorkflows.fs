namespace TodoApi.Workflows

open System
open TodoApi.Types

module TaskWorkflows =

    let getAll (getAllMembers : unit -> Task list ) = getAllMembers

    let findById (findTaskById: int -> Task Option) (id:int) = findTaskById id
    
    let add addTask id description = 
        let newTask = {Id = id; Description = description}
        
        addTask newTask
        



    //namespace TodoApi.Workflows

    //open System
    //open TodoApi.Types

    //module MemberWorkflows =

        //let getAll 
        //    ( getAllMembers : unit -> Member list )
        //    =
        //        getAllMembers

        //let findById
        //    (findById : int -> Member option)
        //    (id : int)
        //    =
        //        findById id  

        //let findByEmail 
        //    (findByEmail : string -> Member option)
        //    (email : string)
        //    =
        //        findByEmail email

        //let save
            //(save : Member -> unit)
            //(firstName : string)
            //(lastName : string)
            //(email : string)
            //(planId : string)
            //=
                //let memberToSave = { Id = Random().Next(); FirstName = firstName; LastName = lastName; Email = email; PlanId = planId}
                //save memberToSave    
