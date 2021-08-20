// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open AD.BaseTypes.FSharp
open TestApp

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message

    match "abc" |> BaseType.create<MyMaxLengthString, _> with
    | Ok (BaseType.Value str) -> printf "%s" str
    | Error msg -> printf "%s" msg

    let someWeekenInThe90s = (1995, 1, 1) |> DateTime |> SomeWeekendInThe90s
    let nextDay = someWeekenInThe90s |> BaseType.map (fun a -> a + TimeSpan.FromDays(1.0))
    let nextWeek = someWeekenInThe90s |> BaseType.bind (fun a -> a + TimeSpan.FromDays(7.0) |> Ok)
    let someWeekend = someWeekenInThe90s |> BaseType.mapValue BaseType.create<SomeWeekend, _>

    let x =
        (1995, 1, 1)
        |> DateTime
        |> BaseType.create<SomeWeekendInThe90s, _>
        |> BaseTypeResult.map (fun a -> a + TimeSpan.FromDays(1.0))

    let y =
        (1995, 1, 1)
        |> DateTime
        |> BaseType.create<SomeWeekendInThe90s, _>
        |> BaseTypeResult.bind (fun a -> a + TimeSpan.FromDays(1.0) |> Ok)


    0 // return an integer exit code