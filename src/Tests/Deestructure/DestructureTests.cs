﻿using Ploeh.AutoFixture.Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using With;
using With.Destructure;
using With.Rubyfy;
using Xunit;
using Xunit.Extensions;

namespace Tests.Deestructure
{
    public class DestructureTests
    {
        public class MyClass
        {
            public string A_Property { get; set; }
            public string B_Field;
            private string _methodvalue;
            public string GetC_Method()
            {
                return _methodvalue;
            }
            public void SetC_Method(string value)
            {
                _methodvalue = value;
            }
        }
        public class MyClass0
        {
            public string A;
            public string B;
            public string C;
        }

        public class MyClass1
        {
            public string A;
            public int B;
            public string C;
        }

        public class MyClass2
        {
            public string A;
            public int B;
            public int C;
        }
        private static int Match(object instance)
        {
            int result = Switch.Match<object, int>(instance)
                .Fields((string a, string b, string c) => 1)
                .Fields((string a, int b, string c) => 2)
                .Fields((string a, string b, int c) => 3)
                .Fields((string a, int b, int c) => 4);
            return result;
        }

        [Theory, AutoData]
        public void Should_match_the_first_case(
            MyClass0 instance)
        {
            int result = Match(instance);
            Assert.Equal(1, result);
        }

        [Theory, AutoData]
        public void Should_match_the_second_case(
            MyClass1 instance)
        {
            int result = Match(instance);
            Assert.Equal(2, result);
        }

        [Theory, AutoData]
        public void Should_match_the_forth_case(
            MyClass2 instance)
        {
            int result = Match(instance);
            Assert.Equal(4, result);
        }
    }
}
