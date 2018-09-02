using System;
using System.Linq;
using System.Windows.Input;

namespace PathEditor.Core
{
    public sealed class MainWindowViewModel
    {
        private readonly IEnvironmentVariablePath _environmentVariablePath;

        public MainWindowViewModel(IEnvironmentVariablePath environmentVariablePath)
        {
            _environmentVariablePath = environmentVariablePath;
        }

        public string Path => FormatPath(_environmentVariablePath.Value);
        public ICommand SaveCommand => new RelayCommand(Save);

        private void Save(object o)
        {
            if (o is string paths)
            {
                if (paths != string.Empty)
                {
                    paths = paths.Replace(Environment.NewLine, string.Empty);
                    if (paths.Last() != ';')
                        paths += ';';
                }
                _environmentVariablePath.Value = paths;
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