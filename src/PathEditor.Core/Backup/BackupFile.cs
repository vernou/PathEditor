using System;
using PathEditor.Core.Dialog;

namespace PathEditor.Core.Backup
{
    public sealed class BackupFile : IBackup
    {
        private readonly IAskFile _askFile;

        public BackupFile(IAskFile askFile)
        {
            _askFile = askFile;
        }

        public SaveBackupResult Save(string system, string user)
        {
            var file = _askFile.File();
            if (file == string.Empty)
                return SaveBackupResult.Cancel;
            System.IO.File.WriteAllText(file, Text(system, user));
            return SaveBackupResult.Done;
        }

        private string Text(string system, string user)
        {
            return $@"#System{Environment.NewLine}{system}{Environment.NewLine}#User{Environment.NewLine}{user}";
        }
    }
}