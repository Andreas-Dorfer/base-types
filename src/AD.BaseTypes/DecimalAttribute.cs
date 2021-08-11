﻿using System;

namespace AD.BaseTypes
{
    /// <summary>
    /// Decimal wrapper.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class DecimalAttribute : Attribute, IBaseType<decimal>
    { }
}
