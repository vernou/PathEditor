using System;
using System.Collections.Generic;
using System.Text;

namespace PathEditor.Core
{
    public sealed class EnvironmentVariablePathSystem : IEnvironmentVariablePath
    {
        public string Value => Environment.GetEnvironmentVariable("Path");
    }
}