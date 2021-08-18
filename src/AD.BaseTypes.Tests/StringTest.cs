﻿using AD.BaseTypes.Arbitraries;
using FsCheck;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AD.BaseTypes.Tests
{
    [String] public partial record MyString;

    [TestClass]
    public class StringTest : BaseTypeTest<MyString, string>
    {
        protected override Arbitrary<MyString> Arbitrary => new StringArbitrary<MyString>();
    }
}
