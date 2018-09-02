using System;
using System.Collections.Generic;
using System.Text;

namespace PathEditor.Core
{
    public sealed class EnvironmentVariablePathSystem : IEnvironmentVariablePath
    {
        public string Value
        {
            get => Environment.GetEnvironmentVariable("Path");
            set => throw new NotImplementedException();
        }
    }
}