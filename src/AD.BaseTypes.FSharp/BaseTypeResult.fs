/// Module for base type results.
module AD.BaseTypes.FSharp.BaseTypeResult

/// Binds the result.
let bind binder = Result.bind (BaseType.bind binder)

/// Maps the result.
let map mapper = Result.bind (BaseType.map mapper)

/// Binds the result's Ok value.
let bindValue binder = Result.bind (BaseType.mapValue binder)

/// Maps the result's Ok value.
let mapValue mapper = Result.map (BaseType.mapValue mapper)
