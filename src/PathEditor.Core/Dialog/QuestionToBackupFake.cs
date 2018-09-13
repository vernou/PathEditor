namespace PathEditor.Core.Dialog
{
    public sealed class QuestionToBackupFake : IQuestionToBackup
    {
        private readonly QuestionToBackupResult _result;

        public QuestionToBackupFake(QuestionToBackupResult result) => _result = result;

        public QuestionToBackupResult Ask() => _result;
    }
}