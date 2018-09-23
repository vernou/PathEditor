namespace PathEditor.Core.Backup
{
    public interface IBackup
    {
        SaveBackupResult Save(string system, string user);
    }

    public enum SaveBackupResult
    {
        Done,
        Cancel
    }
}