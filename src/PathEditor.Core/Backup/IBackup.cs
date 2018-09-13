namespace PathEditor.Core.Backup
{
    public interface IBackup
    {
        SaveBackupResult Save(string environmentVariablePath);
    }

    public enum SaveBackupResult
    {
        Done,
        Cancel
    }
}