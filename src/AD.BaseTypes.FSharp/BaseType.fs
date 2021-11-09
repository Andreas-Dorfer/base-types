/// Module for base types.
module AD.BaseTypes.FSharp.BaseType

open System
open AD.BaseTypes

/// <summary>
/// Creates a base type.
/// </summary>
/// <param name="value">The base type's value.</param>
/// <returns>The created base type or an error message.</returns>
let inline create<'baseType, 'wrapped when 'baseType :> IBaseType<'wrapped> and 'baseType : (static member Create: 'wrapped -> 'baseType)> value =
    try
        (^baseType : (static member Create: 'wrapped -> 'baseType) value) |> Ok
    with
    | :? ArgumentException as exn -> exn.Message |> Error

/// Gets the base type's value.
let value (baseType : #IBaseType<_>) = baseType.Value

/// Gets the base type's value.
let (|Value|) (baseType : #IBaseType<_>) = baseType.Value

/// Binds a base type.
let inline bind binder (baseType : 'baseType) =
    baseType |> value |> binder |> Result.bind create<'baseType, _>

/// Maps a base type.
let inline map mapper (baseType : 'baseType) =
    baseType |> value |> mapper |> create<'baseType, _>

/// Maps the base type's value.
let mapValue mapper = value >> mapper
