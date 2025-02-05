﻿using System;
using With;
using Xunit;
using System.Text.RegularExpressions;

namespace Tests
{
    public class MatchFuncTests
    {
        private string DoMatch(int v)
        {
            return Switch.Match<int, string>(v)
                .Case(1, () => "One!")
                .Case(new[] { 2, 3, 5, 7, 11 }, p => "This is a prime!")
                .Case(13.To(19), "A teen")
                .Case(i => i == 42, "Meaning of life")
                .Case(i => i == 52, i => "Some other number")
                .Else(_ => "Ain't special");
        }

        [Fact]
        public void Test_one_using_different_syntax()
        {
            string result = Switch.Match(1,
                new[] { 1 }, _ => "One!",
                new[] { 2, 3, 5, 7, 11 }, _ => "This is a prime!",
                13.To(19), _ => "A teen")
                .Else(_ => "Ain't special");
            Assert.Equal("One!", result);
        }

        [Fact]
        public void Test_one()
        {
            Assert.Equal("One!", DoMatch(1));
        }
        [Fact]
        public void Test_prime()
        {
            Assert.Equal("This is a prime!", DoMatch(7));
        }
        [Fact]
        public void Test_teen()
        {
            Assert.Equal("A teen", DoMatch(17));
        }
        [Fact]
        public void Test_other()
        {
            Assert.Equal("Ain't special", DoMatch(200));
            Assert.Equal("Ain't special", DoMatch(29));
        }
        [Fact]
        public void Test_meaning_of_life()
        {
            Assert.Equal("Meaning of life", DoMatch(42));
        }
        [Fact]
        public void Test_does_not_match()
        {
            Assert.Throws<NoMatchFoundException>(() =>
            {
                Switch.Match<int, string>(2)
                    .Case(1, () => "One!").Value();
            });
        }

        [Fact]
        public void Regex_find_first()
        {
            var instance = "m";

            int result = Switch.Match<string, int>(instance)
                .Case("m", m => 1)
                .Case("s", m => 2)
                .Regex("[A-Z]{1}[a-z]{2}\\d{1,}", m => 3);
            Assert.Equal(1, result);
        }

        [Fact]
        public void Regex_find_complicated()
        {
            var instance = "Rio1";

            int result = Switch.Match<string, int>(instance)
                .Case("m", m => 1)
                .Case("s", m => 2)
                .Regex("[A-Z]{1}[a-z]{2}\\d{1,}", m => 3);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Regex_use_match_object()
        {
            var instance = "Rio3";

            int result = Switch.Match<string, int>(instance)
                .Case("m", m => 1)
                .Case("s", m => 2)
                .Regex("[A-Z]{1}[a-z]{2}(\\d{1,})", m => Int32.Parse(m.Groups[1].Value));
            Assert.Equal(3, result);
        }

        [Fact]
        public void Regex_find_complicated_differnt_order()
        {
            var instance = "Rio1";

            int result = Switch.Match<string, int>(instance)
                .Regex("X[a-z]{2}\\d{1,}", 4)
                .Regex("[A-Z]{1}[a-z]{2}\\d{1,}", m => 3)
                .Case("m", m => 1)
                .Case("s", m => 2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void Regex_prepared_Find_complicated()
        {
            var result = Switch.Match<string, int>()
                .Case("m", m => 1)
                .Case("s", m => 2)
                .Regex("x[a-z]{2}\\d{1,}", RegexOptions.IgnoreCase, 4)
                .Regex("[a-z]{1}[a-z]{2}\\d{1,}", RegexOptions.IgnoreCase, m => 3);
            Assert.Equal(3, result.ValueOf("Rio1"));
            Assert.Equal(4, result.ValueOf("Xio1"));
        }

        private int FibR(int i)
        {
            switch (i)
            {
                case 1:
                case 2:
                    return 1;
                default:
                    return FibR(i - 1) + FibR(i - 2);
            }
        }

        private int Fib(int i)
        {
            return Switch.Match<int, int>(i) // Could be better if it could be written as "Switch(i)" 
                .Case(1.To(2), 1)
                .Else(n => Fib(n - 1) + Fib(n - 2));
        }

        [Fact]
        public void Can_write_fib_in_a_different_way()
        {
            Assert.Equal(2, Fib(3));
            Assert.Equal(2, FibR(3));
            Assert.Equal(8, Fib(6));
            Assert.Equal(8, FibR(6));
        }

    }
}

