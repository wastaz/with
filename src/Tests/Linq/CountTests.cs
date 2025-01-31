using Xunit;
using System.Linq;
namespace Tests.Linq
{
    public class CountTests
    {
        private readonly int[] ary = new[] { 1, 2, 4, 2 };
        [Fact]
        public void Test_from_documentation()
        {
            Assert.Equal(4, ary.Count());
            Assert.Equal(2, ary.Count(x => x == 2));
            Assert.Equal(3, ary.Count(x => x % 2 == 0));
        }
    }
}
