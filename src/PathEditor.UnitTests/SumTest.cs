using PathEditor.Core;
using Xunit;

namespace PathEditor.UnitTests
{
    public class SumTest
    {
        [Fact]
        public void SuccessTest()
        {
            Assert.Equal(7, new Sum(3, 4).AsInteger());
        }
    }
}