using System;

namespace PathEditor.Core.EnvironmentVariablePath
{
    public sealed class EnvironmentVariablePathSystem : IEnvironmentVariablePath
    {
        public string System
        {
            get => Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
            set => throw new NotImplementedException();
        }

        public string User
        {
            get => Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);
            set => throw new NotImplementedException();
        }
    }
}