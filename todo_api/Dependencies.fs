namespace todo_api

open todo_api.Repositories
open todo_api.Workflows
open System.Collections.Generic

module Dependencies =
    let [<Literal>] connectionString = @"Data Source=" + __SOURCE_DIRECTORY__ + @"/Repositories/Scripts/fsharpjumpstart.db;Version=3"

    let reader: string -> obj -> IEnumerable<_> =  Database.readData connectionString

    let writer: string -> obj -> unit = Database.writeData connectionString

    let getAllMembers _ = MemberRepository.getAll reader
    let findMemberById = MemberRepository.findById reader
    let findMemberByEmail = MemberRepository.findByEmail reader
    let saveMember = MemberRepository.save writer

    let getAllMembersWorkflow = MemberWorkflows.getAll getAllMembers
    let findMemberByIdWorkflow = MemberWorkflows.findById findMemberById
    let findMemberByEmailWorkflow = MemberWorkflows.findByEmail findMemberByEmail
    let saveMemberWorkflow = MemberWorkflows.save saveMember

   
