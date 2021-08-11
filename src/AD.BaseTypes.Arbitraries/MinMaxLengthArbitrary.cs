using FsCheck;
using System;
using System.Linq;

namespace AD.BaseTypes.Arbitraries
{
    /// <summary>
    /// Arbitrary for string base types with a length range.
    /// </summary>
    /// <typeparam name="TBaseType"></typeparam>
    public class MinMaxLengthArbitrary<TBaseType> : StringArbitrary<TBaseType> where TBaseType : IValue<string>
    {
        /// <param name="minLength">The minimal length.</param>
        /// <param name="maxLength">The maximal length.</param>
        /// <param name="creator">The base type's creator.</param>
        /// <exception cref="ArgumentException"><paramref name="maxLength"/> is smaller than <paramref name="minLength"/>.</exception>
        public MinMaxLengthArbitrary(int minLength, int maxLength, Func<string, TBaseType> creator) : base(creator)
        {
            if (maxLength < minLength) throw new ArgumentException("Invalid length range.");

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
        public override Gen<TBaseType> Generator =>
            Gen.Choose(MinLength, MaxLength)
            .SelectMany(length => Gen.ArrayOf(length, Arb.Generate<char>()))
            .Select(_ => Creator(new string(_)));
    }
}
