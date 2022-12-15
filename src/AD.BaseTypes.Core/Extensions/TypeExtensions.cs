namespace AD.BaseTypes.Extensions;

/// <summary>
/// Type extensions.
/// </summary>
public static class TypeExtensions
{
    static readonly Type BaseType = typeof(IBaseType<,>);

    /// <summary>
    /// Determines whether <see cref="IBaseType{TBaseType,TWrapped}"/> is implemented by the current <see cref="Type"/>.
    /// </summary>
    /// <param name="type">The type to be verified.</param>
    /// <returns><see langword="true" /> when the type implements the interface.</returns>
    public static bool ImplementsIBaseType(this Type type)
    {
        if (type is null) return false;
        return type.GetInterfaces().Any(x => x.Name == BaseType.Name && x.Namespace == BaseType.Namespace);
    }
}
