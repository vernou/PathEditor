using System;
using System.Linq;

namespace PathEditor.Core.EnvironmentVariablePath
{
    public sealed class FormattedProcessEnvironmentVariablePath
    {
        private readonly IFormattedEnvironmentVariablePath _formatted;

        public FormattedProcessEnvironmentVariablePath(IFormattedEnvironmentVariablePath formattedEnvironmentVariablePath)
        {
            _formatted = formattedEnvironmentVariablePath;
        }

        public string Value => Compute();

        private string Compute()
        {
            if (_formatted.System == string.Empty)
                return _formatted.User;
            return _formatted.System + (_formatted.System.Last() == ';' ? string.Empty : ";") + Environment.NewLine + _formatted.User;
        }
    }
}