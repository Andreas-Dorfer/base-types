namespace AD.BaseTypes.FSharp

/// Module for base type results.
module BaseTypeResult =

    /// Binds the result.
    let inline bind binder = Result.bind (BaseType.bind binder)

    /// Maps the result.
    let inline map mapper = Result.bind (BaseType.map mapper)

    /// Binds the result's Ok value.
    let bindValue binder = Result.bind (BaseType.mapValue binder)

    /// Maps the result's Ok value.
    let mapValue mapper = Result.map (BaseType.mapValue mapper)
