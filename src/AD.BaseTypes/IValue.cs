namespace AD.BaseTypes
{
    /// <summary>
    /// Common interface for all base types.
    /// </summary>
    /// <typeparam name="T">The wrapped value's type.</typeparam>
    public interface IValue<T>
    {
        /// <summary>
        /// The wrapped Value.
        /// </summary>
        T Value { get; }
    }
}
