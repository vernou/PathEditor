using System;
using System.Linq;
using System.Windows.Input;
using PathEditor.Core.Backup;
using PathEditor.Core.Dialog;
using PathEditor.Core.EnvironmentVariablePath;

namespace PathEditor.Core
{
    public sealed class MainWindowViewModel
    {
        private readonly IEnvironmentVariablePath _environmentVariablePath;
        private readonly IBackup _backup;

        public MainWindowViewModel(IEnvironmentVariablePath environmentVariablePath, IBackup backup)
        {
            _environmentVariablePath = environmentVariablePath;
            _backup = backup;
        }

        public string Path => FormatPath(_environmentVariablePath.Value);

        public ICommand SaveCommand => new RelayCommand(Save);

        private void Save(object o)
        {
            if (o is string formated)
            {
                switch (_backup.Save(_environmentVariablePath.Value))
                {
                    case SaveBackupResult.Done:
                        break;
                    case SaveBackupResult.Cancel:
                        throw new InvalidOperationException("Backup is canceled.");
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                var raw = ParsePath(formated);
                _environmentVariablePath.Value = raw;
            }
        }

        private string FormatPath(string raw)
        {
            if (raw == string.Empty)
                return string.Empty;
            if (raw.Last() == ';')
                raw = raw.Substring(0, raw.Length - 1);
            return string.Join(Environment.NewLine, raw.Split(';').Select(s => s + ";").ToArray());
        }

        private string ParsePath(string formated)
        {
            if (formated == string.Empty)
                return string.Empty;
            var raw = formated.Replace(Environment.NewLine, string.Empty);
            if (raw.Last() != ';')
                raw += ';';
            return raw;
        }
    }
}