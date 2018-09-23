namespace PathEditor.Core.EnvironmentVariablePath
{
    public sealed class EnvironmentVariablePathInMemory : IEnvironmentVariablePath
    {
        public EnvironmentVariablePathInMemory() :
            this(@"C:\System\Path1;C:\System\Path2;C:\System\Path3;", @"C:\User\Path1;C:\User\Path2;C:\User\Path3;")
        { }

        public EnvironmentVariablePathInMemory(string user) :
            this(@"C:\System\Path1;C:\System\Path2;C:\System\Path3;", user)
        { }

        public EnvironmentVariablePathInMemory(string system, string user)
        {
            System = system;
            User = user;
        }

        public string System { get; set; }
        public string User { get; set; }
    }
}