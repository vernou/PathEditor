using System;
using PathEditor.Core.Dialog;

namespace PathEditor.Core.Backup
{
    public sealed class BackupProcess : IBackup
    {
        private readonly IBackup _backup;
        private readonly IQuestionToBackup _questionToBackup;

        public BackupProcess(IBackup backup, IQuestionToBackup questionToBackup)
        {
            _backup = backup;
            _questionToBackup = questionToBackup;
        }

        public SaveBackupResult Save(string environmentVariablePath)
        {
            switch (_questionToBackup.Ask())
            {
                case QuestionToBackupResult.NoThanks:
                    return SaveBackupResult.Done;
                case QuestionToBackupResult.YesIWantBackup:
                    return _backup.Save(environmentVariablePath);
                case QuestionToBackupResult.Cancel:
                    return SaveBackupResult.Cancel;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}