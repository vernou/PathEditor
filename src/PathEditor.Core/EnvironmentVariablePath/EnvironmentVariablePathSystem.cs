using System;

namespace PathEditor.Core.EnvironmentVariablePath
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