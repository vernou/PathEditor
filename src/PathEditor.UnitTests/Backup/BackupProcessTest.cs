using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Assert.Equal(SaveBackupResult.Done, process.Save("NEW PATH"));
            Assert.Equal(1, spy.BackupSaved.Count);
            Assert.Equal("NEW PATH", spy.BackupSaved.First());
        }

        [Fact]
        public void DontWantBackup()
        {
            var spy = new BackupFake(SaveBackupResult.Done);
            var process = new BackupProcess(
                spy,
                new QuestionToBackupFake(QuestionToBackupResult.NoThanks)
            );
            Assert.Equal(SaveBackupResult.Done, process.Save("NEW PATH"));
            Assert.Empty(spy.BackupSaved);
        }

        [Fact]
        public void CancelBackup()
        {
            var spy = new BackupFake(SaveBackupResult.Done);
            var process = new BackupProcess(
                spy,
                new QuestionToBackupFake(QuestionToBackupResult.Cancel)
            );
            Assert.Equal(SaveBackupResult.Cancel, process.Save("NEW PATH"));
            Assert.Empty(spy.BackupSaved);
        }
    }
}