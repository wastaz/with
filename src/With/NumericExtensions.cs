﻿using System;
using With.RangePlumbing;

namespace With
{
    public static class NumericExtensions
    {
        public static IRange<Int32> To(this Int32 @from, Int32 @to)
        {
            return new Int32Range(@from, @to, 1);
        }
        public static IRange<Int32> To(this Int32 @from, Int32 @to, Int32 step)
        {
            return new Int32Range(@from, @to, step);
        }

        public static IRange<Int64> To(this Int64 @from, Int64 @to)
        {
            return new Int64Range(@from, @to, 1);
        }
        public static IRange<Int64> To(this Int64 @from, Int64 @to, Int64 step)
        {
            return new Int64Range(@from, @to, step);
        }

        public static IRange<Decimal> To(this Decimal @from, Decimal @to)
        {
            return new DecimalRange(@from, @to, 1);
        }
        public static IRange<Decimal> To(this Decimal @from, Decimal @to, Decimal step)
        {
            return new DecimalRange(@from, @to, step);
        }
    }
}
