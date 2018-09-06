using System.Collections.Generic;
using PathEditor.Core.Paper;
using Xunit;

namespace PathEditor.UnitTests.Paper
{
    public sealed class MergedTest
    {
        public static IEnumerable<object[]> MergeTextsData()
        {
            //Cursor at 0
            yield return new object[] { "abcd", 0, "ADD", 2, "abADDcd", 0 };
            //Insert at cursor
            yield return new object[] { "abcd", 2, "ADD", 2, "abADDcd", 5 };
            //Insert after cursor
            yield return new object[] { "abcd", 3, "ADD", 2, "abADDcd", 6 };
        }

        [Theory]
        [MemberData(nameof(MergeTextsData))]
        public void MergeTexts(string text, int cursor, string inserted, int at, string expectedText, int expectedCursor)
        {
            var merged = new Merged(new TextOf(text, cursor), inserted, at);
            Assert.Equal(expectedText, merged.Text);
            Assert.Equal(expectedCursor, merged.Cursor);
        }
    }
}