using System;
using Microsoft.Win32;
using PathEditor.Core.Dialog;

namespace PathEditor.App.Dialog
{
    public sealed class AskFile : IAskFile
    {
        public string File()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*",
                FileName = "path_" + DateTime.UtcNow.Ticks + ".txt"
            };
            return saveFileDialog.ShowDialog() == true ? saveFileDialog.FileName : string.Empty;
        }
    }
}