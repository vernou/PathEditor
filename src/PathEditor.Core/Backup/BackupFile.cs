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

        public SaveBackupResult Save(string environmentVariablePath)
        {
            var file = _askFile.File();
            if (file == string.Empty)
                return SaveBackupResult.Cancel;
            System.IO.File.WriteAllText(file, environmentVariablePath);
            return SaveBackupResult.Done;
        }
    }
}