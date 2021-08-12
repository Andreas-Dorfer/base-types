using FsCheck;
using System;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types with a length range.
    /// </summary>
    public static class MinMaxLengthArbitrary
    {
        /// <summary>
        /// Creates an arbitrary.
        /// </summary>
        /// <typeparam name="TBaseType">The base type.</typeparam>
        /// <param name="minLength">The minimal length.</param>
        /// <param name="maxLength">The maximal length.</param>
        /// <param name="creator">The base type's creator.</param>
        /// <returns>The arbitrary.</returns>
        public static MinMaxLengthArbitrary<TBaseType> Create<TBaseType>(int minLength, int maxLength, Func<string, TBaseType> creator) where TBaseType : IBaseType<string> => new(minLength, maxLength, creator);
    }

    /// <summary>
    /// Arbitrary for string base types with a length range.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class MinMaxLengthArbitrary<TBaseType> : StringArbitrary<TBaseType> where TBaseType : IBaseType<string>
    {
        /// <param name="minLength">The minimal length.</param>
        /// <param name="maxLength">The maximal length.</param>
        /// <param name="creator">The base type's creator.</param>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="minLength"/> is negative or <paramref name="maxLength"/> is smaller than <paramref name="minLength"/>.</exception>
        public MinMaxLengthArbitrary(int minLength, int maxLength, Func<string, TBaseType> creator) : base(creator)
        {
            if (minLength < 0) throw new ArgumentOutOfRangeException(nameof(minLength), minLength, "Minimal length must be at least 0.");
            if (maxLength < minLength) throw new ArgumentOutOfRangeException(nameof(maxLength), maxLength, "Maximal length must be larger than the minimal length.");

            MinLength = minLength;
            MaxLength = maxLength;
        }

        /// <summary>
        /// The minimal length.
        /// </summary>
        protected int MinLength { get; }

        /// <summary>
        /// The maximal length.
        /// </summary>
        protected int MaxLength { get; }

        /// <summary>
        /// Filters too short or too long values.
        /// </summary>
        /// <param name="value">The value to check.</param>
        /// <returns>True, if the value is valid.</returns>
        protected override bool Filter(string value) => value is not null && value.Length >= MinLength && value.Length <= MaxLength;

        /// <inheritdoc/>
        public override Gen<TBaseType> Generator => StringGeneration.Generate(MinLength, MaxLength, Creator);
    }
}
