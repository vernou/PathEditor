using System;
using System.Collections.Generic;
using System.Text;
using PathEditor.Core.EnvironmentVariablePath;
using Xunit;

namespace PathEditor.UnitTests.EnvironmentVariablePath
{
    public sealed class FormattedProcessEnvironmentVariablePathTest
    {
        public static IEnumerable<object[]> ValueData()
        {
            var nl = Environment.NewLine;
            yield return new object[] { string.Empty, string.Empty, string.Empty };
            yield return new object[]
            {
                string.Empty,
                $@"C:\User\Path1;{nl}C:\User\Path2;{nl}C:\User\Path3",
                $@"C:\User\Path1;{nl}C:\User\Path2;{nl}C:\User\Path3",
            };
            yield return new object[]
            {
                $@"C:\System\Path1;{nl}C:\System\Path2;{nl}C:\System\Path3",
                $@"C:\User\Path1;{nl}C:\User\Path2;{nl}C:\User\Path3",
                $@"C:\System\Path1;{nl}C:\System\Path2;{nl}C:\System\Path3;{nl}C:\User\Path1;{nl}C:\User\Path2;{nl}C:\User\Path3"
            };
            yield return new object[]
            {
                $@"C:\System\Path;{nl}C:\System\Path2;{nl}C:\System\Path3;",
                $@"C:\User\Path1;{nl}C:\User\Path2;{nl}C:\User\Path3;",
                $@"C:\System\Path;{nl}C:\System\Path2;{nl}C:\System\Path3;{nl}C:\User\Path1;{nl}C:\User\Path2;{nl}C:\User\Path3;"
            };
        }

        [Theory]
        [MemberData(nameof(ValueData))]
        public void Value(string formattedSystem, string formattedUser, string expectedFormattedProcess)
        {
            var nl = Environment.NewLine;
            Assert.Equal(expectedFormattedProcess,
                new FormattedProcessEnvironmentVariablePath(
                    new FormattedEnvironmentVariablePathFake(
                        formattedSystem,
                        formattedUser)
                ).Value
            );
        }
    }
}