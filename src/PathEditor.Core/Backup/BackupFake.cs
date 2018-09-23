using System.Collections.Generic;

namespace PathEditor.Core.Backup
{
    public sealed class BackupFake : IBackup
    {
        private readonly SaveBackupResult _result;
        private readonly List<string> _systemSaved = new List<string>();
        private readonly List<string> _userSaved = new List<string>();

        public BackupFake(SaveBackupResult result)
        {
            _result = result;
        }

        public SaveBackupResult Save(string system, string user)
        {
            _systemSaved.Add(system);
            _userSaved.Add(user);
            return _result;
        }

        public IReadOnlyCollection<string> SystemSaved => _systemSaved;
        public IReadOnlyCollection<string> UserSaved => _userSaved;
    }
}