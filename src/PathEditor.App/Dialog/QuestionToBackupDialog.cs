using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PathEditor.Core.Dialog;

namespace PathEditor.App.Dialog
{
    public sealed class QuestionToBackupDialog : IQuestionToBackup
    {
        public QuestionToBackupResult Ask()
        {
            switch (MessageBox.Show("Do you want make a backup before apply change?", "Backup?", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    return QuestionToBackupResult.YesIWantBackup;
                case MessageBoxResult.No:
                    return QuestionToBackupResult.NoThanks;
                case MessageBoxResult.Cancel:
                    return QuestionToBackupResult.Cancel;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}