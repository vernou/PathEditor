using System;
using System.Collections.Generic;
using PathEditor.Core;
using PathEditor.Core.Backup;
using PathEditor.Core.EnvironmentVariablePath;
using PathEditor.Core.User;
using Xunit;

namespace PathEditor.UnitTests
{
    public sealed class MainWindowViewModelTest
    {
        public static IEnumerable<object[]> FormatPathData()
        {
            yield return new object[] { string.Empty, string.Empty, string.Empty, string.Empty };
            yield return new object[]
            {
                @"C:\System\Path1;C:\System\Path2;C:\System\Path3",
                @"C:\User\Path1;C:\User\Path2;C:\User\Path3",
                $@"C:\System\Path1;{Environment.NewLine}C:\System\Path2;{Environment.NewLine}C:\System\Path3;",
                $@"C:\User\Path1;{Environment.NewLine}C:\User\Path2;{Environment.NewLine}C:\User\Path3;"
            };
            yield return new object[]
            {
                @"C:\System\Path1;C:\System\Path2;C:\System\Path3;",
                @"C:\User\Path1;C:\User\Path2;C:\User\Path3;",
                $@"C:\System\Path1;{Environment.NewLine}C:\System\Path2;{Environment.NewLine}C:\System\Path3;",
                $@"C:\User\Path1;{Environment.NewLine}C:\User\Path2;{Environment.NewLine}C:\User\Path3;"
            };
        }

        [Theory]
        [MemberData(nameof(FormatPathData))]
        public void FormatPath(string system, string user, string expectedSystem, string expectedUser)
        {
            var mainWindowViewModel = new MainWindowViewModel(
                new EnvironmentVariablePathInMemory(system, user),
                new BackupFake(SaveBackupResult.Cancel),
                new UserFake(true)
            );
            Assert.Equal(expectedSystem, mainWindowViewModel.SystemPath);
            Assert.Equal(expectedUser, mainWindowViewModel.UserPath);
        }

        public static IEnumerable<object[]> SaveData()
        {
            yield return new object[] { string.Empty, string.Empty, string.Empty, string.Empty };
            yield return new object[]
            {
                $@"C:\System\Path1;{Environment.NewLine}C:\System\Path2;",
                $@"C:\User\Path1;{Environment.NewLine}C:\User\Path2;",
                @"C:\System\Path1;C:\System\Path2;",
                @"C:\User\Path1;C:\User\Path2;"
            };
            yield return new object[]
            {
                $@"C:\System\Path1;{Environment.NewLine}C:\System\Path2;{Environment.NewLine}C:\System\Path3",
                $@"C:\User\Path1;{Environment.NewLine}C:\User\Path2;{Environment.NewLine}C:\User\Path3",
                @"C:\System\Path1;C:\System\Path2;C:\System\Path3;",
                @"C:\User\Path1;C:\User\Path2;C:\User\Path3;"
            };
        }

        [Theory]
        [MemberData(nameof(SaveData))]
        public void Save(string formattedSystem, string formattedUser, string expectedSystem, string expectedUser)
        {
            var path = new EnvironmentVariablePathInMemory();
            new MainWindowViewModel(
                path,
                new BackupFake(SaveBackupResult.Done),
                new UserFake(true)
            ).SaveCommand.Execute(new FormattedEnvironmentVariablePathFake(formattedSystem, formattedUser));
            Assert.Equal(expectedSystem, path.System);
            Assert.Equal(expectedUser, path.User);
        }

        [Fact]
        public void SaveNoModifySystemWhenUserIsNotAdministrator()
        {
            var path = new EnvironmentVariablePathInMemory(@"C:\System\Path1;", @"C:\User\Path1;");
                new MainWindowViewModel(
                    path,
                new BackupFake(SaveBackupResult.Done),
                new UserFake(false)
            ).SaveCommand.Execute(new FormattedEnvironmentVariablePathFake(@"C:\System\Path2;", @"C:\User\Path2;"));
            Assert.Equal(@"C:\System\Path1;", path.System);
            Assert.Equal(@"C:\User\Path2;", path.User);
        }

    [Theory]
        [InlineData(false, true)]
        [InlineData(true, false)]
        public void SystemIsReadOnly(bool isAdministrator, bool expectedSystemIsReadOnly)
        {
            Assert.Equal(expectedSystemIsReadOnly,
                new MainWindowViewModel(
                    new EnvironmentVariablePathInMemory(),
                    new BackupFake(SaveBackupResult.Done),
                    new UserFake(isAdministrator)
                ).SystemIsReadOnly
            );
        }
    }
}