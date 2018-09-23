using System;
using System.Linq;
using System.Windows.Input;
using PathEditor.Core.Backup;
using PathEditor.Core.EnvironmentVariablePath;
using PathEditor.Core.User;

namespace PathEditor.Core
{
    public sealed class MainWindowViewModel
    {
        private readonly IEnvironmentVariablePath _environmentVariablePath;
        private readonly IBackup _backup;
        private readonly IUser _user;

        public MainWindowViewModel(IEnvironmentVariablePath environmentVariablePath, IBackup backup, IUser user)
        {
            _environmentVariablePath = environmentVariablePath;
            _backup = backup;
            _user = user;
        }

        public string SystemPath => FormatPath(_environmentVariablePath.System);
        public string UserPath => FormatPath(_environmentVariablePath.User);
        public bool SystemIsReadOnly => !_user.IsAdministrator;

        public ICommand SaveCommand => new RelayCommand(Save);

        private void Save(object o)
        {
            if (o is IFormattedEnvironmentVariablePath formatted)
            {
                switch (_backup.Save(_environmentVariablePath.System, _environmentVariablePath.User))
                {
                    case SaveBackupResult.Done:
                        break;
                    case SaveBackupResult.Cancel:
                        throw new InvalidOperationException("Backup is canceled.");
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                if(_user.IsAdministrator)
                    _environmentVariablePath.System = ParsePath(formatted.System);
                _environmentVariablePath.User = ParsePath(formatted.User);
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

        private string ParsePath(string formatted)
        {
            if (formatted == string.Empty)
                return string.Empty;
            var raw = formatted.Replace(Environment.NewLine, string.Empty);
            if (raw.Last() != ';')
                raw += ';';
            return raw;
        }
    }
}