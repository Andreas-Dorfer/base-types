namespace AD.BaseTypes.Extensions;

/// <summary>
/// Type extensions
/// </summary>
public static class TypeExtensions
{
    /// <summary>
    /// Determines whether <see cref="IBaseType{TBaseType,TWrapped}"/> is implemented by the current <see cref="Type"/>.
    /// </summary>
    /// <param name="type">The type to be verified.</param>
    /// <returns><see langword="true" /> when the type implements the interface.</returns>
    public static bool ImplementsIBaseType(this Type type)
    {
        var baseType = typeof(IBaseType<,>);
        if (type == null || baseType == null) return false;
        return type.GetInterfaces().Any(x => x.Name == baseType.Name && x.Namespace == baseType.Namespace);
    }
}
