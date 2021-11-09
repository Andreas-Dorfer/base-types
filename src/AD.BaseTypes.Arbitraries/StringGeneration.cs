namespace AD.BaseTypes.Arbitraries
{
    static class StringGeneration
    {
        public static Gen<TBaseType> Generate<TBaseType>(int minLength, int maxLength, Func<string, TBaseType> creator) where TBaseType : IBaseType<string> =>
            Gen.Choose(minLength, maxLength)
            .SelectMany(length => Gen.ArrayOf(length, Arb.Generate<char>()))
            .Select(_ => creator(new(_)));
    }
}
