using System;

namespace PathEditor.Core.EnvironmentVariablePath
{
    public sealed class EnvironmentVariablePathSystem : IEnvironmentVariablePath
    {
        public string System
        {
            get => Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.Machine);
            set => Environment.SetEnvironmentVariable("Path", value, EnvironmentVariableTarget.Machine);
        }

        public string User
        {
            get => Environment.GetEnvironmentVariable("Path", EnvironmentVariableTarget.User);
            set => Environment.SetEnvironmentVariable("Path", value, EnvironmentVariableTarget.User);
        }
    }
}