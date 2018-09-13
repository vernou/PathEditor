using System.Collections.Generic;

namespace PathEditor.Core.Backup
{
    public sealed class BackupFake : IBackup
    {
        private readonly SaveBackupResult _result;
        private readonly List<string> _backupSaved = new List<string>();

        public BackupFake(SaveBackupResult result)
        {
            _result = result;
        }

        public SaveBackupResult Save(string environmentVariablePath)
        {
            _backupSaved.Add(environmentVariablePath);
            return _result;
        }

        public IReadOnlyCollection<string> BackupSaved => _backupSaved;
    }
}