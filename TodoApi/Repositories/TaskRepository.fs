namespace TodoApi.Repositories

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