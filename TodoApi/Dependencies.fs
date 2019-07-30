namespace TodoApi

open TodoApi.Repositories
open TodoApi.Workflows
open TodoApi.Types
open System.Collections.Generic

module Dependencies =
    let [<Literal>] connectionString = @"Data Source=" + __SOURCE_DIRECTORY__ + @"/Repositories/Scripts/fsharpjumpstart.db;Version=3" //TODO
    let [<Literal>] connectionString2 = @"Data Source=" + __SOURCE_DIRECTORY__ + @"/Repositories/Scripts/todo.db;Version=3"

    let memberReader: string -> obj -> IEnumerable<_> =  Database.readData connectionString2
    let taskReader: string -> obj -> IEnumerable<_> =  Database.readData connectionString2

    let writer: string -> obj -> unit = Database.writeData connectionString2

    let getAllMembers _ = MemberRepository.getAll memberReader
    let findMemberById = MemberRepository.findById memberReader
    let findMemberByEmail = MemberRepository.findByEmail memberReader
    let saveMember = MemberRepository.save writer

    let getAllMembersWorkflow = MemberWorkflows.getAll getAllMembers
    let findMemberByIdWorkflow = MemberWorkflows.findById findMemberById
    let findMemberByEmailWorkflow = MemberWorkflows.findByEmail findMemberByEmail
    let saveMemberWorkflow = MemberWorkflows.save saveMember

    let getAllTasks _ = TaskRepository.getAll taskReader
    let findTaskById = TaskRepository.findById taskReader

    let getAllTasksWorkflow = TaskWorkflows.getAll getAllTasks
    let findTaskByIdWorkflow = TaskWorkflows.findById findTaskById

   
