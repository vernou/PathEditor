using System;
using System.Collections.Generic;
using PathEditor.Core.Paper;
using Xunit;

namespace PathEditor.UnitTests.Paper
{
    public sealed class AutoBreakLineTest
    {
        public static IEnumerable<object[]> BreakLineData()
        {
            yield return new object[] { string.Empty, 0, string.Empty, 0 };
            yield return new object[] { $@"C:\TMP\Path1;C:\TMP\Path2;", 0, $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;", 0 };
            yield return new object[] { $@"C:\TMP\Path1;C:\TMP\Path2;", 15, $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;", 15 + Environment.NewLine.Length };
        }

        [Theory]
        [MemberData(nameof(BreakLineData))]
        public void BreakLine(string text, int cursor, string expectedText, int expectedCursor)
        {
            var breakLine = new AutoBreakLine(new TextOf(text, cursor));
            Assert.Equal(expectedText, breakLine.Text);
            Assert.Equal(expectedCursor, breakLine.Cursor);
        }
    }
}