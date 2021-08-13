// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open AD.BaseTypes
open TestApp


// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message


    let x : Result<MyMaxLength, _> = "abc" |> BaseType.create


    0 // return an integer exit code