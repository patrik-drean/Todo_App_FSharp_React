namespace TodoApi.Logic

open System
open TodoApi.Types

module MemberName = 
    let capitalizeFirstLetter (name : string) : string =
        failwith "not-implemented"

    let trim (name : string) : string =
        name.Trim()

    let toLower (name : string) : string =
        name.ToLower()

    let removeEmptySpaces (name : string) : string =
        name.Replace(" ", "")        

    let format (name : string) : string = failwith "not-implemented"
