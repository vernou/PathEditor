using System;
using System.Collections.Generic;
using System.Linq;
using PathEditor.Core;
using PathEditor.Core.Backup;
using PathEditor.Core.Dialog;
using PathEditor.Core.EnvironmentVariablePath;
using Xunit;

namespace PathEditor.UnitTests
{
    public sealed class MainWindowViewModelTest
    {
        public static IEnumerable<object[]> FormatPathData()
        {
            yield return new object[] { string.Empty, string.Empty };
            yield return new object[] { @"C:\TMP\Path1;C:\TMP\Path2;C:\TMP\Path3", $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;{Environment.NewLine}C:\TMP\Path3;" };
            yield return new object[] { @"C:\TMP\Path1;C:\TMP\Path2;C:\TMP\Path3;", $@"C:\TMP\Path1;{Environment.NewLine}C:\TMP\Path2;{Environment.NewLine}C:\TMP\Path3;" };
        }

        [Theory]
        [MemberData(nameof(FormatPathData))]
        public void FormatPath(string path, string formatedPath)
        {
            Assert.Equal(formatedPath,
                new MainWindowViewModel(
                    new EnvironmentVariablePathInMemory(path),
                    new BackupFake(SaveBackupResult.Cancel)
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
        public void Save(string formatedPath, string path)
        {
            var evpim = new EnvironmentVariablePathInMemory();
            new MainWindowViewModel(
                evpim,
                new BackupFake(SaveBackupResult.Done)
            ).SaveCommand.Execute(formatedPath);
            Assert.Equal(path, evpim.Value);
        }
    }
}