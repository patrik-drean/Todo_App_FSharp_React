namespace TodoApi.Workflows

open System
open TodoApi.Types

module TaskWorkflows =

    let getAll (getAllMembers : unit -> Task list ) = getAllMembers

    let findById (findTaskById: int -> Task Option) (id:int) = findTaskById id