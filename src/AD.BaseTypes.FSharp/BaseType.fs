namespace AD.BaseTypes

open System

/// Module for base types.
module BaseType =

    /// Creates a base type.
    /// <param name="value">The base type's value.</param>
    /// <returns>The created base type or an error message.</returns>
    let inline create<'baseType, 'wrapped when 'baseType :> IBaseType<'wrapped> and 'baseType : (static member Create: 'wrapped -> 'baseType)> value =
        try
            (^baseType : (static member Create: 'wrapped -> 'baseType) value) |> Ok
        with
        | :? ArgumentException as exn -> exn.Message |> Error
