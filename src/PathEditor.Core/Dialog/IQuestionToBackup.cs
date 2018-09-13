namespace PathEditor.Core.Dialog
{
    public interface IQuestionToBackup
    {
        QuestionToBackupResult Ask();
    }

    public enum QuestionToBackupResult
    {
        YesIWantBackup,
        NoThanks,
        Cancel
    }
}