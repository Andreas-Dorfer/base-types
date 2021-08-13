namespace AD.BaseTypes

open System

module BaseType =

    let inline create<'baseType, 'wrapped when 'baseType :> IBaseType<'wrapped> and 'baseType : (static member Create: 'wrapped -> 'baseType)> value =
        try
            (^baseType : (static member Create: 'wrapped -> 'baseType) value) |> Ok
        with
        | :? ArgumentException as exn -> exn.Message |> Error
