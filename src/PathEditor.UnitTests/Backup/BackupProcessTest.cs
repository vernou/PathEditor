using PathEditor.Core.Backup;
using PathEditor.Core.Dialog;
using Xunit;

namespace PathEditor.UnitTests.Backup
{
    public sealed class BackupProcessTest
    {
        [Fact]
        public void AcceptBackup()
        {
            var spy = new BackupFake(SaveBackupResult.Done);
            var process = new BackupProcess(
                spy,
                new QuestionToBackupFake(QuestionToBackupResult.YesIWantBackup)
            );
            Assert.Equal(SaveBackupResult.Done, process.Save("NEW SYSTEM PATH", "NEW USER PATH"));
            Assert.Equal(new[] { "NEW SYSTEM PATH" }, spy.SystemSaved);
            Assert.Equal(new[] { "NEW USER PATH" }, spy.UserSaved);
        }

        [Fact]
        public void WithoutBackup()
        {
            var spy = new BackupFake(SaveBackupResult.Done);
            var process = new BackupProcess(
                spy,
                new QuestionToBackupFake(QuestionToBackupResult.NoThanks)
            );
            Assert.Equal(SaveBackupResult.Done, process.Save("NEW SYSTEM PATH", "NEW USER PATH"));
            Assert.Empty(spy.SystemSaved);
            Assert.Empty(spy.UserSaved);
        }

        [Fact]
        public void CancelBackup()
        {
            var spy = new BackupFake(SaveBackupResult.Done);
            var process = new BackupProcess(
                spy,
                new QuestionToBackupFake(QuestionToBackupResult.Cancel)
            );
            Assert.Equal(SaveBackupResult.Cancel, process.Save("NEW SYSTEM PATH", "NEW USER PATH"));
            Assert.Empty(spy.SystemSaved);
            Assert.Empty(spy.UserSaved);
        }
    }
}