using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using PathEditor.Core;
using Xunit;

namespace PathEditor.UnitTests
{
    public sealed class MainWindowViewModelTest
    {
        public static IEnumerable<object[]> FormatPathData()
        {
            yield return new object[] { string.Empty, string.Empty };
            yield return new object[] { @"C:\TMP\Path1;C:\TMP\Path2;C:\TMP\Path3", $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;{Environment.NewLine}C:\TMP\Path3;" };
            yield return new object[] { @"C:\TMP\Path1;C:\TMP\Path2;C:\TMP\Path3;", $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;{Environment.NewLine}C:\TMP\Path3;"};
        }

        [Theory]
        [MemberData(nameof(FormatPathData))]
        public void FormatPath(string path, string formatedPath)
        {
            Assert.Equal(formatedPath,
                new MainWindowViewModel(
                    new EnvironmentVariablePathInMemory(path)
                ).Path
            );
        }

        public static IEnumerable<object[]> SaveData()
        {
            yield return new object[] { string.Empty, string.Empty };
            yield return new object[] { $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;", @"C:\TMP\Path1;C:\TMP\Path2;" };
            yield return new object[] { $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;{Environment.NewLine}C:\TMP\Path3", @"C:\TMP\Path1;C:\TMP\Path2;C:\TMP\Path3;" };
        }

        [Theory]
        [MemberData(nameof(SaveData))]
        public void Sage(string formatedPath, string path)
        {
            var evpim = new EnvironmentVariablePathInMemory();
            new MainWindowViewModel(evpim).SaveCommand.Execute(formatedPath);
            Assert.Equal(path, evpim.Value);
        }

        public static IEnumerable<object[]> SetPathData()
        {
            yield return new object[] { string.Empty, string.Empty };
            yield return new object[] { $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;", $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;" };
            yield return new object[] { $@"C:\TMP\Path1;C:\TMP\Path2;", $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;" };
        }

        [Theory]
        [MemberData(nameof(SetPathData))]
        public void SetPath(string changed, string expected)
        {
            var vm = new MainWindowViewModel(new EnvironmentVariablePathInMemory());
            vm.Path = changed;
            Assert.Equal(expected, vm.Path);
        }
    }
}