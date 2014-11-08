using System;
using With;
using Xunit.Extensions;
using Ploeh.AutoFixture.Xunit;
using Xunit;
using System.Collections.Generic;
using System.Linq;
namespace Tests
{
    public class ChainTests
    {
        [Theory,AutoData]
        public void Test(string[] array) 
        {
            Assert.Equal(0.To(array.Length-1).ToArray(), array
                .Chain(s => YieldAppend1(s))
                .Chain(s => Yield(s)).ToArray());
        }

        private IEnumerable<int> Yield(IEnumerable<string> s)
        {
            var i = 0;
            foreach (var item in s)
            {
                yield return i++;
            }
        }

        private IEnumerable<string> YieldAppend1(IEnumerable<string> s)
        {
            foreach (var item in s)
            {
                yield return item + "1";
            }
        }

    }
}
