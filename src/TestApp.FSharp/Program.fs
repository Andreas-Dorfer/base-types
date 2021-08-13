// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open AD.BaseTypes.FSharp
open TestApp

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message

    match "abc" |> BaseType.create<MyMaxLength, _> with
    | Ok (BaseType.Value str) -> printf "%s" str
    | Error msg -> printf "%s" msg

    0 // return an integer exit code