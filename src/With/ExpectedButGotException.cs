﻿using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using With.Rubyfy;

namespace With
{
    [Serializable]
    public class ExpectedButGotException : Exception
    {
        public ExpectedButGotException(ExpressionType[] expected, ExpressionType got)
            : this(expected.Map(e => e.ToString()).ToA(), got.ToString())
        {
        }

        public ExpectedButGotException(MemberTypes[] expected, MemberTypes got)
            : this(expected.Map(e => e.ToString()).ToA(), got.ToString())
        {
        }

        public ExpectedButGotException(string[] expected, string got)
            : this(string.Format("Expected {0} but got {1}", string.Join(", ", expected), got))
        {
        }

        private ExpectedButGotException(string message)
            : base(message)
        {
        }

        private ExpectedButGotException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected ExpectedButGotException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}
