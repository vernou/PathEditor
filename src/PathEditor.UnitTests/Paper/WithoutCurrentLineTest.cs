using System;
using System.Collections.Generic;
using PathEditor.Core.Paper;
using Xunit;

namespace PathEditor.UnitTests.Paper
{
    public sealed class WithoutCurrentLineTest
    {
        public static IEnumerable<object[]> RemoveCurrentLineData()
        {
            var nl = Environment.NewLine;
            //Empty
            yield return new object[] { string.Empty, 0, string.Empty, 0 };
            //Cursor at the start, remove first line
            yield return new object[] { $"line1{nl}line2{nl}line3{nl}line4", 0, $"line2{nl}line3{nl}line4", 0 };
            //Cursor at the first line, remove first line
            yield return new object[] { $"line1{nl}line2{nl}line3{nl}line4", 3, $"line2{nl}line3{nl}line4", 0 };
            //Cursor at the second line, remove the second line
            yield return new object[] { $"line1{nl}line2{nl}line3{nl}line4", 10, $"line1{nl}line3{nl}line4", 7 };
            //Cursor at the end, remove the last line
            yield return new object[] { $"line1{nl}line2{nl}line3{nl}line4", 26, $"line1{nl}line2{nl}line3{nl}", 21 };
        }

        [Theory]
        [MemberData(nameof(RemoveCurrentLineData))]
        public void RemoveCurrentLine(string text, int cursor, string expectedText, int expectedCursor)
        {
            var paper = new WithoutCurrentLine(new TextOf(text, cursor));
            Assert.Equal(expectedText, paper.Text);
            Assert.Equal(expectedCursor, paper.Cursor);
        }
    }
}