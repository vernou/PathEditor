namespace PathEditor.Core.EnvironmentVariablePath
{
    public class FormattedEnvironmentVariablePathFake : IFormattedEnvironmentVariablePath
    {
        public FormattedEnvironmentVariablePathFake(string formattedSystem, string formattedUser)
        {
            System = formattedSystem;
            User = formattedUser;
        }

        public string System { get; private set; }
        public string User { get; private set; }
    }
}