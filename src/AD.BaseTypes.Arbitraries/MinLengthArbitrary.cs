using FsCheck;
using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types with a minimal range.
    /// </summary>
    public static class MinLengthArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="minLength">The minimal length.</param>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static MinLengthArbitrary<TBaseType> Create<TBaseType>(int minLength, Func<string, TBaseType> creator) where TBaseType : IBaseType<string> => new(minLength, creator);
    }

    /// <summary>
    /// Arbitrary for string base types with a minimal range.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class MinLengthArbitrary<TBaseType> : StringArbitrary<TBaseType> where TBaseType : IBaseType<string>
    {
        /// <param name="minLength">The minimal length.</param>
        /// <param name="creator">The base type's creator.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="minLength"/> is negative.</exception>
        public MinLengthArbitrary(int minLength, Func<string, TBaseType> creator) : base(creator)
        {
            if (minLength < 0) throw new ArgumentOutOfRangeException(nameof(minLength), minLength, "Minimal length must be at least 0.");
            MinLength = minLength;
        }

        /// <summary>
        /// The minimal length.
        /// </summary>
        protected int MinLength { get; }

        /// <summary>
        /// Filters too short values.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True, if the value is valid.</returns>
        protected override bool Filter(string value) => value is not null && value.Length >= MinLength;

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator =>
            Gen.Sized(i => StringGeneration.Generate(MinLength, MinLength + i, Creator));
    }
}
