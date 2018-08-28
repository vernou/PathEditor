using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace PathEditor.Core
{
    public sealed class MainWindowViewModel
    {
        private readonly IEnvironmentVariablePath _environmentVariablePath;

        public MainWindowViewModel(IEnvironmentVariablePath environmentVariablePath)
        {
            _environmentVariablePath = environmentVariablePath;
        }

        public string Path => _environmentVariablePath.Value?.Replace(";", ";" + Environment.NewLine);
    }
}