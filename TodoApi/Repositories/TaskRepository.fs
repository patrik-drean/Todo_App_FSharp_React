﻿namespace TodoApi.Repositories

open System.Collections.Generic
open TodoApi.Types
open FSharp.Data.Sql

module TaskRepository =

    [<CLIMutable>]
    type TaskDto = {
        Id: int
        Description: string
    }

    let toDomain (dto: TaskDto): Task = {
        Id = dto.Id
        Description = dto.Description
    }

    let getAll (readData: string -> obj -> IEnumerable<TaskDto>): Task list  = 

        let sql = "select id, description from tasks;"
        let emptyParams = [Database.p "" ""] |> dict

        let results = readData sql emptyParams

        results 
        |> List.ofSeq
        |> List.map toDomain

    let findById (readData: string -> obj -> IEnumerable<TaskDto>) (id:int) : Task option =

        let sql = """
            select id, description
            from tasks
            where id = @id
        """
        let dbParams = [Database.p "id" id] |> dict

        let results = readData sql dbParams

        results 
        |> List.ofSeq
        |> List.map toDomain
        |> List.tryHead

    let add writeData (newTask:Task) =
        
        let sql = """
        insert into tasks
        values(@id, @description)
        """
        
        let dbParams = ([
            Database.p "id" newTask.Id
            Database.p "description" newTask.Description
            ]
            |> dict
        )
        
        writeData sql dbParams

        //namespace TodoApi.Repositories

        //open System.Collections.Generic
        //open TodoApi.Types
        //open FSharp.Data.Sql

        //module MemberRepository =

            //[<CLIMutable>]
            //type MemberDto = {
            //    Id : int
            //    FirstName : string
            //    LastName : string
            //    Email : string
            //    PlanId : string 
            //}

            //let toDomain (dto : MemberDto) : Member =
            //    {
            //        Id = dto.Id
            //        FirstName = dto.FirstName
            //        LastName = dto.LastName
            //        Email = dto.Email
            //        PlanId = dto.PlanId
            //    }

            ////todo: exception when trying to insert duplicate email... handle graciously
            //let save writeData (memberToSave : Member) : unit =
            //    let query = """
            //        insert into members
            //        (id, first_name, last_name, email, plan_id)
            //        values
            //        (@id, @firstName, @lastName, @email, @planId);
            //    """
            //    writeData
            //        query
            //        ([
            //            Database.p "id" (memberToSave.Id)
            //            Database.p "firstName" memberToSave.FirstName 
            //            Database.p "lastName" memberToSave.LastName
            //            Database.p "email" memberToSave.Email
            //            Database.p "planId" memberToSave.PlanId
            //        ] |> dict)

            //let delete writeData (id : int) : unit =
            //    let query = """
            //        delete from members
            //        where id = @id
            //    """
            //    writeData
            //        query
            //        ([
            //            Database.p "id" id
            //        ] |> dict)        

            
                
            //let findById (readData: string -> obj -> IEnumerable<MemberDto>) (id : int) : Member option =

            //    let selectSql ="""
            //        select id, first_name as FirstName, last_name as LastName, email, plan_id as PlanId
            //        from members
            //        where id = @id;
            //        """
            //    readData selectSql ([Database.p "id" id] |> dict) 
            //    |> List.ofSeq 
            //    |> List.map toDomain 
            //    |> List.tryHead

            //let findByEmail (readData: string -> obj -> IEnumerable<MemberDto>) (email : string) : Member option =

            //    let selectSql ="""
            //        select id, first_name as FirstName, last_name as LastName, email, plan_id as PlanId
            //        from members
            //        where email = @email;
            //        """
            //    readData selectSql ([Database.p "email" email] |> dict) 
            //    |> List.ofSeq 
            //    |> List.map toDomain 
            //    |> List.tryHead    


            //let getAll (readData: string -> obj -> IEnumerable<MemberDto>) : Member list =

                //let selectSql = "select id, first_name as firstName, last_name as lastName, email, plan_id as planId from members;"
                //let results = readData selectSql ([Database.p "" ""] |> dict)

                //results 
                //|> List.ofSeq
                //|> List.map toDomain
