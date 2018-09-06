using System.Collections.Generic;
using PathEditor.Core.Paper;
using Xunit;

namespace PathEditor.UnitTests.Paper
{
    public sealed class ReducedTest
    {
        public static IEnumerable<object[]> ReduceData()
        {
            //Remove two first letters
            yield return new object[] { "abcde", 0, 0, 2, "cde", 0 };
            //Remove three last letters
            yield return new object[] { "abcde", 0, 2, 3, "ab", 0 };
            //Remove before cursor
            yield return new object[] { "abcde", 4, 1, 1, "acde", 3 };
            //Remove between cursor
            yield return new object[] { "abcde", 3, 1, 3, "ae", 1 };
        }

        [Theory]
        [MemberData(nameof(ReduceData))]
        public void Remove(string text, int cursor, int removeAt, int removeLength, string expectedText, int expectedCursor)
        {
            var merged = new Reduced(new TextOf(text, cursor), removeAt, removeLength);
            Assert.Equal(expectedText, merged.Text);
            Assert.Equal(expectedCursor, merged.Cursor);
        }
    }
}