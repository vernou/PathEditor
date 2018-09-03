using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PathEditor.Core
{
    public sealed class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _formatedPath;
        private readonly IEnvironmentVariablePath _environmentVariablePath;

        public MainWindowViewModel(IEnvironmentVariablePath environmentVariablePath)
        {
            _environmentVariablePath = environmentVariablePath;
        }

        public string Path
        {
            get => _formatedPath ?? (_formatedPath = FormatPath(_environmentVariablePath.Value));
            set
            {
                _formatedPath = AutoBreakLine(value);
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand => new RelayCommand(Save);

        private void Save(object o)
        {
            if (o is string formated)
            {
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

        private string AutoBreakLine(string edited)
        {
            if(edited == string.Empty)
                return edited;
            for (var separatorIndex = edited.IndexOf(';'); separatorIndex != -1; separatorIndex = edited.IndexOf(';', separatorIndex + 1))
            {
                if ((separatorIndex+1) != edited.Length && edited.IndexOf(Environment.NewLine, separatorIndex) != separatorIndex + 1)
                {
                    edited = edited.Insert(separatorIndex+1, Environment.NewLine);
                    separatorIndex += Environment.NewLine.Length;
                }
            }
            return edited;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}